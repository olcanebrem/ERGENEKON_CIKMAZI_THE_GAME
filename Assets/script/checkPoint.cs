using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private SpriteRenderer checkPointRenderer;
    public bool checkPointReached;
    private Animator animator;
    public Sprite red;
    // Start is called before the first frame update
    void Start()
    {
        checkPointRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkPointReached = true;
            animator.enabled=false;
            checkPointRenderer.sprite = red;
        }

    }
}