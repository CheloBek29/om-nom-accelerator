using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskValidator : MonoBehaviour
{
    [SerializeField] private string m_correctAnswer;
    [SerializeField] private GameObject m_nextTask;

    public void checkValue(TMP_InputField input)
    {
        if (input.text.ToLower() == m_correctAnswer)
        {
            m_nextTask.SetActive(true);
        }
    }
}
