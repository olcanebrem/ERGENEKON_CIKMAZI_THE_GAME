using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sr : MonoBehaviour
{
    
    SpriteRenderer spriteRenderer;
    void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        if (UnityEngine.Random.Range(0,5)==2)
        {
        spriteRenderer.flipX = true;
        }else{

                spriteRenderer.flipX = false;
        }
            
            
    }
}
