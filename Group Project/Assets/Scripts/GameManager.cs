using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Text Questions;
    private bool answered = false;
    private int player;
    private int enemy;
    private float delay;
    public Text playerHealth;
    public Text enemyHealth;
    public Transform Crab;
    public Transform Player;
    private Question currQuestion;
    private Question[] questions;
    private bool isPlayingSound;
    public AudioSource indicator;
    public AudioSource music;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip correct;
    public AudioClip incorrect;
    // Use this for initialization

    void initializeQuestions()
    {
        questions = new Question[]{
           new Question("What will the result of 50.1 * 2 be?", "100", "100.2", "101", "52.1", "100.2"),
           new Question("Which of the following is a valid declaration and initialization of an integer variable?", "int num = 1.0;", "int num;", "double num = 1;", "int num = 1;", "int num = 1;"),
           new Question("True or false; Strings are auto-initialized to null", "True", "False", "True"),
           new Question("If the double 55.6 is casted to an int, what would the resulting integer be?", "56", "55.0", "55", "56.0", "55"),
           new Question("True or false; Strings are defined as an array of ints.", "True", "False", "False"),
           new Question("True or false; boolean values can be written in 0s and 1s.","True","False", "True"),
           new Question("True or false; you can use the % operator on doubles","True","False","False"),
           new Question("What is a valid declaration of a String?","String word = 'cat';","String word = 'c';","String word = new String[3];","String word;","String word;"),
           new Question("Which of the following is a valid declaration and initialization of a boolean?","boolean Yep = \"false\";", "true Yep;","boolean Yep = false;","boolean Yep == false;","boolean Yep = false;"),
           new Question("If a variable in a class is static, how can it be accessed?", "class.variable", "object.variable", "Just by calling the variable.", "It can't, it causes a compiler error because it is incorrect syntax.", "class.variable")
        };
    }

    void Start() {
        initializeQuestions();
        loadNewQuestion();
        player = 60;
        enemy = 100;
        isPlayingSound = false;
        playerHealth.text = "HP: " + player + "/" + 60;
        enemyHealth.text = "Enemy HP:" + enemy + "/" + 100;

            button1.onClick.AddListener(delegate { checkAnswer(button1); });
            button2.onClick.AddListener(delegate { checkAnswer(button2); });
            button3.onClick.AddListener(delegate { checkAnswer(button3); });
            button4.onClick.AddListener(delegate { checkAnswer(button4); });
    }

    void checkAnswer(Button clicked)
    {
        if(answered == false)
        {

            if (clicked.GetComponentInChildren<Text>().text.Equals(currQuestion.getCorrectAnswer()))
            {
                enemy -= 20;
                indicator.clip = correct;
            }

            else
            {
                player -= 20;
                indicator.clip = incorrect;
            }

            indicator.Play();
            answered = true;
            playerHealth.text = "HP: " + player + "/" + 60;
            enemyHealth.text = "Enemy HP:" + enemy + "/" + 100;

			if (enemy <= 0) {
				Questions.text = "You win!";
				button1.onClick.RemoveAllListeners ();
				button2.onClick.RemoveAllListeners ();
				button3.onClick.RemoveAllListeners ();
				button4.onClick.RemoveAllListeners ();
				Vector3 newCrabPos = new Vector3 (0, -200, 0);
				Crab.transform.position = newCrabPos;
				music.clip = win;
				music.Play ();

			} else if (player <= 0) {
				Questions.text = "You lose!";
				button1.onClick.RemoveAllListeners ();
				button2.onClick.RemoveAllListeners ();
				button3.onClick.RemoveAllListeners ();
				button4.onClick.RemoveAllListeners ();
				Vector3 newPlayerPos = new Vector3 (0, -200, 0);
				Player.transform.position = newPlayerPos;
				music.clip = lose;
				music.Play ();
			}
        }
    }

    private void Update()
    {
        
        if (answered == true)
        {
            loadNewQuestion();
            answered = false;
        }
    }


    void loadNewQuestion()
    {
        currQuestion = questions[(int)Random.Range(0, questions.Length)];
        button1.GetComponentInChildren<Text>().text = currQuestion.getAnswer1();
        button2.GetComponentInChildren<Text>().text = currQuestion.getAnswer2();
        button3.GetComponentInChildren<Text>().text = currQuestion.getAnswer3();
        button4.GetComponentInChildren<Text>().text = currQuestion.getAnswer4();
        Questions.text = currQuestion.getQuestion();
    }
}
