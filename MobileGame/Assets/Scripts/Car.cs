//This file is called Car.cs
//by Jeremy Porritt using 101367286
//

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float speed = 7.0f;

    public AudioClip sound;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

            transform.position = Vector3.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Score.health--;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            if (Score.health == 0){
                if (Score.highScore < Score.score){
                    Score.highScore = Score.score;
                    using (StreamWriter sw = new StreamWriter("highscore.txt")){
                        sw.WriteLine(Score.score);
                    }
                }
                SceneManager.LoadScene("Game Over");
            }
            
        }
        if (collision.gameObject.tag == "Bonus")
        {
            Score.score += 3;
            Destroy(collision.gameObject);
        }
    }
}
