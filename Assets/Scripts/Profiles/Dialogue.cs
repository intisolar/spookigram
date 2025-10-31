using System;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string id; 
    public DialogueLayout layout; 
    public DialogueLine[] lines;
    public string clue;
}
