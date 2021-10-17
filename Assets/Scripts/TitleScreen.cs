using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public GameObject player;
    public GameObject backgroundMusic;
    public GameObject titlePanel;
    public GameObject scoreText;
    int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("z") && (player.GetComponent<Player>().GetState() != 0))
        {
            player.GetComponent<Player>().SetState(0);
            backgroundMusic.GetComponent<AudioSource>().Play();
            titlePanel.SetActive(false);
            scoreText.SetActive(true);
        }

        if(player.GetComponent<Player>().GetState() == 0)
        {
            scoreText.GetComponent<Text>().text = "score: " + score;
        }
    }

    public void RaiseScore()
    {
        score++;
    }
}
