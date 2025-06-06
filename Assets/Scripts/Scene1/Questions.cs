using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    public Dialogue dialogueScript;     
    public string[] answers;             

    public void AskQuestion(int index)
    {
        if (index >= 0 && index < answers.Length)
        {
            dialogueScript.StartSingleLine(answers[index]);
        }
    }
}
