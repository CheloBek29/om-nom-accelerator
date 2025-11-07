using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<Quest> m_quests;
    private UIManager _uiManager;
    private NotebookManager _notebookManager;
    private InteractableComponentManager _iManager;
    private TaskManager _taskManager;
    private int _activeQuest = 0;
    private bool _isQuestActive = false;

    private void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _notebookManager = FindObjectOfType<NotebookManager>();
        _iManager = FindAnyObjectByType<InteractableComponentManager>();
        _taskManager = FindObjectOfType<TaskManager>();
    }

    private void Start()
    {
        StartQuest();
    }

    public void StartQuest()
    {
        if (_activeQuest < m_quests.Count && !_isQuestActive)
        {
            Quest quest = m_quests[_activeQuest];
            _isQuestActive = true;
            _uiManager.ShowPopUp(quest._questText);
            _iManager.ActivateInteractable(quest._endTrigger);
        }
    }

    public void CheckQuest(GameObject trigger)
    {
        if (_isQuestActive)
        {
            Quest quest = m_quests[_activeQuest];
            if (quest._endTrigger == trigger)
            {
                if (quest._noteToAdd)
                {
                    _notebookManager.AddNote(quest._noteToAdd);
                }
                _uiManager.HidePopUp();
                _iManager.DeactivateInteractable(quest._endTrigger.GetComponent<InteractableObject>());
                if (quest._isStartingTask)
                    _taskManager.StartTask();
                _activeQuest++;
                _isQuestActive = false;
            }
        }
    }
}
