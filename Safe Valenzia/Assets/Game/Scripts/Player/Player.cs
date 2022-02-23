using UnityEngine;

public class Player : MonoBehaviour
{
    MainInput mainInput;
    MovementController controller;
    Interactions interactions;

    [SerializeField]
    float speed;
    
    void Awake()
    {
        mainInput = new MainInput();
        controller = new MovementController(this.gameObject, speed, mainInput);
        interactions = new Interactions(this.gameObject, mainInput);
    }

    void OnEnable()
    {
        mainInput.Enable();
    }

    void OnDisable()
    {
        mainInput.Disable();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        interactions.CollisionEnter(collision);    
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactions.CollisionExit(collision);
    }

    void Update()
    {
        controller.Process();
        interactions.Process();
    }
}
