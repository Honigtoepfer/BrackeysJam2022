using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionOutOfDungeon : MonoBehaviour, IInteractable
{
    
    [SerializeField] private int dungeonIndex = 0;
    

    public void Enter()
    {
        GameVars.current.quests[dungeonIndex] = QuestState.Completed;
        SceneManager.LoadScene("MainScene");
    }

    private void FixedUpdate()
    {
        if(GameVars.current.currentTimer < 0)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void Exit()
    {
        
    }

    public void Interact()
    {
        
    }
}
