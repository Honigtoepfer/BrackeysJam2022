using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public static event System.Action<DialogueConversation> OnStartDialogue;

    [SerializeField]
    DialogueConversation conversation;

    void Start()
    {
        
    }

    public void Interact()
    {
        print("npc interact()");

        OnStartDialogue(conversation);
    }

    public void Enter()
    {
        print("npc enter()");
    }

    public void Exit()
    {
        print("npc exit()");
    }
}
