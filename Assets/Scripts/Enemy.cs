using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int speed = 2;
    Vector3 zeroVector;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<Player>().GetComponent<Transform>();
        zeroVector = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = zeroVector;

        if (target.GetComponent<Player>().GetState() == 1)
        {
            //Debug.Log("DEAD!");
            return;
        }
        
        Vector3 dir = target.position - this.transform.localPosition;;
        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            target.gameObject.GetComponent<Player>().Die();
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == target.gameObject)
        {
            target.gameObject.GetComponent<Player>().Die();
        }
    }
}
