using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 2f;
    public Dialogue dialogue;
    private bool hasReachedTarget = false;


    void Update()
    {
       if(!hasReachedTarget)
       {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if(Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                hasReachedTarget = true;
                dialogue.StartDialogue();
            }
       }
    }
}
