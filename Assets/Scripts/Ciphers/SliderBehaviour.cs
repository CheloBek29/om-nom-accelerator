using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Slider slider;

    public void ChangeValue()
    {
        text.text = slider.value.ToString();
    }
}
