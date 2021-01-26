using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sc : MonoBehaviour
{
        float timeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, -11);
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        transform.position = new Vector3((Mathf.Cos(timeCounter)), (Mathf.Sin(timeCounter)), -11) * 10f;
    }
}
