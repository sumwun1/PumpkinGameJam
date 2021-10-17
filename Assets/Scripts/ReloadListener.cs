using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadListener : MonoBehaviour
{
    private Player player;
    public int trap_plus_num;
    public int enemy_plus_num;
    public int level;
    public GameObject spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        level = 1;
        spawnManager.GetComponent<SpawnManager>().StartLevel(level);
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
            /*GameObject.Find("GameDataRecorder").GetComponent<GameData>().additional_enemy_num += this.enemy_plus_num;
            GameObject.Find("GameDataRecorder").GetComponent<GameData>().additional_trap_num += this.trap_plus_num;
            SceneManager.LoadScene(0);*/
            Vector3 zero = new Vector3(0, 0, 0);
            Trap_Activation[] buttons = GameObject.FindObjectsOfType<Trap_Activation>();

            for(int a = 0; a < buttons.Length; a++)
            {
                Destroy(buttons[a].gameObject);
            }

            Trap_1[] spikes = GameObject.FindObjectsOfType<Trap_1>();

            for (int a = 0; a < spikes.Length; a++)
            {
                Destroy(spikes[a].gameObject);
            }

            Turret[] turrets = GameObject.FindObjectsOfType<Turret>();

            for (int a = 0; a < turrets.Length; a++)
            {
                Destroy(turrets[a].gameObject);
            }

            Bullet[] bullets = GameObject.FindObjectsOfType<Bullet>();

            for (int a = 0; a < bullets.Length; a++)
            {
                Destroy(bullets[a].gameObject);
            }

            player.gameObject.transform.position = zero;
            level++;
            spawnManager.GetComponent<SpawnManager>().StartLevel(level);
        }
        //return;
    }
}
