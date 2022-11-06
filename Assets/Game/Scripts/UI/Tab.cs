using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Tab : Activable
{
    /*[Header("Refs")]
    [SerializeField] Image logoImage;
    [Header("Idle")]
    [SerializeField] Sprite idleSprite;
    [SerializeField] Color idleBGColor = Color.gray;
    [Header("Selected")]
    [SerializeField] Sprite selectedSprite;
    [SerializeField] Color selectedBGColor = Color.white;
    [SerializeField] GameObject tabCanvas;*/

    public Button               tabButton;
    public Image                image;

    [SerializeField] Color      idleColor = Color.gray;
    [SerializeField] Color      selectedColor = Color.white;
    [SerializeField] Color      disabledColor = Color.black;

    public EnumEventSO          changeTabEvent;
    public EnumSO               condition;
    public InteractableEventSO  tabClickedOn;

    void Awake()
    {
        //tabButton = GetComponent<Button>();
        //image = GetComponent<Image>();
    }

    public void Disable()
    {
        SetState(false);
        SetInteractable(false);
        tabButton.interactable = isInteractable;
        image.color = disabledColor;
    }

    public void SetIdle()
    {
        isInteractable = true;
        tabButton.interactable = isInteractable;
        image.color = idleColor;
        /*logoImage.sprite = idleSprite;
        logoImage.color = idleColor;
        tabCanvas.SetActive(false);*/
    }

    public override void OnSelect()
    {
        tabClickedOn.Raise(this);
    }

    public void SetTabState(bool state)
    {
        SetState(state);
        SetInteractable(state);
        tabButton.interactable = isInteractable;
        image.color = (state ? idleColor : disabledColor);
    }
    
    public void SetSelected()
    {
        SetInteractable(false);
        tabButton.interactable = isInteractable;
        image.color = selectedColor;
        changeTabEvent.Raise(condition);
        /*logoImage.sprite = selectedSprite;
        logoImage.color = selectedColor;
        tabCanvas.SetActive(true);*/
    }
}