using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Events;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;

    [SerializeField] private List<AnswerUI> answerUIs = new List<AnswerUI>();

    public UnityEvent OnQuizEndedWrongAnswer = new UnityEvent();
    public UnityEvent OnQuizEndedRightAnswer = new UnityEvent();

    private Question _currentQuestion;

    private void Start()
    {
        foreach (var answerUI in answerUIs)
        {
            answerUI.onAnswer += OnAnswer;
        }
    }

    private void OnAnswer(string answerID)
    {
        var answeredCorrectly = false;
        if (answerID == _currentQuestion.correct_answer_id)
        {
            answeredCorrectly = true;
            OnQuizEndedRightAnswer?.Invoke();
        }
        else
        {
            OnQuizEndedWrongAnswer?.Invoke();
        }
        EduanaManager.Instance.StartCoroutine(EduanaManager.Instance.SendKeywordProgress(answeredCorrectly));
    }

    private void OnEnable()
    {
        _currentQuestion = EduanaManager.Instance.GetNextKeywordQuestion();
        SetUpUI();
    }

    private void SetUpUI()
    {
        questionText.text = _currentQuestion.text;
        var tempList = new List<AnswerUI>();

        foreach (var answerUI in answerUIs)
        {
            tempList.Add(answerUI);
        }

        for (int i = 1; i <= _currentQuestion.answers.Count; i++)
        {
            _currentQuestion.answers.TryGetValue(i.ToString(), out var answer);

            var randomAnswerUI = tempList[Random.Range(0, tempList.Count - 1)];

            tempList.Remove(randomAnswerUI);

            randomAnswerUI.SetUpText(answer.text, i.ToString());
        }
    }

    void OnDisable()
    {
        foreach (var answerUI in answerUIs)
        {
            answerUI.ResetText();
        }
    }
}
