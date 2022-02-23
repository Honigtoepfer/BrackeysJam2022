using UnityEngine;

public class MovementController
{
    GameObject obj;
    float speed;
    MainInput input;

    public MovementController(GameObject obj, float speed, MainInput input)
    {
        this.obj = obj;
        this.speed = speed;
        this.input = input;
    }

    public void Process()
    {
        Vector2 dirToMove = input.Player.move.ReadValue<Vector2>().normalized;

        obj.transform.Translate(dirToMove * Time.deltaTime * speed);
    }
}
