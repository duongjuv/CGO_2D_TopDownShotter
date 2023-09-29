using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool ready, start;

    //  Enemy
    [SerializeField] public TextMeshProUGUI textCoint;
    [SerializeField] private GameObject aimMouse, gameOverMenu;
    [SerializeField] private Text   scoreText, maxScoreText;

    public static int score, maxScore;
    //  Player
    //[SerializeField] public static int moveSpeedPlayer, RotationSpeedPlayer, maxHP_Player;
    //[SerializeField] public static int minDamage, maxDamage;
    public static int coint = 0;
    void Start()
    {
        ready = true;
        aimMouse.SetActive(true);
        score = 0;
        //coint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coint = PlayerPrefs.GetInt("Coint");
        /*score = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score: " + score.ToString();
        if(score > PlayerPrefs.GetInt("Score") )
        {
            PlayerPrefs.SetInt("MaxScore", score);
            
        }
        int maxScore = PlayerPrefs.GetInt("MaxScore");
        maxScoreText.text = "Best: " + maxScore.ToString();*/
        textCoint.text = coint.ToString();
    }
    public void LoseGame()
    {
        gameOverMenu.SetActive(true);
    }
}
