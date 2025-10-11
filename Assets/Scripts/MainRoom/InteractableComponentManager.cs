using UnityEngine;
using UnityEngine.UI;

public class InteractableComponentManager : MonoBehaviour
{
    [Header("Scene Changer")]
    [SerializeField] private SceneChanger m_sceneChanger;

    [Header("Cursor Settings")]
    [SerializeField] private Image m_cursor;
    [SerializeField] private Vector2 m_originalSize;
    [SerializeField] private Vector2 m_hoverSize;

    [Header("Scene")]
    [SerializeField] private string m_scene;

    private void OnMouseEnter()
    {
        m_cursor.rectTransform.sizeDelta = m_hoverSize;
        gameObject.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {
        m_cursor.rectTransform.sizeDelta = m_originalSize;
        gameObject.GetComponent<Outline>().enabled = false;
    }

    private void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.None;
        m_sceneChanger.ChangeScene(m_scene);
    }
}
