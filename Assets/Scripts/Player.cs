using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxVelocity;
    public float acceleration;
    int state;
    private float velocity;
    private float speed;
    Vector3 zeroVector;
    Vector3 up;
    Vector3 down;
    Vector3 left;
    Vector3 right;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        speed = 0;
        zeroVector = new Vector3(0, 0, 0);
        up = new Vector3(0, 1, 0);
        down = new Vector3(0, -1, 0);
        left = new Vector3(-1, 0, 0);
        right = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = zeroVector;

        if (state == 1)
        {
            return;
        }
        
        if (Input.GetKey("right") && Input.GetKey("up"))
        {
            velocity = maxVelocity - 2;
        }
        else if (Input.GetKey("right") && Input.GetKey("down"))
        {
            velocity = maxVelocity - 2;
        }
        else if (Input.GetKey("left") && Input.GetKey("up"))
        {
            velocity = maxVelocity - 2;
        }
        else if (Input.GetKey("left") && Input.GetKey("down"))
        {
            velocity = maxVelocity - 2;
        }
        else
        {
            velocity = maxVelocity;
        }

        if (Input.GetKey("up"))
        {
            if (speed < velocity)
            {
                speed += acceleration;
            }
            if (speed > velocity)
            {
                speed -= acceleration;
            }
            transform.Translate(up * speed * Time.deltaTime, Space.World);
        }
        else if (!Input.GetKey("right") && !Input.GetKey("left") && !Input.GetKey("down"))
        {
            if (speed > 0)
            {
                speed -= acceleration;
            }
        }

        if (Input.GetKey("down"))
        {
            if (speed < velocity)
            {
                speed += acceleration;
            }
            if (speed > velocity)
            {
                speed -= acceleration;
            }
            transform.Translate(down * speed * Time.deltaTime, Space.World);
        }
        else if (!Input.GetKey("left") && !Input.GetKey("right") && !Input.GetKey("up"))
        {
            if (speed > 0)
            {
                speed -= acceleration;
            }
        }
        

        if (Input.GetKey("left"))
        {
            if (speed < velocity)
            {
                speed += acceleration;
            }
            if (speed > velocity)
            {
                speed -= acceleration;
            }
            transform.Translate(left * speed * Time.deltaTime, Space.World);
        }
        else if (!Input.GetKey("right") && !Input.GetKey("up") && !Input.GetKey("down"))
        {
            if (speed > 0)
            {
                speed -= acceleration;
            }
        }

        if (Input.GetKey("right"))
        {
            if (speed < velocity)
            {
                speed += acceleration;
            }
            if (speed > velocity)
            {
                speed -= acceleration;
            }
            transform.Translate(right * speed * Time.deltaTime, Space.World);
        }
        else if (!Input.GetKey("left") && !Input.GetKey("up") && !Input.GetKey("down"))
        {
            if (speed > 0)
            {
                speed -= acceleration;
            }
        }
    }

    public int GetState()
    {
        return (state);
    }

    public void Die()
    {
        state = 1;
    }
}
