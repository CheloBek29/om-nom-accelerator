using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Outline))]
public class InteractableObject : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnHoveredQuest;
    [HideInInspector] public UnityEvent OnHoverEndedQuest;
    [HideInInspector] public UnityEvent OnClickedQuest;

    [Tooltip("Необязательное поле, если не указано открывается UI по умолчанию - дневник")]
    public GameObject uiToShow;

    private Outline _outline;

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

    private void OnMouseEnter()
    {
        _outline.enabled = true;
        OnHoveredQuest.Invoke();
    }

    private void OnMouseExit()
    {
        _outline.enabled = false;
        OnHoverEndedQuest.Invoke();
    }

    private void OnMouseDown()
    {
        OnClickedQuest.Invoke();
    }

    private void OnDisable()
    {
        _outline.enabled = false;
    }

    public static List<InteractableObject> FindInteractableObjectsWithTag(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        List<InteractableObject> resList = new List<InteractableObject>();

        foreach (var item in gameObjects)
        {
            InteractableObject component = item.GetComponent<InteractableObject>();
            if (component)
                resList.Add(component);
        }

        return resList;
    }
}
