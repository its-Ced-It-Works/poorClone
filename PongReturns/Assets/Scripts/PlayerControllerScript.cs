using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerScript : MonoBehaviour
{
    public float paddleSpeed = 1f;
    Rigidbody2D paddleBody;

    void Setup()
    {
        paddleBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Control();

    }

    void Control()
    {
        if (Input.GetKey(KeyCode.UpArrow) && this.transform.position.y <= 3.5f)
        {
            //paddleBody.AddForce(new Vector2(0, 1 * paddleSpeed));
            paddleBody.velocity = new Vector2(0, 1) * paddleSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) && this.transform.position.y >= -3.5f)
        {
            //paddleBody.AddForce(new Vector2(0, -1 * paddleSpeed));
            paddleBody.velocity = new Vector2(0, -1) * paddleSpeed * Time.deltaTime;
        }

        else if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {

            paddleBody.velocity = new Vector2(0, 0);

        }
    }
}
