using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Activation : MonoBehaviour
{
    public GameObject activated_trap;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z) && collision.tag == "Player"){
            activated_trap.SetActive(true);
        }
    }


}
