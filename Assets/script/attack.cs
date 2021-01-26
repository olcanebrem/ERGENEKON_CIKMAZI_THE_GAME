using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour // saldirinin ne zaman yapılacagini belirler
{
    public GameObject projectile;
    private Controller gameController;
    public GameObject[] weaponary;
    private GameObject test;
    void Start()
    {
        gameController = FindObjectOfType<Controller>();
    }
    void OnTriggerEnter2D(Collider2D oth) // degdigi itemin adini baz alarak onu projectile yapar
    {
        if (oth.tag == "item")
        {
            
            for (int i = 0; i < weaponary.Length; i++)
            {
                test = GameObject.Find(oth.name);
                
                if (weaponary[i].ToString() == test.ToString())
                {
                     projectile = weaponary[i];
                }
            }
        }
        
    }

  
    void Update()
    {
        
        if (Input.GetKeyDown("space") && projectile != null) // space e basildiginde itemi cogaltir
        {
            if ((gameController.movementx != 0f) || (gameController.movementy != 0f))
            {
                Instantiate(projectile, transform.position, transform.rotation);
            }

        }
    }


}
