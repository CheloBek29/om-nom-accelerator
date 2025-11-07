using System;
using UnityEngine;

[Serializable]
public class Task
{
    public GameObject _taskUI;
    public bool _isStartingQuest;

    private string _correctAnswer;

    public bool CheckAnswer(string answer)
    {
        return answer == _correctAnswer;
    }
}