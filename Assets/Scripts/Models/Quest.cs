using System;
using UnityEngine;

[Serializable]
public class Quest
{
    public GameObject _endTrigger;
    public string _questText;
    public GameObject _noteToAdd;
    public bool _isStartingTask;
    public bool _isStartingQuest;
}