using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonTransition : MonoBehaviour, IInteractable
{
    [SerializeField]
    int sceneNumber;

    public void Enter()
    {
        switch(sceneNumber)
        {
            case 1:
                SceneManager.LoadScene("Dungeon 1");
                break;

            case 2:
                SceneManager.LoadScene("Dungeon 2");
                break;

            case 3:
                SceneManager.LoadScene("Dungeon 3");
                break;
        }
    }

    public void Exit()
    {
        
    }

    public void Interact()
    {
        
    }
}
