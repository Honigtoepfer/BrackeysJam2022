using UnityEngine;

public class Interactions
{
    GameObject obj;
    MainInput input;

    IInteractable interactable;

    public Interactions(GameObject obj, MainInput input)
    {
        this.obj = obj;
        this.input = input;
    }

    public void CollisionEnter(Collider2D collider)
    {
        interactable = collider.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactable.Enter();
        }
    }

    public void CollisionExit(Collider2D collider)
    {
        interactable = collider.GetComponent<IInteractable>();

        if (interactable != null)
        {
             interactable.Exit();
             interactable = null;
        }
    }

    public void Process()
    {
        if (interactable != null)
        {
            input.Player.interaction.started += ContextMenu => Interaction();
        }
    }

    void Interaction()
    {
        if (interactable != null)
        {
            interactable.Interact();
            interactable = null;
        }
    }
}
