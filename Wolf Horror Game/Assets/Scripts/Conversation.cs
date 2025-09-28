using System;
using UnityEngine;

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
[CreateAssetMenu(fileName = "Conversation", menuName = "Scriptable Objects/Conversation")]
public class Conversation : ScriptableObject
{
    public string title;
    public Statement[] statements;
    public Conversation(string title, Statement[] statements)
    {
        this.title = title;
        this.statements = statements;
    }
    public override string ToString() => $"=== {this.name} ===\n"
        + string.Join("\n", this.statements);
}
