using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    [Header("Cursor Settings")]
    [SerializeField] private Image m_cursor;
    [SerializeField] private Vector2 m_originalSize;
    [SerializeField] private Vector2 m_hoverSize;

    private void Start()
    {
        m_cursor.rectTransform.sizeDelta = m_originalSize;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HoveredQuest()
    {
        m_cursor.rectTransform.sizeDelta = m_hoverSize;
    }

    public void HoverEndedQuest()
    {
        m_cursor.rectTransform.sizeDelta = m_originalSize;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
