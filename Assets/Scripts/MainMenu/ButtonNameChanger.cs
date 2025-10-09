using TMPro;
using UnityEngine;
using UnityEngine.UI;

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


    public void Start() {
        gameObject.GetComponent<Button>().onClick.AddListener(() => { sceneChanger.ChangeScene(levelName); });
    }
    
    
}
