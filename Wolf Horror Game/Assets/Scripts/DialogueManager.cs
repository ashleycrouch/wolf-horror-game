using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset conversationsJSON;
    [SerializeField]
    private GameObject dialoguePanel = null;
    [SerializeField]
    private Image speakerImage = null;
    [SerializeField]
    private TextMeshProUGUI speakerName = null;
    [SerializeField]
    private TextMeshProUGUI speakerMessage = null;
    public Conversation currentConversation;
    public int currentStatementIndex;
    public Statement defaultStatement;
    private Statement currentStatement;
    private bool speaking=false;

    public void startConversation(Conversation conversation)
    {
        Debug.Log("Starting conversation:\n" + conversation.title);
        currentConversation = conversation;
        speaking=true;
        setStatement(0);
        showStatement();
    }

    public void endConversation()
    {
        Debug.Log("Ending conversation:\n" + currentConversation.title);
        currentConversation = null;
        currentStatementIndex = 0;
        currentStatement = defaultStatement;
        speaking = false;
        showStatement();
    }

    void setStatement(int index)
    {
        currentStatementIndex = index;
        currentStatement = currentConversation.statements[index];
    }

    void showStatement()
    {
        dialoguePanel.gameObject.SetActive(speaking);
        speakerImage.sprite = currentStatement.speaker.headshot;
        speakerName.text = currentStatement.speaker.nickname;
        speakerMessage.text = currentStatement.message;
    }

    public void nextStatement()
    {
        if (!speaking) { return; }
        int nextIndex = currentStatementIndex + 1;
        if (nextIndex >= currentConversation.statements.Length) {
            endConversation();
        } else {
            setStatement(nextIndex);
            showStatement();
        }
    }
}
