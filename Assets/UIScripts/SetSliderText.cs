using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetSliderText : MonoBehaviour
{
    TextMeshProUGUI sliderLabel;

    private void Start()
    {
        sliderLabel = GetComponent<TextMeshProUGUI>();
    }

    public void setText(float value)
    {
        sliderLabel.text = ((int) value).ToString();
    }

}
