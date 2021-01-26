using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    float timeCounter = 2f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter > 1)
        {
            timeCounter -= Time.deltaTime;
            rb.AddForce(new Vector2(0, 1f));
            //transform.position = Vector3.MoveTowards(transform.position,Vector3.Lerp(transform.position,transform.position += new Vector3(0,1f,0),2*Time.deltaTime),2f*Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position,transform.position += new Vector3(0,.5f,0),Time.deltaTime);
        }
        if (timeCounter < 1 || timeCounter == 1)
        {
            timeCounter -= Time.deltaTime;
            rb.AddForce(new Vector2(0, -1f)); ;

        }
        if (timeCounter < 0)
        {
            timeCounter = 2f;
        }
    }







}

