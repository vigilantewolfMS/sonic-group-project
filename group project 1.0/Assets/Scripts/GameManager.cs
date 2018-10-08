using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text button1;
    public Text button2;
    public Text button3;
    public Text button4;
    public Text Questions;
    private Question currQuestion;
    private Question[] questions;
    // Use this for initialization

    void initializeQuestions()
    {
        questions = new Question[]{
           new Question("What will the result of 50.1 * 2 be?", "100.2", "100", "101", "52.1", "100.2"),
           new Question("Which of the following is a valid declaration and initialization of an integer variable?", "int num = 1;", "int num = 1.0;", "double num = 1;", "num = 1;", "int num = 1;"),
           new Question("True or false; Strings are auto-initialized to null", "True", "False", "True"),
           new Question("If the double 55.6 is casted to an int, what would the resulting integer be?", "55", "56", "55.0", "56.0", "55"),
           new Question("True or false; Strings are defined as an array of characters.", "True", "False", "True"),
           new Question("If a variable in a class is static, how can it be accessed?", "class.variable", "object.variable", "Just by calling the variable.", "It can't, it causes a compiler error because it is incorrect syntax.", "class.variable")
        };
    }

    void Start() {
        initializeQuestions();
        loadNewQuestion();
    }
    // Update is called once per frame

    void loadNewQuestion()
    {
        currQuestion = questions[(int)Random.Range(0, questions.Length)];
        button1.text = currQuestion.getAnswer1();
        button2.text = currQuestion.getAnswer2();
        button3.text = currQuestion.getAnswer3();
        button4.text = currQuestion.getAnswer4();
        Questions.text = currQuestion.getQuestion();
    }
}
