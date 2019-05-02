using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour
{
    public bool SetQualitySetting(int level)
    {
        QualitySettings.SetQualityLevel(level, true);

        if (SetQualitySetting(0))
        {
            QualitySettings.vSyncCount = 0;
        }

        if (SetQualitySetting(1))
        {
            QualitySettings.vSyncCount = 0;
        }

        if (SetQualitySetting(2))
        {
            QualitySettings.vSyncCount = 1;
        }

        if (SetQualitySetting(3))
        {
            QualitySettings.vSyncCount = 2;
        }

        if (SetQualitySetting(4))
        {
            QualitySettings.vSyncCount = 3;
        }

        if (SetQualitySetting(5))
        {
            QualitySettings.vSyncCount = 4;
        }

        return false;
    }
}

