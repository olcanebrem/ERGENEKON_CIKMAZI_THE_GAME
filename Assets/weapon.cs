using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    private SpriteRenderer sR;
    public Sprite[] a = new Sprite[6];// random collectibles
    // Start is called before the first frame update
    void Start()
    {
        int b = UnityEngine.Random.Range(0,6); 
        sR= GetComponent<SpriteRenderer>();
        sR.sprite = a[b];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
