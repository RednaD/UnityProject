using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticalController : MonoBehaviour, IController
{
    Interactable                _hovered;
    RaycastHit                  hit;
    public InteractionTypeEnum  InteractionType;

    public GameObject           TacticalOverlay;
    public TabGroup             TabGroup;

    // TODO mettre dans un SO LevelManager ou autre, chargé en début de LevelManager
    public EventSO              onActionEnded;
    public LevelManager         LevelManager;
    public PartySO_GO           partyPool;
    public PartySO_TC           party;
    public GroupeSO_TNPC        enemies;    // TODO make it so only a few are selected by random
    //public SelectionVariable    selection;
    public TacticalCharacter    SelectedCharacter;

    //public IntVariable  delay;

    // Level
    public GridManager          Grid;
    //public ConditionsVictoire ConditionsVictoire;

    public BoolVariable         isButtonPressed;

    // TODO add HardReset() pour recommencer le niveau
    // TODO clic gauche : sélection ; clic droit : dé-sélection

    public void Awake()
    {
        LevelManager.Init();

        GameObject playerGO;
        TacticalCharacter playerTC;
        party.v.Clear();
        int i = 0;
        while (i < partyPool.v.Count)
        {
            playerGO = Instantiate(partyPool.v[i]);
            playerTC = playerGO.GetComponent<TacticalCharacter>();
            playerTC.SetToTile(LevelManager.Grid.startPosParty[i]);
            party.v.Add(playerTC);
            i++;
        }

        GameObject enemyGO;
        TacticalNPC enemyTC;
        enemies.v.Clear();
        i = 0;
        while (i < LevelManager.level.enemiesPool.v.Count)
        {
            enemyGO = Instantiate(LevelManager.level.enemiesPool.v[i]);
            enemyTC = enemyGO.GetComponent<TacticalNPC>();
            enemyTC.SetToTile(LevelManager.Grid.startPosEnemies[i]);
            enemies.v.Add(enemyTC);
            i++;
        }
    }

    public void Start()
    {
        SelectedCharacter = party.v[0];
        OnNewTurn();
    }

    public void HandleInput()
    {
        if (isButtonPressed.v)
        {
            isButtonPressed.v = false;
            return;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            var interactable = hit.transform.GetComponent<Interactable>();

            if (interactable == null && _hovered != null)
            {
                _hovered.SetHover(false);
                _hovered = null;
            }
            if (interactable != null)
            {
                if (interactable != _hovered && _hovered != null) _hovered.SetHover(false);
                if (interactable.CheckIfInteractable())
                {
                    _hovered = interactable;
                    _hovered.SetHover(true);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    interactable.TryInteract(InteractionType.action);
                }
                else if (Input.GetMouseButtonUp(1))
                {
                    interactable.TryInteract(InteractionType.action);
                }
            }
        }

        // LEFT MOUSE BUTTON DESELECTION
        /*if (Input.GetMouseButtonUp(1))
        {
            if (_selection != null)
            {
                Debug.Log("You shouldn't be here... O.O");
                _selection.OnDeselect();
                _selection = null;
            }
            // else open contextual menu ?
        }*/

        // MOUSE WHEEL NAVIGATION
        
        float wheelAxis = Input.GetAxis("Mouse ScrollWheel");
        if (wheelAxis != 0)
        {
            TabGroup.TryChangeTab(wheelAxis);
        }
    }

    public void OnNewTurn()
    {
        Debug.Log("Starting new turn");
        StartCoroutine(StartNewTurn());
    }

    // TODO statemachine ?
    IEnumerator StartNewTurn()
    {
        foreach(TacticalCharacter character in party.v) character.Reset();
        //foreach(TacticalNPC npc in enemy.v) enemy.Reset();
        yield return StartCoroutine(LevelManager.Grid.Reset(party, enemies));
        Debug.Log("First player is " + SelectedCharacter);
        // TODO pas TryInteract, on doit le selectionner différemment pour ne pas avoir l'animation de sélection de perso
        SelectedCharacter.OnSelect();
    }

    public void OnCharacterSelected(TacticalCharacter newActiveCharacter)
    {
        //StartCoroutine(LevelManager.Grid.Reset());
        //foreach(TacticalCharacter character in party.v) character.onSetSelection(activeCharacter);
        //SelectedCharacter.SetSelectionState(false);
        Debug.Log("activeCharacter is " + newActiveCharacter);
        SelectedCharacter = newActiveCharacter;
        //SelectedCharacter.SetSelectionState(true);
        //onShowCharacterActions.Raise(activeCharacter);
    }

    public void OnCharacterMoving(TacticalCharacter character)
    {
        Debug.Log(character.name + " is about to move");
        StartCoroutine(CharacterMoving(character));
    }

    IEnumerator CharacterMoving(TacticalCharacter character)
    {
        yield return StartCoroutine(LevelManager.Grid.Reset(party, enemies));
        LevelManager.Grid.GetTile(character.posX, character.posZ).FindReachableTiles(character, LevelManager.Grid.grid);
    }

    public void OnCharacterAttacking(TacticalCharacter character)
    {
        Debug.Log(character.name + " is preparing an attack");
        StartCoroutine(LevelManager.Grid.Reset(party, enemies));
        character.FindReachableTargets(enemies);
    }

    public void OnCharacterUsingSpecial(TacticalCharacter character)
    {
        Debug.Log(character.name + " is preparing his special");
        StartCoroutine(LevelManager.Grid.Reset(party, enemies));
        //character.FindReachableTargets(enemies);
    }

    public void OnFight(TacticalNPC enemy)
    {

    }

    public void OnEnemyHasDied(TacticalNPC enemy)
    {
        // TODO animate enemy's death
        Debug.Log("Enemies remaining before death: " + enemies.v.Count);
        enemies.v.Remove(enemy);
        enemy.gameObject.SetActive(false);
        //Destroy(enemy);
        Debug.Log("Enemies remaining after death: " + enemies.v.Count);
        LevelManager.Grid.Reset(party, enemies);
        onActionEnded.Raise();
    }
}
