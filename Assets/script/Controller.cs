
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{
    public float playerHealth = 100;
    public float speed = 10f;
    public float movementx = 0f;
    public float movementy = 0f;
    public LevelManager gameLevelManager;
    Rigidbody2D rb;
    private Animator playerAnimation;
    public Vector3 respawnPoint;
    private bar bar;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        gameLevelManager = FindObjectOfType<LevelManager>();
        bar = FindObjectOfType<bar>();
    }
    void FixedUpdate()
    {

        enemySkull[] enemyTotal = FindObjectsOfType<enemySkull>();
        for (int i = 0; i < enemyTotal.Length; i++)
        {
            if (enemyTotal[i].isPlayerTrigger == true)
            {
                enemyTotal[i].isPlayerTrigger = false;
                {
                    rb.AddForce(new Vector2(enemyTotal[i].direction.x, enemyTotal[i].direction.y) * 500f);
                    playerHealth -= UnityEngine.Random.Range(10, 15);
                    Debug.Log(playerHealth + "*" + enemyTotal[i]);
                }
            }
            if (playerHealth < 0)
            {
                Debug.Log("GAMEOVER");
                SceneManager.LoadScene(2);
            }
        }
    }
    void Update()
    {
        bar.SetHealth(playerHealth);

        movementx = Input.GetAxis("Horizontal");
        movementy = Input.GetAxis("Vertical");
        if (movementx > 0f)
        {
            rb.velocity = new Vector2(movementx * speed, movementy * speed);
            transform.localScale = new Vector2(.50f, transform.localScale.y);
        }
        else if (movementy > 0f)
        {
            rb.velocity = new Vector2(movementx * speed, movementy * speed);
        }
        else if (movementx < 0f)
        {
            rb.velocity = new Vector2(movementx * speed, movementy * speed);
            transform.localScale = new Vector2(-.50f, transform.localScale.y);
        }
        else if (movementy < 0f)
        {
            rb.velocity = new Vector2(movementx * speed, movementy * speed);

        }
        else if (true)
        {
            rb.velocity = new Vector2(0, 0);
        }
        playerAnimation.SetFloat("Speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DMG")
        {
            gameLevelManager.Respawn();
        }
        if (other.tag == "checkPoint")
        {
            respawnPoint = other.transform.position;
        }
    }
    
}
