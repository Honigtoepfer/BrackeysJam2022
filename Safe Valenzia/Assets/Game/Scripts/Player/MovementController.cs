using UnityEngine;

public class MovementController
{
    GameObject obj;
    float speed;
    MainInput input;
    bool canMove = true;
    Animator animator;

    public MovementController(GameObject obj, float speed, MainInput input)
    {
        this.obj = obj;
        this.speed = speed;
        this.input = input;

        this.animator = obj.GetComponentInChildren<Animator>();
        animator.SetFloat("x", 0);
        animator.SetFloat("y", -1);

        NPC.OnStartDialogue += TogglePlayerMovement;
    }

    void TogglePlayerMovement(DialogueConversation obj)
    {
        canMove = !canMove;
    }

    public void Process()
    {
        if (canMove == false) return;

        Vector2 dirToMove = input.Player.move.ReadValue<Vector2>().normalized;

        obj.transform.Translate(dirToMove * Time.deltaTime * speed);

        if (dirToMove.magnitude > 0.3f)
        {
            animator.SetFloat("x", dirToMove.x);
            animator.SetFloat("y", dirToMove.y);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
