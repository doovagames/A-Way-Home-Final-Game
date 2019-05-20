using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Camera;

public class Dialogue : MonoBehaviour
{

    [SerializeField] private Text _textDisplay;
    [SerializeField] private int _index;
    [SerializeField] private float _typingSpeed;

    [SerializeField] private GameObject _continueButton;
    [SerializeField] private Animator _textDisplayAnimator;

    private AudioSource _continueClick;

    [SerializeField] private BoatMovement _boat;
    [SerializeField] private CameraLook _camera;
    
    [TextArea(3, 10)]
     public string[] _Sentences;

     private void Start()
     {
         _continueClick = GetComponent<AudioSource>();
         StartCoroutine(Type());
         _boat.enabled = false;
         _camera.enabled = false;
         Cursor.visible = true;
     }

     private void Update()
     {
         if (_textDisplay.text == _Sentences[_index])
         {
             _continueButton.SetActive(true);
         }
     }

     IEnumerator Type()
     {
         foreach (var letter in _Sentences[_index].ToCharArray())
         {
             _textDisplay.text += letter;
             yield return new WaitForSeconds(_typingSpeed);
         }
     }

     public void NextSentence()
     {
         _continueClick.Play();
         _textDisplayAnimator.SetTrigger("Change");
         _continueButton.SetActive(false);
         
         if (_index < _Sentences.Length - 1)
         {
             _index++;
             _textDisplay.text = "";
             StartCoroutine(Type());
         }
         else
         {
             _textDisplay.text = "";
             _continueButton.SetActive(false);
         }
     }
}
