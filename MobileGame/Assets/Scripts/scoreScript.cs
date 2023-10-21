using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public Image slider;
    
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score.score.ToString();
        slider.fillAmount = Score.health/3.0f;
    }
}
