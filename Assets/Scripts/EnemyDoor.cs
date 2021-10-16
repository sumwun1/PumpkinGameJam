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
        var Enemy = Instantiate(enemy);
        Enemy.transform.position = new Vector3(Random.Range(-10f, 30f), Random.Range(10f, 30f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
