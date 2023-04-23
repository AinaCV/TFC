using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image staminaBar;

    private void Update()
    {
        staminaBar.fillAmount = (float)PlayerController.Instance.stamina / (float)PlayerController.Instance.maxStamina;
    }
}
