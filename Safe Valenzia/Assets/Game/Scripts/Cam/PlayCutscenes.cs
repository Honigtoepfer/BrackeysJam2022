using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutscenes : MonoBehaviour
{
    
    [SerializeField] private Animator anim;
    private bool once = false;

    private void Start()
    {
        if(once)
            return;
        
        QuestState[] quests = GameVars.current.quests;
        bool win = true;
        for(int i = 0; i < quests.Length; i++)
        {
            if(quests[i] != QuestState.Completed)
            {
                win = false;
                break;
            }
        }

        if(win)
        {
            anim.SetTrigger("goddess");
        }
    }

    private void FixedUpdate()
    {
        if(GameVars.current.currentTimer < 0 && !once)
        {
            anim.SetTrigger("flood");
        }
    }

}
