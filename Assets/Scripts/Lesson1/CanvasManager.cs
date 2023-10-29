using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image HealthbarFill;

    void Start()
    {
        HealthbarFill.fillAmount = 1;
    }

    public void ChangeHealth(float value)
    {
        HealthbarFill.fillAmount = value;
    }
}
