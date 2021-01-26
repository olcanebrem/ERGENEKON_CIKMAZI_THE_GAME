using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public Controller gamePlayer;
    static public int totalpoint;
    public Text puan;
        void Start()
    {
        gamePlayer = FindObjectOfType<Controller>();
        puan.text = "POINT " + totalpoint;
    }

    
    public void Respawn()
    {
        StartCoroutine ("RespawnCo");
    }
    public IEnumerator RespawnCo(){
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds (respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
    public void Collect(int points){
        totalpoint += points;
        puan.text = "POINT " + totalpoint;
    }
}
