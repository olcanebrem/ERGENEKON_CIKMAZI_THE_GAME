using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySkull : MonoBehaviour
{
    public float health = 100;
    public float DMG = 20;
    private attack playerPos;
    public Vector3 direction;
    private Rigidbody2D rb;
    private Animator animator;
    private Transform enemyTransform;
    public bool isPlayerTrigger = false;
    SpriteRenderer sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = FindObjectOfType<attack>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        enemyTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        MovePosition();
    }
    void Update()
    {
        if (transform.position.x < playerPos.transform.position.x)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        if (transform.position.x > playerPos.transform.position.x)
        {

            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        direction = (playerPos.transform.position - transform.position);
        direction.Normalize();
        if (isPlayerTrigger == true)
        {
            enemyAttack();
        }
    }
    void MovePosition()
    {
        //rb.MovePosition((Vector2)transform.position+((Vector2)direction * Time.deltaTime*1f));
        rb.AddForce(new Vector2(direction.x, direction.y) * 5f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PROJECTILE")
        {
            slash();
            health -= DMG;


            enemyAttack();
            Destroy(other.gameObject);
            if (health < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                animator.SetBool("death", true);
                StartCoroutine(DESTROY(1));
            }

            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(Wait2(1));
        }
        if (other.tag == "Player")
        {
            animator.SetBool("touch", true);
            isPlayerTrigger = true;
            StartCoroutine(Wait3(1));
        }
    }
    void slash()
    {
        if (true)//baska enemyler gelir ise kosul degisebilir
        {
            rb.AddForce(new Vector2(-direction.x, -direction.y) * 300f);
        }
    }
    void enemyAttack()
    {

        rb.AddForce(new Vector2(-direction.x, -direction.y) * 300f);
        

    }
    IEnumerator DESTROY(int a)
    {
        
        Instantiate(Resources.Load("point") as GameObject ,transform.position,transform.rotation);
        yield return new WaitForSeconds(a);
        Destroy(gameObject);
    }
    IEnumerator Wait2(int a)
    {
        yield return new WaitForSeconds(a);

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    IEnumerator Wait3(int a)
    {
        yield return new WaitForSeconds(a);
        
        animator.SetBool("touch", false);
    }
}
