using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviourScript : MonoBehaviour
{
    public float Speed = 1000f;
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) * Speed);
        }
    }
}
