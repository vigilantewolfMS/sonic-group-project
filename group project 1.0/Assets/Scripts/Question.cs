using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    private string question;
    private string answer1;
    private string answer2;
    private string answer3;
    private string answer4;
    private string correctAnswer;

    public Question(string _question, string _answer1, string _answer2, string _correctAnswer)
    {
        question = _question;
        answer1 = _answer1;
        answer2 = _answer2;
        answer3 = "";
        answer4 = "";
        correctAnswer = _correctAnswer;
    }

    public Question(string _question, string _answer1, string _answer2, string _answer3, string _answer4, string _correctAnswer)
    {
        question = _question;
        answer1 = _answer1;
        answer2 = _answer2;
        answer3 = _answer3;
        answer4 = _answer4;
        correctAnswer = _correctAnswer;
    }

    public string getQuestion()
    {
        return question;
    }

    public string getAnswer1()
    {
        return answer1;
    }

    public string getAnswer2()
    {
        return answer2;
    }

    public string getAnswer3()
    {
        return answer3;
    }

    public string getAnswer4()
    {
        return answer4;
    }

    public string getCorrectAnswer()
    {
        return correctAnswer;
    }
}