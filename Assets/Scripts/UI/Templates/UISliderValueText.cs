using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISliderValueText : MonoBehaviour {
    [SerializeField]
    [Tooltip("The text shown will be formatted using this string.  {0} is replaced with the actual value")]
    private string formatText = "{0}°";

    [SerializeField]
    [Tooltip("How many decimal places in the value")]
    private int decimalPlaces = 2;

    private TextMeshProUGUI tmproText;
    private Slider slider;

    private void Start() {
        tmproText = GetComponent<TextMeshProUGUI>();
        slider = GetComponentInParent<Slider>();


        slider.onValueChanged.AddListener(HandleValueChanged);
        HandleValueChanged(slider.value);
        
    }

    private void HandleValueChanged(float value) {
        tmproText.text = string.Format(formatText, value.ToString("n"+ decimalPlaces));
    }
}