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

        if(target.GetComponent<Player>().GetState() == 1)
        {
            return;
        }

        Vector3 dir = target.position - this.transform.localPosition;
        //Debug.Log(speed);
        float distThisFrame = speed * Time.deltaTime;

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
            this.transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}
