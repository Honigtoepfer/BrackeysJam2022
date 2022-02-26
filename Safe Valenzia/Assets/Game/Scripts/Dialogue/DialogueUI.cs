using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static event Action<DialogueConversation> OnEndDialogue;

    [SerializeField]
    Canvas dialogueCanvas;

    [SerializeField]
    Text dialogueText;

    bool inConversation;
    bool readyForNextLine = true;

    MainInput input;
    int count = 0;
    DialogueConversation conversation;

    void Awake()
    {
        dialogueCanvas.enabled = false;
        dialogueText.text = "";

        input = new MainInput();
    }

    void OnEnable()
    {
        input.Enable();
        NPC.OnStartDialogue += StartDialogue;
    }

    void OnDisable()
    {
        input.Disable();
        NPC.OnStartDialogue -= StartDialogue;
    }

    void StartDialogue(DialogueConversation conversation)
    {
        dialogueCanvas.enabled = true;
        inConversation = true;
        this.conversation = conversation;
        StartCoroutine(ShowNextDialogueBox());
    }

    void Update()
    {
        if (inConversation == true)
        {
            input.Player.interaction.started += ContextMenu => StartCoroutine(ShowNextDialogueBox());
        }
    }

    IEnumerator ShowNextDialogueBox()
    {
        if (readyForNextLine == true)
        {
            if (count < conversation.sentences.Length)
            {
                dialogueText.text = conversation.sentences[count];

                count++;
            }
            else
            {
                dialogueCanvas.enabled = false;
                OnEndDialogue?.Invoke(null);
                count = 0;
            }

            readyForNextLine = false;
        }

        yield return new WaitForSeconds(0.75f);

        readyForNextLine = true;
    }
}
