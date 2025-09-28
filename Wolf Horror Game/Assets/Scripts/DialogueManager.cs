using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum Wolf
{
    Alpha,
    Beta
}

[Serializable]
public struct Statement
{
    public Wolf speaker;
    [TextAreaAttribute]
    public string message;
    public Statement(Wolf speaker, string message)
    {
        this.speaker = speaker;
        this.message = message;
    }
    public override string ToString() => $"{this.speaker}: {this.message}";
}

[Serializable]
public struct Conversation
{
    public string title;
    public Statement[] statements;
    public Conversation(string title, Statement[] statements)
    {
        this.title = title;
        this.statements = statements;
    }
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset conversationsJSON;
    [SerializeField]
    private GameObject dialoguePanel = null;
    [SerializeField]
    private Conversation conversation;

    Conversation getConversationsFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Conversation>(jsonString);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        conversation = getConversationsFromJSON(conversationsJSON.text);
        Debug.Log(conversation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
