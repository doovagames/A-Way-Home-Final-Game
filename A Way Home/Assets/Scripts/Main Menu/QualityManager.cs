using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour
{
    List<string> names = new List<string>() { "Fastest", "Fast", "Simple", "Good", "Beautiful", "Fantastic"};
    
    public Dropdown _dropdown;
    public Text _selectedName;

    // Start is called before the first frame update
    private void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        _dropdown.AddOptions(names);
    }

    public void SetQualitySetting(int level)
    {
        QualitySettings.SetQualityLevel(level, true);
    }
}
