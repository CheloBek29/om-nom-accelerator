using TMPro;
using UnityEngine;

public class ButtonNameChanger : MonoBehaviour
{
    [SerializeField] private string levelName = "ExampleLevel";
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private TMP_Text textSprite;

    [ContextMenu("Применить")]
    public void ApllyName()
    {
        textSprite.text = levelName;
        gameObject.name = levelName;
    }

    public void OnClick()
    {
        sceneChanger.ChangeScene(levelName);
    }
}
