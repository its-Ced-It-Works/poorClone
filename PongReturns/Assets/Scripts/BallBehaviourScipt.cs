using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BallBehaviourScipt : MonoBehaviour
{
    public float Power = 100f;
    Rigidbody2D body;
    CircleCollider2D col;
    Vector3 ZeroOut = new Vector3(0, 0, 0);
    public float YSPeed;
    public float XSpeed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        transform.position = ZeroOut; // zero out to start
        body.AddForce(
            new Vector2(
                UnityEngine.Random.Range(-1.5f, 1.5f)
                , UnityEngine.Random.Range(-1.5f, 0f)
                ) * 1000f
            );
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpeed();
        YSPeed = body.velocity.y;
        XSpeed = body.velocity.x;
    }

    void CheckSpeed()
    {
        if (body.velocity.x > 25)
        {
            body.velocity = new Vector2(25f, body.velocity.y);
        }
        if (body.velocity.x < -25)
        {
            body.velocity = new Vector2(-25f, body.velocity.y);
        }
        if (body.velocity.y > 25)
        {
            body.velocity = new Vector2(body.velocity.x, 25f);
        }
        if (body.velocity.y < -25)
        {
            body.velocity = new Vector2(body.velocity.x, -25f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BoxCollider2D>() != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                body.AddForce(
                    new Vector2(
                        UnityEngine.Random.Range(0f, 1.5f),
                        UnityEngine.Random.Range(-1.5f, 1.5f)
                        ) * Power
                    );
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                body.AddForce(
                    new Vector2(
                        UnityEngine.Random.Range(-1.5f, 0f),
                        UnityEngine.Random.Range(-1.5f, 1.5f)
                        ) * Power
                    );
            }
            else if (other.gameObject.CompareTag("TopWall"))
            {
                body.velocity += new Vector2(2.1f * body.velocity.x, -1.5f * body.velocity.y) * Time.deltaTime * Power;
            }
            else if (other.gameObject.CompareTag("BottomWall"))
            {
                body.velocity += new Vector2(2.1f * body.velocity.x, 1.5f * body.velocity.y) * Time.deltaTime * Power;
            }
        }
    }
}
