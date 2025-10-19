using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text m_answerField;

    private TaskManager _taskManager;

    private void Awake()
    {
        _taskManager = FindObjectOfType<TaskManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(HandleTask);
    }

    private void HandleTask()
    {
        _taskManager.FinishTask(m_answerField.text);
    }
}
