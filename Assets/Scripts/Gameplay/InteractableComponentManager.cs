using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class InteractableComponentManager : MonoBehaviour
{
    [SerializeField] private GameObject _defaultUI;

    private CursorManager _cursorManager;
    private UIManager _uiManager;
    private QuestManager _questManager;

    private List<InteractableObject> _interactableObjects = new List<InteractableObject>();
    private List<InteractableObject> _mainObjects = new List<InteractableObject>();

    private void Awake()
    {
        _cursorManager = FindObjectOfType<CursorManager>();
        _uiManager = FindObjectOfType<UIManager>();
        _questManager = FindObjectOfType<QuestManager>();

        InteractableObject[] objects = FindObjectsOfType<InteractableObject>();
        foreach (var item in objects)
        {
            if (item.m_isInitiallyActive)
                _interactableObjects.Add(item);
        }

        _mainObjects.AddRange(InteractableObject.FindInteractableObjectsWithTag("MainObject"));
    }

    private void Start()
    {
        _interactableObjects.ForEach(i => AddListeners(i));

        _uiManager.OnUIOpened.AddListener(DisableAllInteractables);
        _uiManager.OnUIClosed.AddListener(EnableAllInteractables);
    }

    private void AddListeners(InteractableObject item)
    {
        item.OnHoveredQuest.AddListener(_cursorManager.HoveredQuest);
        item.OnHoverEndedQuest.AddListener(_cursorManager.HoverEndedQuest);
        item.OnClickedQuest.AddListener(() => ClickedInteractable(item));
        item.OnClickedQuest.AddListener(() => _questManager.CheckQuest(item.gameObject));
    }

    private void RemoveListeners(InteractableObject item)
    {
        item.OnHoveredQuest.RemoveAllListeners();
        item.OnHoverEndedQuest.RemoveAllListeners();
        item.OnClickedQuest.RemoveAllListeners();
    }

    private void ClickedInteractable(InteractableObject obj)
    {
        if (obj.uiToShow)
            _uiManager.ShowUI(obj.uiToShow);
        else
            _uiManager.ShowUI(_defaultUI);
    }

    public void ActivateInteractable(GameObject obj)
    {
        if (obj && obj.TryGetComponent<InteractableObject>(out InteractableObject component)) {
            _interactableObjects.Add(component);
            component.enabled = true;
            AddListeners(component);
        }
    }

    public void DeactivateInteractable(InteractableObject obj)
    {
        RemoveListeners(obj);
        obj.enabled = false;
        if (!obj.m_isInitiallyActive)
            _interactableObjects.Remove(obj);
    }

    private void EnableAllInteractables()
    {
        foreach (var item in _interactableObjects)
        {
            item.enabled = true;
            AddListeners(item);
        }
    }

    private void DisableAllInteractables()
    {
        foreach (var item in _interactableObjects)
        {
            item.enabled = false;
            RemoveListeners(item);
        }
    }
}
