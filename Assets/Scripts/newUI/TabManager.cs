using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] private GameObject _contentTable;

    public GameObject GetContentTable() {return _contentTable;}
}
