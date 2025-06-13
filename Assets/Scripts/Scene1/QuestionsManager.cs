using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    [System.Serializable]
    public class QA
    {
        public string question;
        public string answer;
    }

    [Header("Dialogue Reference")]
    public Dialogue dialogueScript;

    [Header("Questions and Answers")]
    public QA[] questionList;
}
