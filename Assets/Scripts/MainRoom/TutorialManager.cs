using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private UIManager m_uiManager;
    [SerializeField] private string m_tutorialText;
    [SerializeField] private InteractableComponentManager m_triggerComponent;
    [SerializeField] private bool m_isGlobal;

    private bool _isTutorialActive = false;

    public void OnClicked()
    {
        Debug.Log("Clicked on tutorial manager");
        if (!m_isGlobal && !_isTutorialActive)
            StartTutorial(m_tutorialText, m_triggerComponent);
    }

    public void StartTutorial(string text, InteractableComponentManager trigger)
    {
        m_uiManager.ShowPopUp(text);
        _isTutorialActive = true;
        m_triggerComponent = trigger;
        m_triggerComponent.ActivateTutorialHint();
    }

    public void OnTutorialTriggered()
    {
        if (_isTutorialActive)
        {
            m_uiManager.HidePopUp();
            _isTutorialActive = false;
        }
    }
}
