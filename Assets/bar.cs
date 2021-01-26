using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar : MonoBehaviour

{
    Controller cont;
    attack playerPos;
    RectTransform move;
    public Slider slider;
    
    public void Transform(){
        
    }
    public void SetHealth(float a)
    {
        
        slider.value = a;
    }
    // public void RectMove(){
    //     move.anchoredPosition = playerPos.transform.position;
    // }
}
