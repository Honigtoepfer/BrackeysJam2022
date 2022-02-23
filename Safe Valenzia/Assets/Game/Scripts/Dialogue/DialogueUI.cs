using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    Canvas dialogueCanvas;

    [SerializeField]
    Text dialogueText;

    void Start()
    {
        dialogueCanvas.enabled = false;
        dialogueText.text = "";
    }

    void OnEnable()
    {
        NPC.OnStartDialogue += StartDialogue;
    }

    void OnDisable()
    {
        NPC.OnStartDialogue -= StartDialogue;
    }

    void StartDialogue(DialogueConversation conversation)
    {
        dialogueCanvas.enabled = true;
        dialogueText.text = conversation.sentences[0];
    }
}
