using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
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
            //print("up arrow key is held down");
            transform.Translate(up * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("down"))
        {
            //print("down arrow key is held down");
            transform.Translate(down * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("left"))
        {
            transform.Translate(left * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("right"))
        {
            transform.Translate(right * speed * Time.deltaTime, Space.World);
        }
    }
}
