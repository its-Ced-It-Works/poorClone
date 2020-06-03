using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class AIPaddleControllerScript : PaddleBehaviourScript
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
        target.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.insideUnitSphere.x, UnityEngine.Random.insideUnitSphere.y) * 1000f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(8,target.transform.position.y,0);
    }
}
