using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    public int additional_enemy_num;
    public int additional_trap_num;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
