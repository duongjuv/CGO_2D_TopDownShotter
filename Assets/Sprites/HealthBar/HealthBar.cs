using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    
    public Image fillBar;
    public TextMeshProUGUI valueHealthText;

    public void UpdateBar(int currentValue, int maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
        valueHealthText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
}
