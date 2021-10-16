using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Activation : MonoBehaviour
{
    public float range;
    public GameObject activated_trap;
    Transform playerTransform;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindObjectOfType<Player>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && (playerTransform.position - this.transform.localPosition).magnitude <= range)
        {
            Debug.Log("pressed");
            animator.SetBool("IsPushed", true);
            activated_trap.SetActive(true);
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z) && collision.gameObject.tag == "Player"){
            Debug.Log("pressed");
            activated_trap.SetActive(true);
        }
    }*/


}
