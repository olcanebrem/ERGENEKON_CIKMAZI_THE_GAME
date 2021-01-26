using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private LevelManager gameLevelManager;
    private Controller plah;
    public float heal = 2f;
    public int deger;
    // Start is called before the first frame update
    void Start()
    {
        plah = FindObjectOfType<Controller>();
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            if (plah.playerHealth < 100f)
            {
            plah.playerHealth += heal;
            }
                
            gameLevelManager.Collect(deger);
            Destroy(gameObject);
        }
    }
    


}   

