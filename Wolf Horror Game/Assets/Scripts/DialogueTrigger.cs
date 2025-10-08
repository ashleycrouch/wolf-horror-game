using System.Diagnostics;
using UnityEditor.Build;
using UnityEngine;

public enum TriggerType
{
    None,
    Automatic,
    Collision,
    Interact
}

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Conversation conversation;
    
    [SerializeField]
    private TriggerType triggerType;
    [SerializeField]
    private Collider2D trigger;

    public void triggerConversation()
    {
        bool missingConversation = conversation == null;
        if (missingConversation) { return; }
        dialogueManager.startConversation(conversation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isCollision = triggerType == TriggerType.Collision;
        bool isCollidingWithPlayer = collision.gameObject.tag == "Player";
        if(isCollision && isCollidingWithPlayer) { triggerConversation(); }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(triggerType == TriggerType.Automatic) { triggerConversation(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
