using System.IO;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float i;
    private Rigidbody2D rb;
    private float yaxis;
    private Controller gameSpeed;
    private float xaxis;
    
    [SerializeField]
    private GameObject projectile;

     void Update()
    {
        ++i;
        rb.SetRotation(i);

    }
    void Start()
    {
        
        gameObject.tag = "PROJECTILE";
        i = UnityEngine.Random.Range(0f, 360f);
        gameSpeed = FindObjectOfType<Controller>();
        rb = GetComponent<Rigidbody2D>();

        if (gameSpeed.movementx < -0.01f)
        {
            xaxis = -20f;
        }
        if (gameSpeed.movementy < -0.01f)
        {
            yaxis = -20f;
           
        }
        if (gameSpeed.movementx > 0.01f)
        {
            xaxis = 20f;
        }
        if (gameSpeed.movementy > 0.01f)
        {
            yaxis = 20f;
        }
        rb.velocity = new Vector2(gameSpeed.movementx + xaxis, gameSpeed.movementy + yaxis);
        StartCoroutine(Wait());
         
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }



}
