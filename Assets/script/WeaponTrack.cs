using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrack : MonoBehaviour
{
    private attack attacj;
    public Sprite gameObjectSprite;
    private Rigidbody2D rb;
    private float i = 0;
    private float timeCounter=0;
    private attack playerPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = FindObjectOfType<attack>();
        attacj = FindObjectOfType<attack>();
        
    }

    void Update()
    {
        if (attacj.projectile.gameObject != null)
        {
            SpriteRenderer projectileRenderer = attacj.projectile.gameObject.GetComponent<SpriteRenderer>();
            gameObject.GetComponent<SpriteRenderer>().sprite = projectileRenderer.sprite;
            //Vector3 a = new Vector3(1.5f,1.5f,0);
            Vector3 b = playerPos.gameObject.transform.position;
        
            timeCounter+=Time.deltaTime;
            float x = Mathf.Cos(timeCounter);
            float y = Mathf.Sin(timeCounter);
            Vector3 a = new Vector3(x,y,0)*2;
            transform.position = Vector3.Lerp(transform.position, a+b, Time.deltaTime * 3f);
        
        }

        
        ++i;
        rb.SetRotation(i);
    }

}
