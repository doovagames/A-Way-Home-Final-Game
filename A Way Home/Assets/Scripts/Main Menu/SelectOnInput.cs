using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour
{
	public EventSystem _eventSystem;
	public GameObject _selectedObject;

	private bool buttonSelected;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	private void Update ()
	{
		if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
		{
			_eventSystem.SetSelectedGameObject(_selectedObject);
			buttonSelected = true;
		}
	}

	private void OnDisable()
	{
		buttonSelected = false;
	}
	
}