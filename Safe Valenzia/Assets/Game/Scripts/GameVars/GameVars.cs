using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVars
{
    
    public static GameVars current = new GameVars();

    public QuestState[] quests = {QuestState.Open, QuestState.Open, QuestState.Open};

    public float currentTimer = 10f;

}

[System.Serializable]
public enum QuestState
{
    Open,
    Taken,
    Completed
}