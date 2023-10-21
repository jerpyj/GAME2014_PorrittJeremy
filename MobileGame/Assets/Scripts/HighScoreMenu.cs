using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using TMPro;

public class HighScoreMenu : MonoBehaviour
{

    public TMP_Text scoreText;

    void Start()
    {
        using (StreamReader sr = new StreamReader("highscore.txt"))
        {
            Score.highScore = float.Parse(sr.ReadLine());
        }
        
        scoreText.text = "High Score: " + Score.highScore.ToString();
    }

}
