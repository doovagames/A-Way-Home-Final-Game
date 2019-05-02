using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour
{
    public void SetQualitySetting(int level)
    {
        QualitySettings.SetQualityLevel(level, true);
    }

    public void SetAntiAliasing(int _amount)
    {
        QualitySettings.antiAliasing = _amount;
    }
}
