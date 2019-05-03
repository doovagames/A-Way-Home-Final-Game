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
}

