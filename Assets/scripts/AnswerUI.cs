using UnityEngine;
using TMPro;
using System;

public class AnswerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;
    public bool hasText { get; private set; }
    private string answerID;
    public Action<string> onAnswer;

    public void SetUpText(string text, string answerID)
    {
        this.answerID = answerID;
        answerText.text = text;
        hasText = true;
    }

    public void ResetText()
    {
        hasText = false;
        answerText.text = "";
    }

    public void OnClickAnswer()
    {
        onAnswer?.Invoke(answerID);
    }
}
