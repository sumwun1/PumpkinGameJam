using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletItself;
    public Vector3 dir;
    public int bulletSpeed;
    public GameObject Turret;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        //Turret = GameObject.FindGameObject("Turret")
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetState() != 0)
        {
            return;
        }

        float distThisFrame = bulletSpeed * Time.deltaTime;
        transform.Translate(dir.normalized * distThisFrame, Space.World);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision)
        //print("here!");
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Destroy(Turret);
            
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
