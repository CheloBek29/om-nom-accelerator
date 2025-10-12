using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class InteractableComponentManager : MonoBehaviour
{
    public UnityEvent OnHovered;

    [Header("Scene Changer")]
    [SerializeField] private UIManager m_sceneChanger;

    [Header("Cursor Settings")]
    [SerializeField] private Image m_cursor;
    [SerializeField] private Vector2 m_originalSize;
    [SerializeField] private Vector2 m_hoverSize;

    [Header("Interactive")]
    [SerializeField] private bool m_isUI;
    [SerializeField] private GameObject m_uiToShow;

    [SerializeField] private bool m_isNote;
    [SerializeField] private GameObject m_noteToAdd;

    [Header("Tutorial Settings")]
    [SerializeField] private bool m_isTutorial;
    [SerializeField] private GameObject m_tutorialPopup;

    private Outline _outline;
    private InteractableComponentManager _componentManager;
    private void Start()
    {
        _outline = gameObject.GetComponent<Outline>();
        _outline.enabled = m_isTutorial;
        if (m_isTutorial) _outline.OutlineWidth = 10;
        _componentManager = gameObject.GetComponent<InteractableComponentManager>();
    }

    public void ActivateTutorialHint()
    {
        m_isTutorial = true;
    }

    private void OnMouseEnter()
    {
        if (_componentManager.enabled)
        {
            if (m_isTutorial)
            {
                _outline.OutlineWidth = 4;
                m_isTutorial = false;
                m_sceneChanger.HidePopUp();
                OnHovered.Invoke();
            }
            m_cursor.rectTransform.sizeDelta = m_hoverSize;
            _outline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (_componentManager.enabled)
        {
            m_cursor.rectTransform.sizeDelta = m_originalSize;
            _outline.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (_componentManager.enabled)
        {
            _outline.enabled = false;

            if(m_isUI) m_sceneChanger.ShowUI(m_uiToShow);
            if(m_isNote) m_noteToAdd.SetActive(true);
        }
    }
}
