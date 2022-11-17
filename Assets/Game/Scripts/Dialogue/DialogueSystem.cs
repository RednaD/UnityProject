using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public BoolEventSO      onDialogueStart;
    public GameObject       dialogueBox;
    public Image            leftSprite;
    public Image            rightSprite;
    public TextMeshProUGUI  text;
    public float            dialogueSpeed;      // the less, the fastest
    public PlayerDataSO     player;

    private bool            isDialogueEnd;
    private DialogueSO      currentLine;
    public DialogueSO       dialogue;

    private Coroutine       readLineCoroutine;
    private List<EnumSO>    choicesMade = new List<EnumSO>();
    
    public void GetDialogue(DialogueTreeSO dialogueTree)
    {
        Debug.Log("Muh");
        dialogue = dialogueTree.GetDialogue(player.choices);
        if (dialogue != null) StartCoroutine(ReadDialogue());
    }

    IEnumerator ReadDialogue()
    {
        dialogueBox.SetActive(true);
        enabled = true;
        isDialogueEnd = false;
        onDialogueStart.Raise(true);
        choicesMade.Clear();
        choicesMade.Add(dialogue as EnumSO);
        currentLine = null;

        readLineCoroutine = StartCoroutine(ReadNextLine());
        yield return new WaitUntil (() => isDialogueEnd);

        foreach (EnumSO choice in choicesMade) if (!player.choices.Contains(choice)) player.choices.Add(choice);
        onDialogueStart.Raise(false);
        dialogueBox.SetActive(false);
        enabled = false;
    }

    IEnumerator ReadNextLine()
    {
        if (currentLine != null) currentLine.GetNextLine(player.choices);
        else currentLine = dialogue;
        Debug.Log(currentLine);
        text.text = "";

        foreach (char letter in currentLine.content.ToCharArray())
        {
            // if special character, wait even more
            text.text += letter;
            yield return new WaitForSeconds(dialogueSpeed);
            if (letter == '.') yield return new WaitForSeconds(0.4f);
        }

        if (currentLine.nextLine == null)
        {
        //  changer anim de l'icone pour indiquer fin du dialogue
        }
        yield return null;
        readLineCoroutine = null;
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (readLineCoroutine == null)
            {
                Debug.Log(currentLine.nextLine.Count == 0);
                if (currentLine.nextLine.Count == 0) isDialogueEnd = true;
                else readLineCoroutine = StartCoroutine(ReadNextLine());
            }
            else
            {
                StopCoroutine(readLineCoroutine);
                readLineCoroutine = null;
                text.text = currentLine.content;
            }
        }
    }
}
        //if (player.choices.Contains(dialogue as EnumSO) || dialogue.firstReplayLine == null) readLineCoroutine = StartCoroutine(ReadLine(dialogue.firstLine));
        //else readLineCoroutine = StartCoroutine(ReadLine(dialogue.firstReplayLine));
