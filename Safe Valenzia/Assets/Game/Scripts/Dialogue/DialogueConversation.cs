using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue Conversation")]
public class DialogueConversation : ScriptableObject
{
    public new string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
