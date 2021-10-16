using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : MonoBehaviour
{
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
