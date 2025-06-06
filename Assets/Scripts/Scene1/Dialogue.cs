using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject Dialogue_Panel;
    public TextMeshProUGUI Dialogue_Text;
    public string[] DialogueLines;
    public float typeSpeed = 0.02f;

    private int currentLineIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f;

    void Update()
    {
        if (Dialogue_Panel.activeSelf && Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickThreshold)
            {
                // Double click: close dialogue immediately
                Dialogue_Panel.SetActive(false);
                Dialogue_Text.text = "";
                isTyping = false;

                if (typingCoroutine != null)
                    StopCoroutine(typingCoroutine);

                return;
            }

            lastClickTime = Time.time;

            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                Dialogue_Text.text = DialogueLines[currentLineIndex];
                isTyping = false;
            }
            else
            {
                currentLineIndex++;
                if (currentLineIndex < DialogueLines.Length)
                {
                    typingCoroutine = StartCoroutine(TypeLine(DialogueLines[currentLineIndex]));
                }
                else
                {
                    Dialogue_Panel.SetActive(false);
                }
            }
        }
    }

    public void StartDialogue()
    {
        Dialogue_Panel.SetActive(true);
        currentLineIndex = 0;
        typingCoroutine = StartCoroutine(TypeLine(DialogueLines[currentLineIndex]));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        Dialogue_Text.text = "";

        foreach (char c in line)
        {
            Dialogue_Text.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
    }
    public void StartSingleLine(string line)
    {
        Dialogue_Panel.SetActive(true);
        currentLineIndex = 0;
        DialogueLines = new string[] { line }; 
        typingCoroutine = StartCoroutine(TypeLine(DialogueLines[0]));
    }
}
