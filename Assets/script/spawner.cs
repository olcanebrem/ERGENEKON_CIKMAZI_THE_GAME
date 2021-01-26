using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    float[] rare = new float[2];
    private enemySkull enemy;
    float timeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<enemySkull>();
    }

    // Update is called once per frame
    void Update()
    {
        float rarety = UnityEngine.Random.Range(-5, 5);
        timeCounter += .04f + rarety * Time.deltaTime;
        if (timeCounter < 5)
        {
            rare[0] = rarety;
        }
        if (timeCounter < 8)
        {
            rare[1] = rarety;
        }
        if (timeCounter > 10)
        {

            timeCounter = 0;
            Vector3 a = (transform.position + (new Vector3(rare[0], rare[1], 0)));

            //Vector3 a = new Vector3(transform.position.x+rare[0],transform.position.y,0);
            Instantiate(Resources.Load<GameObject>("heli"), a, transform.rotation);
        }
    }
}
