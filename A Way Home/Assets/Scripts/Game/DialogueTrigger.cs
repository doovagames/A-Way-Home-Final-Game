using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue _dialogue;
    [SerializeField] private DialogueManager _dialogueManager;

    private void Start()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        _dialogueManager.StartDialogue(_dialogue);
    }
    
}
