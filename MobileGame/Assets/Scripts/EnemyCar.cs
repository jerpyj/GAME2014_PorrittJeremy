using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{

    public float speed = 5.0f;

    public bool isPolice = false;

    public AudioClip sound;

    void Start()
    {
        
    }

    void Update()
    {
        if (!isPolice)
            transform.position = new Vector3(transform.position.x, transform.position.y + -speed * Time.deltaTime * Score.gamePace, transform.position.z );
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime * Score.gamePace, transform.position.z );
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }

}
