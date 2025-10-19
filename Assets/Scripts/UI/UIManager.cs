using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public UnityEvent OnUIOpened;
    public UnityEvent OnUIClosed;

    [SerializeField] private GameObject m_popUp;
    [SerializeField] private TMP_Text m_popUpText;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    public void ShowUI(GameObject ui)
    {
        InteractableComponentManager[] interactable = FindObjectsOfType<InteractableComponentManager>();
        foreach (var el in interactable)
        {
            el.enabled = false;
        }
        _camera.GetComponent<CameraMovement>().enabled = false;
        ui.SetActive(true);
        OnUIOpened.Invoke();
    }

    public void HideUI()
    {
        GameObject[] UIs = GameObject.FindGameObjectsWithTag("UI");
        foreach (var ui in UIs)
        {
            ui.SetActive(false);
        }
        OnUIClosed.Invoke();
        _camera.GetComponent<CameraMovement>().enabled = true;

        InteractableComponentManager[] interactable = FindObjectsOfType<InteractableComponentManager>();
        foreach (var el in interactable)
        {
            el.enabled = true;
        }
    }

    public void ShowPopUp(string text)
    {
        m_popUp.SetActive(true);
        m_popUpText.text = text;
    }

    public void HidePopUp()
    {
        m_popUp.SetActive(false);
    }
}
