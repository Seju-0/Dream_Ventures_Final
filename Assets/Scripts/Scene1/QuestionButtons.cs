using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButtons : MonoBehaviour
{
    public int questionIndex;
    public QuestionsManager questionsManager;

    private Button button;
    private TextMeshProUGUI buttonText;

    void Start()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        if (questionsManager != null && questionIndex < questionsManager.questionList.Length)
        {
            buttonText.text = questionsManager.questionList[questionIndex].question;

            button.onClick.AddListener(() =>
            {
                string answer = questionsManager.questionList[questionIndex].answer;
                questionsManager.dialogueScript.StartSingleLine(answer);
            });
        }
    }
}