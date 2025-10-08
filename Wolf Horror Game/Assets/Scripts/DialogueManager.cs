using System;
using System.Collections;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Conversation currentConversation;
    public float autoplayDelay = 5f;
    public int currentStatementIndex = 0;
    public bool autoplay = true;
    public Statement defaultStatement;


    [SerializeField]
    private GameObject dialoguePanel = null;
    [SerializeField]
    private Image speakerImage = null;
    [SerializeField]
    private TextMeshProUGUI speakerName = null;
    [SerializeField]

    private TextMeshProUGUI speakerMessage = null;
    private Statement currentStatement;
    private float autoplayTimer = 0f;
    private bool speaking = false;


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
    public void enableAutoplay(bool shouldEnable = true)
    {
        if (autoplay == shouldEnable) { return; }
        autoplay = shouldEnable;
        autoplayTimer = 0f;
    }

    void autoplayUpdate()
    {
        if (!speaking || !autoplay) { return; }
        if (autoplayTimer < autoplayDelay) 
        {
            autoplayTimer += Time.deltaTime;
        } else
        {
            autoplayTimer = 0f;
            nextStatement();
        }
    }

    private void Start()
    {
        currentStatement = defaultStatement;
        showStatement();
    }

    private void Update()
    {
        autoplayUpdate();
    }
}
