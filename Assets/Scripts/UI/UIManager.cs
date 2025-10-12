using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image m_cursor;
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
        Cursor.lockState = CursorLockMode.None;
        _camera.GetComponent<CameraMovement>().enabled = false;
        m_cursor.enabled = false;
        ui.SetActive(true);
    }

    public void HideUI()
    {
        GameObject[] UIs = GameObject.FindGameObjectsWithTag("UI");
        foreach (var ui in UIs)
        {
            ui.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;
        _camera.GetComponent<CameraMovement>().enabled = true;

        InteractableComponentManager[] interactable = FindObjectsOfType<InteractableComponentManager>();
        foreach (var el in interactable)
        {
            el.enabled = true;
        }

        m_cursor.enabled = true;
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

    public void StartTutorial(string popUpText, InteractableComponentManager popUpTrigger)
    {
        ShowPopUp(popUpText);
        popUpTrigger.ActivateTutorialHint();
    }
}
