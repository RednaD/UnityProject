using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public Tab defaultTab;
    [SerializeField] Tab selectedTab;

    Tab[] _tabs;

    public void Start()
    {
        _tabs = GetComponentsInChildren<Tab>();
        foreach (var tab in _tabs)
        {
            tab.SetIdle();
            tab.tabButton.onClick.AddListener(() => OnTabSelected(tab));
        }

        OnTabSelected(defaultTab);
    }

    void OnDestroy()
    {
        foreach (var tabButton in _tabs)
        {
            tabButton.tabButton.onClick.RemoveListener(() => OnTabSelected(tabButton));
        }
    }

    public void OnTabSelected(Tab newTab)
    {
        if (selectedTab != null)
        {
            selectedTab.SetIdle();
        }

        selectedTab = newTab;
        selectedTab.SetSelected();
    }

    
}