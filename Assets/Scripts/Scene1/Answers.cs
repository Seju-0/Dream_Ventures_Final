using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    [SerializeField] private List<GameObject> Folder;
    public Dialogue dialogueScript;
    public string[] answers;
    public Client client;

    public void ApproveLoan(int index)
    {
        if (index >= 0 && index < answers.Length)
        {
            dialogueScript.StartSingleLine(answers[index]);

            foreach (GameObject component in Folder)
            {
                component.SetActive(false);
            }

            client.LeaveAfterDialogue();
        }
    }

    public void RejectLoan(int index)
    {
        if (index >= 0 && index < answers.Length)
        {
            dialogueScript.StartSingleLine(answers[index]);

            foreach (GameObject component in Folder)
            {
                component.SetActive(false);
            }

            client.LeaveAfterDialogue();
        }
    }
}