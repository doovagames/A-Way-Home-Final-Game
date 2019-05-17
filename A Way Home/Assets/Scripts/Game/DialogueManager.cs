
using System.Collections.Generic;
using Camera;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text _nameText;
    public Text _dialogueText;

    public Animator _animator;

    [SerializeField] private CameraLook _cameraLook;
    [SerializeField] private BoatMovement _boat;
    
    
    private Queue<string> _sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _boat.enabled = false;
        _cameraLook.enabled = false;
        
        _animator.SetBool("IsOpen", true);
        
        Debug.Log("Starting conversation with " + dialogue._name);

        _nameText.text = dialogue._name;
        
        _sentences.Clear();

        foreach (var sentence in dialogue._Sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        _dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        _animator.SetBool("IsOpen", false);
        _boat.enabled = true;
        _cameraLook.enabled = true;
    }
}
