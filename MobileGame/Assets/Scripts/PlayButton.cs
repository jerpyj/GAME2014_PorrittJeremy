using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public string game;

    public void LoadLevel()
    {
        SceneManager.LoadScene(game);
    }
}
