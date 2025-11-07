using System;
using UnityEngine;

[Serializable]
public class Task
{
    public GameObject _taskUI;
    public bool _isStartingQuest;
    public bool _isStartingNextTask;

    [SerializeField] private string _correctAnswer;

    public bool CheckAnswer(string answer)
    {
        return answer.Substring(0, answer.Length - 1).Equals(_correctAnswer, StringComparison.OrdinalIgnoreCase) || answer.Equals(_correctAnswer, StringComparison.OrdinalIgnoreCase);
    }
}