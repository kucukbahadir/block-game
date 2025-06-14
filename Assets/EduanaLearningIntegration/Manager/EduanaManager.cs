using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System;
using System.Collections;
using NUnit.Framework.Internal;

public class EduanaManager : MonoBehaviour
{
    public static EduanaManager Instance;

    [SerializeField] private int minimumKeywordAmountBeforeFetching = 2;
    [SerializeField] private ApiURLContainer apiURLContainer;
    [SerializeField] private bool useLocalJSON;
    [SerializeField] private TextAsset localJSONFile;
    [SerializeField] private List<Keyword> keywords = new List<Keyword>();
    [SerializeField] private bool autoFetch = true;
    [SerializeField] private bool showKeywordList;

    private Keyword _currentKeyword;
    private int _currentQuestionIndex;
    private string _currentStudentId;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        TotalReset();

        StartCoroutine(FetchKeywords());
        SetUpCurrentKeywordInfo();
    }

    [ExecuteAlways]
    public IEnumerator FetchKeywords()
    {
        if (useLocalJSON)
        {
            var keywordsContainer = DeconstructJson(localJSONFile.text);

            SetKeywordsInKeywordList(keywordsContainer);
        }
        else
        {
            var request = UnityWebRequest.Get($"localhost:3000/api/students/{_currentStudentId}/next-keywords");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var jsonText = request.downloadHandler.text;
                print("Request handled successfully ");

                var keywordsContainer = DeconstructJson(jsonText);

                SetKeywordsInKeywordList(keywordsContainer);
            }
            else
            {
                Debug.LogError("Failed to get keywords. Request result: " + request.result + " response code: " + request.responseCode);
            }
        }

    }

    public IEnumerator SendKeywordProgress(bool answerResult)
    {
        print(answerResult);
        var keywordsClass = new KeywordProgress(_currentKeyword.id, answerResult, DateTime.Now.ToString());

        var json = JsonUtility.ToJson(keywordsClass);
        var bytes = System.Text.Encoding.UTF8.GetBytes(json);

        var request = new UnityWebRequest("", "PUT");


        request.uploadHandler = new UploadHandlerRaw(bytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to send progress. Request result: " + request.result);
        }
    }

    private KeywordsContainer DeconstructJson(string JsonString)
    {
        return JsonConvert.DeserializeObject<KeywordsContainer>(JsonString);
    }

    public void GiveStudentId(string studentId)
    {
        _currentStudentId = studentId;
    }

    public Question GetNextKeywordQuestion()
    {
        if (_currentQuestionIndex >= _currentKeyword.questions.Length)
        {
            var nextKeyword = GetNextKeyword();
            _currentKeyword = nextKeyword;
            _currentQuestionIndex = 0;
        }

        if (_currentKeyword == null)
        {
            Debug.LogError("There are no keywords in the keywords list anymore, so there is no question left");
            return null;
        }

        var nextQuestion = _currentKeyword.questions[_currentQuestionIndex];
        _currentQuestionIndex++;
        return nextQuestion;
    }

    private Keyword GetNextKeyword()
    {
        keywords.Remove(_currentKeyword);

        if (autoFetch && keywords.Count <= minimumKeywordAmountBeforeFetching)
        {
            StartCoroutine(FetchKeywords());
        }

        return keywords.Count <= 0 ? null : keywords[0];
    }

    private void SetKeywordsInKeywordList(KeywordsContainer keywordsContainer)
    {
        foreach (var keyword in keywordsContainer.keywords)
        {
            if (CheckIfKeywordIsInList(keyword)) continue;
            keywords.Add(keyword);
        }
    }

    private void SetUpCurrentKeywordInfo()
    {
        if (_currentKeyword != null && keywords.Count <= 0) return;

        _currentKeyword = keywords[0];
        _currentQuestionIndex = 0;
    }

    public void TotalReset()
    {
        _currentKeyword = null;
        _currentQuestionIndex = 0;

        keywords.Clear();
    }

    private bool CheckIfKeywordIsInList(Keyword target)
    {
        var isInList = false;

        foreach (var keyword in keywords)
        {
            if (keyword.id == target.id) isInList = true;
        }

        return isInList;
    }
}
