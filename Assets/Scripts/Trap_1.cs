using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_1 : MonoBehaviour
{
    TitleScreen titleScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.FindObjectOfType<TitleScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            titleScreen.RaiseScore();
            Destroy(gameObject);
            // Do the animation
        }
    }
}
