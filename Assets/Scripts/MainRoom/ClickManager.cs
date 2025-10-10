using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [Tooltip("Для того, чтобы настроить объекты, ведущие на другие сцены, добавьте по элементу в списки Choose Scene Game Objects и Choose Scene Names, объект, по нажатию которого перемещать - в первый, а название сцены, куда перемещать - во второй.")]
    [SerializeField] private List<GameObject> m_chooseSceneGameObjects;
    [SerializeField] private List<string> m_chooseSceneNames;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject.transform.parent.gameObject;
                if (m_chooseSceneGameObjects.Contains(hitObject))
                {
                    int sceneId = m_chooseSceneGameObjects.IndexOf(hitObject);
                    gameObject.GetComponent<SceneChanger>().ChangeScene(m_chooseSceneNames[sceneId]);
                }
            }
        }
    }
}
