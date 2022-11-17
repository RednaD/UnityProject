using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TabGroup : MonoBehaviour
{
    public Tab              defaultTab;
    [SerializeField] Tab    selectedTab;

    Tab[]                   _tabs;
    public IntVariable      index;
    int                     indexMax;

    public CharacterEventSO resetCharacterSelection;
    TacticalCharacter       character;

    public void Awake()
    {
        _tabs = GetComponentsInChildren<Tab>(true);
        indexMax = _tabs.Length - 1;
        index.v = System.Array.IndexOf(_tabs, defaultTab);
    }

    public void OnTabClickedOn(Interactable tab)
    {
        OnTabSelected(tab as Tab);
    }

    public void OnTabSelected(Tab newTab)
    {
        if (selectedTab != null) selectedTab.SetTabState(selectedTab.isActive);

        selectedTab = newTab;
        index.v = System.Array.IndexOf(_tabs, selectedTab);
        selectedTab.SetSelected();
    }

    public void Update()                // TODO TO REMOVE!!
    {
        float wheelAxis = Input.GetAxis("Mouse ScrollWheel");
        if (wheelAxis != 0)
        {
            int res = FindNextEnableTab(wheelAxis);
            if (res != -1) OnTabSelected(_tabs[res]);
            else resetCharacterSelection.Raise(null);
        }
    }

    public void DisableTab(Tab tab)
    {
        tab.Disable();
        selectedTab = null;
        int res = FindNextEnableTab(1);
        if (res != -1) OnTabSelected(_tabs[res]);
        else resetCharacterSelection.Raise(null);
    }

    public int FindNextEnableTab(float diff)
    {
        int i = index.v;
        while (!_tabs[i].isInteractable)
        {
            if (diff > 0) i = (i == indexMax ? 0 : i + 1);
            else i = (i == 0 ? indexMax : i - 1);
            if (i == index.v) return -1;
        }
        return i;
    }

    public void DisplayCharacterMenu(TacticalCharacter _character)
    {
        character = _character;
        Refresh();
    }

    public void Refresh()
    {
        Debug.Log(character);
        if (character.actionsLeft.Count == 0) resetCharacterSelection.Raise(null);
        index.v = System.Array.IndexOf(_tabs, defaultTab);
        foreach (Tab tab in _tabs)
        {
            tab.SetTabState(character.actionsLeft == null || character.actionsLeft.Contains(tab.condition as StateSO));
        }
        OnTabSelected(defaultTab.isInteractable ? defaultTab : _tabs[FindNextEnableTab(1)]);
    }

    public void Reset()
    {
        index.v = System.Array.IndexOf(_tabs, defaultTab);
    }
}