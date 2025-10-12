using UnityEngine;
using UnityEngine.UI;

public class Bookmarks : MonoBehaviour
{
    [SerializeField] private GameObject m_currentTab;
    [SerializeField] private GameObject m_currentGroup;
    [SerializeField] private GameObject m_scrollRect;


    public void ChangeTab(GameObject tab)
    {
        m_currentTab.SetActive(false);
        tab.SetActive(true);

        m_currentTab = tab;
        m_scrollRect.GetComponent<ScrollRect>().content = m_currentTab.GetComponent<RectTransform>();
    }

    public void ChangeGroup(GameObject group)
    {
        m_currentGroup.SetActive(false);

        group.SetActive(true);

        m_currentGroup = group;
    }
}