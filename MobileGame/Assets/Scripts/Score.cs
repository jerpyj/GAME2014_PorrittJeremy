using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static public float score = 0;

    static public float health = 3;

    static public float gamePace = 1.0f;

    static public float lineSpawnSpeed = 0.2f;

    static public float carSpawnSpeed = 4.0f;

    static public float highScore = 0;

    static public void Reset()
    {
        score = 0;
        gamePace = 1;
        lineSpawnSpeed = 0.2f;
        carSpawnSpeed = 4.0f;
        health = 3;
    }
}
