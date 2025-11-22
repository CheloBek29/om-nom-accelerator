using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private List<Task> m_tasks;

    private QuestManager _questManager;
    private int _currentTask = 0;

    private void Awake()
    {
        _questManager = FindObjectOfType<QuestManager>();
    }

    private void Start()
    {
        //StartTask();
    }

    public void StartTask()
    {
        if (_currentTask < m_tasks.Count)
        {
            Task task = m_tasks[_currentTask];
            task._taskUI.SetActive(true);
        }
    }

    public void FinishTask(string answer)
    {
        Task task = m_tasks[_currentTask];
        if (task.CheckAnswer(answer))
        {
            if (task._isStartingQuest)
                _questManager.StartQuest();
            _currentTask++;
            if (task._isStartingNextTask)
                StartTask();
        }
    }
}
