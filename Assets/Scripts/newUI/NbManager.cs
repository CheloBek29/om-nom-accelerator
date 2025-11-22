using UnityEngine;

public class NbManager : MonoBehaviour
{
    [SerializeField] private GameObject m_bookmarkHidden, m_bookmarkVisible, m_backToTab;
    [SerializeField] private GameObject m_currentNote, m_currentTab, m_currentContentTable;

    public void OpenNote(GameObject note)
    {
        m_currentContentTable.SetActive(false);
        
        m_currentNote = note;
        note.SetActive(true);

        m_bookmarkVisible.SetActive(false); m_bookmarkHidden.SetActive(true);
        m_backToTab.SetActive(true);
    }

    public void CloseNote()
    {
        m_currentNote.SetActive(false);
        m_currentContentTable.SetActive(true);

        m_bookmarkVisible.SetActive(true); m_bookmarkHidden.SetActive(false);
        m_backToTab.SetActive(false);
    }

    public void ChangeTab(GameObject tab)
    {
        CloseNote();
        m_currentTab.SetActive(false);
        m_currentContentTable = tab.GetComponent<TabManager>().GetContentTable();

        m_currentTab = tab;

        tab.SetActive(true);
    }
}
