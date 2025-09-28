using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private Conversation conversation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueManager.startConversation(conversation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
