using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class AIPaddleControllerScript : MonoBehaviour
{
    Rigidbody2D body;
    GameObject target;

    BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Ball");        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(8,target.transform.position.y,0);
    }
}
