using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskValidator : MonoBehaviour
{
    [SerializeField] private UIManager m_uiManager;
    [SerializeField] private string m_correctAnswer;
    [SerializeField] private GameObject m_nextTask;

    [Header("Pop Up")]
    [SerializeField] private bool m_needPopUp;
    [SerializeField] private string m_popUpText;
    [SerializeField] private InteractableComponentManager m_popUpTrigger;

    public void checkValue(TMP_InputField input)
    {
        if (input.text.ToLower() == m_correctAnswer)
        {
            m_nextTask.SetActive(true);
            if (m_needPopUp)
            {
                m_uiManager.ShowPopUp(m_popUpText);
                m_popUpTrigger.ActivateTutorialHint();
            }
        }
    }

    public void OnPopUpTriggered()
    {
        m_uiManager.HidePopUp();
    }
}
