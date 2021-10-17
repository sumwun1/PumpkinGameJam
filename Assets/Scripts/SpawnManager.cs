using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float range;
    public GameObject enemy;
    public GameObject button;
    private int layer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        /*Spawn(enemy);
        Spawn(button);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(GameObject thing) {
        if(thing.tag == "Enemy")
        {
            layer = -1;
        }
        else
        {
            layer = 0;
        }
        
        GameObject[] spawnFars = GameObject.FindGameObjectsWithTag("SpawnFar");
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-8f, 8f), layer);

        while (true)
        {
            bool reRandomize = false;

            for(int a = 0; a < spawnFars.Length; a++)
            {
                if((spawnFars[a].transform.parent.position - spawnPosition).magnitude < range)
                {
                    reRandomize = true;
                    break;
                }
            }

            if (reRandomize)
            {
                spawnPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-8f, 8f), layer);
                continue;
            }

            break;
        }

        Instantiate(thing, spawnPosition, this.transform.rotation).SetActive(true);
    }

    public void StartLevel(int level)
    {
        for(int a = 0; a < level; a++)
        {
            Spawn(enemy);
            Spawn(button);
        }
    }
}
