using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadListener : MonoBehaviour
{
    private Player player;
    public int trap_plus_num;
    public int enemy_plus_num;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.Dead)
        {
            // GameObject.Find("GameDataRecorder").GetComponent<GameData>().additional_enemy_num = 0;
            // GameObject.Find("GameDataRecorder").GetComponent<GameData>().additional_trap_num = 0;
            SceneManager.LoadScene(0);
            return;
        }
        GameObject[] EnemyArr = GameObject.FindGameObjectsWithTag("Enemy");
        List<float> EnemyList = new List<float>();
        Dictionary<float, GameObject> EnemyDic = new Dictionary<float, GameObject>();
        if(EnemyArr.Length == 0)
        {
            GameObject.Find("GameDataRecorder").GetComponent<GameData>().additional_enemy_num += this.enemy_plus_num;
            GameObject.Find("GameDataRecorder").GetComponent<GameData>().additional_trap_num += this.trap_plus_num;
            SceneManager.LoadScene(0);
        }
        return;
    }
}
