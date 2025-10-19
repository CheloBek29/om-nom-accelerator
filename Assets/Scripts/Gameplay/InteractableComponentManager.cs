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
        _interactableObjects.AddRange(FindObjectsOfType<InteractableObject>());
        _mainObjects.AddRange(InteractableObject.FindInteractableObjectsWithTag("MainObject"));

        _interactableObjects.ForEach(i => AddListeners(i));
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
        InteractableObject component = obj.GetComponent<InteractableObject>();
        if (component && !_mainObjects.Contains(component))
        {
            _interactableObjects.Add(component);
            AddListeners(component);
            component.enabled = true;
        }
    }

    public void DeactivateInteractable(InteractableObject obj)
    {
        if (!_mainObjects.Contains(obj))
        {
            _interactableObjects.Remove(obj);
            RemoveListeners(obj);
            obj.enabled = false;
        }
    }
}
