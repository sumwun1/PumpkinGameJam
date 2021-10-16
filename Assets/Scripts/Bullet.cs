using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletItself;
    public Vector3 dir;
    public int bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distThisFrame = bulletSpeed * Time.deltaTime;
        transform.Translate(dir.normalized * distThisFrame, Space.World);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision)
        print("here!");
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Bullet")
        {

        }
        else
        {
            // print("here!");
            Destroy(this.gameObject);
        }
    }
}