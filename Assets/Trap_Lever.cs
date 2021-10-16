using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Two conditions for activating the trap:
// Stay Collision with the Lever
// Cotinuously clicking on Z
// Once leaving the collision or not clicking Z, counter becomes 0
// When they both happen, activate the Lever, start the counter
// when counter reaches given number, activate the related trap.
public class Trap_Lever : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject activated_trap;
    public int default_activation_bar;
    private int activation_count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z) && collision.gameObject.tag == "Player")
        {
            activation_count += 1;
        }
        else if(Input.GetKey(KeyCode.Z) && collision.gameObject.tag == "Player")
        {
            activation_count += 1;
            if(activation_count >= default_activation_bar)
            {
                activated_trap.SetActive(true);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Z) && collision.gameObject.tag == "Player")
        {
            activation_count = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        activation_count = 0;
    }


}
