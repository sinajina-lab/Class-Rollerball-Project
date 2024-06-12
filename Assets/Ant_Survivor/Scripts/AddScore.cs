using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class AddScore : MonoBehaviour
{
    public int ground = 0;
    public TextMeshProUGUI textGround;

    int sessionNumber; //Variable to store Game Session Number, which updates everytime a new game is played, each dice roll is a session in this case

    //private int score = 0;
    //public Text scoreText;

    // Use this for initialization

    private void Awake()
    {
        //Get session number integer value from key "Session Number", if key not found create key with value = 1
        sessionNumber = PlayerPrefs.GetInt("SessionNumber", 1);

        Debug.Log("Current session number is:" + sessionNumber);
    }

    void Start()
    {
        //score = 0;
        //scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //score = 0;
        //scoreText.text = "0";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Ground")
        {
            ground++;
            textGround.text = ground.ToString();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //score += 1;
            //scoreText.text = "0" + score.ToString();
        }
    }

    public void MyScores()
    {
        //Send the current score to High Score Manager to evaluate and assign it to the leaderboard
        SendScoreToManager(ground, sessionNumber);

        sessionNumber += 1;

        //Update the session number to whatever the current session number is, in the save data
        PlayerPrefs.SetInt("SessionNumber", sessionNumber);
    }
    

    public void SendScoreToManager(int score, int sessionNumber)
    {
       // HighScoreManager.instance.AddNewScore(score, sessionNumber);
    }
}