using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    private float offset = 2f;
    public Vector3 playerPosition;
    public float offsetSmoothness = 2f;
    public float movementx;    
    public float movementy;
    void Start()
    {

    }

    void Update()
    {
         movementx = Input.GetAxis ("Horizontal");
        movementy = Input.GetAxis ("Vertical");
        playerPosition = new Vector3 (player.transform.position.x,player.transform.position.y,player.transform.position.z-10);
        
        if (movementx > 0f)
        {
        playerPosition = new Vector3(player.transform.position.x+offset,player.transform.position.y,transform.position.z-10f);
        }
        else if (movementy > 0f)
        {
        playerPosition = new Vector3(player.transform.position.x,player.transform.position.y+offset,player.transform.position.z-10f);
        }
        else if (movementx < 0f)
        {
        playerPosition = new Vector3(player.transform.position.x-offset,player.transform.position.y,player.transform.position.z-10f);
        }
        else if (movementy < 0f)
        {
        playerPosition = new Vector3(player.transform.position.x,player.transform.position.y-offset,player.transform.position.z-10f);
        }
        
        transform.position = Vector3.Lerp(transform.position,playerPosition,offsetSmoothness*Time.deltaTime);
    }
}
