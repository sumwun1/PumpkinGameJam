using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject player;
    public GameObject backgroundMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("z"))
        {
            player.GetComponent<Player>().SetState(0);
            backgroundMusic.GetComponent<AudioSource>().Play();
            this.gameObject.SetActive(false);
        }
    }
}
