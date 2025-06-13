using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Client : MonoBehaviour
{
    public Transform targetPoint;
    public Transform exitPoint;
    public float enterSpeed;
    public float exitSpeed;
    public Dialogue dialogue;
    public string nextSceneName; 

    private bool hasReachedTarget = false;
    private bool isLeaving = false;

    void Update()
    {
        if (!hasReachedTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, enterSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
            {
                hasReachedTarget = true;
                dialogue.StartDialogue();
            }
        }
        else if (isLeaving)
        {
            transform.position = Vector3.MoveTowards(transform.position, exitPoint.position, exitSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, exitPoint.position) < 0.01f)
            {
                isLeaving = false;

                if (!string.IsNullOrEmpty(nextSceneName))
                {
                    SceneManager.LoadScene(nextSceneName);
                }
            }
        }
    }

    public void LeaveAfterDialogue()
    {
        dialogue.OnDialogueComplete += StartLeaving;
    }

    private void StartLeaving()
    {
        isLeaving = true;
        dialogue.OnDialogueComplete -= StartLeaving;
    }
}
