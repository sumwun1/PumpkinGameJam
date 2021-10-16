using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxVelocity;
    public float acceleration;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 up = new Vector3(0, 1);
        Vector3 down = new Vector3(0, -1);
        Vector3 left = new Vector3(-1, 0);
        Vector3 right = new Vector3(1, 0);

        if (Input.GetKey("up"))
        {
            if (speed < maxVelocity)
            {
                speed += acceleration;
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
            if (speed < maxVelocity)
            {
                speed += acceleration;
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
            if (speed < maxVelocity)
            {
                speed += acceleration;
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
            if (speed < maxVelocity)
            {
                speed += acceleration;
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
}
