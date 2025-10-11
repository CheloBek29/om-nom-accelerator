using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_camera;

    public void ShowUI(GameObject ui)
    {
        InteractableComponentManager[] interactable = GameObject.FindObjectsOfType<InteractableComponentManager>();
        foreach (var el in interactable)
        {
            el.enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        m_camera.GetComponent<CameraMovement>().enabled = false;
        ui.SetActive(true);
    }
}
