using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer checkPointSpriteRenderer;
    public bool checkPointReach;

    // Start is called before the first frame update
    void Start()
    {
        checkPointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkPointSpriteRenderer.sprite = greenFlag;
            checkPointReach = true;
        }   
    }
}
