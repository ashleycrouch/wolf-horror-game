using System;
using UnityEngine;

[Serializable]
public struct Statement
{
    public Speaker speaker;
    [TextAreaAttribute]
    public string message;
    public Statement(Speaker speaker, string message)
    {
        this.speaker = speaker;
        this.message = message;
    }
    public override string ToString() => $"{this.speaker}: {this.message}";
}

[Serializable]
[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue/Conversation")]
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
