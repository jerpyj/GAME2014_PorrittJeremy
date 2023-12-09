//Player.cs created by Jeremy Porritt on December 6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 1f; // Reduced jump force
    public float deadzone = 50.0f;
    private Vector2 startTouchPosition, currentTouchPosition;
    private bool isMoving;

    private bool isOnGround;

    private bool jumpSound;

    public GameObject circlePrefab;
    private GameObject currentCircle;

    public static int score = 0;

    public static float health = 3;
    private float hpTimer = 0;

    public AudioSource jump;
    public AudioSource boing;

    public AudioSource star;

    public AudioSource ouch;

    public TMP_Text scoreText;

    public Image hpBar;

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        hpTimer += Time.deltaTime;
        hpBar.fillAmount = health/3.0f;
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if it's the beginning of a touch
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isMoving = true;
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 7; // Set z to 0 to match the 2D plane
                currentCircle = Instantiate(circlePrefab, touchPosition, Quaternion.identity);
                currentCircle.transform.parent = Camera.main.transform;
            }
            // Check if the touch is moving
            else if (touch.phase == TouchPhase.Moved)
            {
                currentTouchPosition = touch.position;
            }
            // Check if the touch has ended
            else if (touch.phase == TouchPhase.Ended)
            {
                isMoving = false;

                if (currentCircle != null)
                {
                    Destroy(currentCircle);
                }
            }
        }

        // Keyboard controls
        float moveX = Input.GetAxis("Horizontal");

        // Move the player horizontally
        transform.Translate(new Vector3(moveX, 0, 0) * moveSpeed * Time.deltaTime);

        // Make the player jump if the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (isMoving)
        {
            Vector2 offset = currentTouchPosition - startTouchPosition;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

            // Check if the movement is outside the deadzone
            if (offset.magnitude > deadzone)
            {
                // Move the player horizontally
                transform.Translate(new Vector3(direction.x, 0, 0) * moveSpeed * Time.deltaTime);

                if (direction.x > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1); // Facing right
                }
                else if (direction.x < 0)
                {
                    transform.localScale = new Vector3(1, 1, 1); // Facing left
                }

                // Make the player jump if the touch moves upwards
                if (direction.y > 0 && isOnGround)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                }
            }
        }
    }



    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isOnGround = true;
        }

        if (collision.gameObject.tag == "hurt")
        {
            if (hpTimer > 1){
                health--;
                Debug.Log("Hurt");
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce * 1.5f), ForceMode2D.Impulse);
                ouch.Play();
                if (health <= 0){
                    SceneManager.LoadScene("GameOver");
                }
                hpTimer = 0;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "star")
        {
            Destroy(col.gameObject);
            score += 10;
            star.Play();
        }
        if (col.gameObject.tag == "trampoline")
        {
            Debug.Log("Boing");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce * 3.0f), ForceMode2D.Impulse);
            boing.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isOnGround = false;
            jump.Play();
        }
    }

    static public void Reset()
    {
        health = 3.0f;
        score = 0;
    } 
}
