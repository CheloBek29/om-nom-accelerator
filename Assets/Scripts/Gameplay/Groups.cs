using UnityEngine;

public class Groups : MonoBehaviour
{
    [SerializeField] private GameObject currentTab;

    public void ChangeTab(GameObject tab)
    {
        currentTab.SetActive(false);

        tab.SetActive(true);

        currentTab = tab;
    }
}