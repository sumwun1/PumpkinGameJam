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
        // print(this.transform.rotation);
        transform.eulerAngles = zeroVector;
        if (target.GetComponent<Player>().GetState() == 1)
        {
            Debug.Log("DEAD!");
            return;
        }
        // print(this.transform.rotation);
        Vector3 dir = target.position - this.transform.localPosition;;
        //Debug.Log(speed);
        float distThisFrame = speed * Time.deltaTime;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        /*Griefer[] griefers = GameObject.FindObjectsOfType<Griefer>();
        Griefer nearestGriefer = null;

        foreach (Griefer griefer in griefers)
        {
            //float d = Vector3.Distance(this.transform.position, griefer.transform.position);

            if (nearestGriefer == null)
            {
                nearestGriefer = griefer;
            }
        }

        if (nearestGriefer == null)
        {
            return;
        }*/

        if (dir.magnitude <= distThisFrame)
        {
            target.gameObject.GetComponent<Player>().Die();
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            // print("transform.rotation:");
            // print(transform.rotation);
            // print("transform.position:");
            // print(transform.position);
            // print(Quaternion.LookRotation(dir));
            // this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.3f);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // this.transform.rotation = Quaternion.LookRotation(dir);
            // transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0f, 0f);
        }
    }
}
