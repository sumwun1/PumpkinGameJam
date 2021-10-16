using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // Quaternion randomRotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), 0f);
        // Instantiate(enemy, startPosition, randomRotation);
        GameObject Enemy = Instantiate(enemy);
        Enemy.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-8f, 8f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
