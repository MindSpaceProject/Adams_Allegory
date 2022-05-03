using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
public class NPC : ScriptableObject
{
    public string npcName;
    public string npcName2;
    public string npcName3;
    public string playerName;
    [TextArea(8, 20)]
    public string[] dialogue;
    [TextArea(3, 15)]
    public string[] playerDialogue;
}

