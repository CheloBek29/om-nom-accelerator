using UnityEngine;

public class Bookmarks : MonoBehaviour
{
    [SerializeField] private GameObject currentTab;
    [SerializeField] private GameObject currentGroup;


    public void ChangeTab(GameObject tab)
    {
        currentTab.SetActive(false);

        tab.SetActive(true);

        currentTab = tab;
    }

    public void ChangeGroup(GameObject group)
    {
        currentGroup.SetActive(false);

        group.SetActive(true);

        currentGroup = group;
    }
}