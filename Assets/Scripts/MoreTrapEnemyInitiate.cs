using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreTrapEnemyInitiate : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    public Trap_Activation buttonPrefab;
    public Turret turretPrefab;
    public Trap_Lever leverPrefab;
    public Enemy enemyPrefab;
    public Trap_1 platePrefab;
    public Vector2 randomRange_LeftUp;
    public Vector2 randomRange_RightDown;
    GameData dataRecorder;
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        dataRecorder = GameObject.FindObjectOfType<GameData>();
        // print("GameDataEnemyNumber" + dataRecorder.additional_enemy_num);
        while (!player.basicEnemyTrapReady)
        {
            player = GameObject.FindObjectOfType<Player>();
            print(player.basicEnemyTrapReady);
        }
        print("dataRecorder here!");
        print(dataRecorder.additional_enemy_num);
        GameObject[] TrapArr = GameObject.FindGameObjectsWithTag("Trap");
        List<float> TrapList = new List<float>();
        Dictionary<float, GameObject> TrapDic = new Dictionary<float, GameObject>();
        GameObject[] WallArr = GameObject.FindGameObjectsWithTag("Wall");
        List<float> WallList = new List<float>();
        Dictionary<float, GameObject> WallDic = new Dictionary<float, GameObject>();
        GameObject[] EnemyArr = GameObject.FindGameObjectsWithTag("Enemy");
        List<float> EnemyList = new List<float>();
        Dictionary<float, GameObject> EnemyDic = new Dictionary<float, GameObject>();
        bool isIntersect;

        for (int i = 0; i < dataRecorder.additional_trap_num;)
        {
            isIntersect = false;
            
            Vector3 midTransformPos = new Vector3(Random.Range(randomRange_LeftUp.x, randomRange_RightDown.x), Random.Range(randomRange_LeftUp.y, randomRange_RightDown.y), 0);
            Transform midTransform = TrapArr[0].transform;
            Vector3 midTransformScale = midTransform.localScale;
            // print("here!");
            // Give a random bias to the position of the trap 
            for (int j = 0; j < WallArr.Length; j++)
            {
                Vector3 WallPos = WallArr[j].transform.position;
                Vector3 WallScale = WallArr[j].transform.localScale;
                float halfSum_X = (midTransformScale.x * 0.5f) + (WallScale.x * 0.5f);
                float halfSum_Z = (midTransformScale.y * 0.5f) + (WallScale.y * 0.5f);
                float distance_X = Mathf.Abs(midTransformPos.x - WallPos.x);
                float distance_Z = Mathf.Abs(midTransformPos.y - WallPos.y);
                if (distance_X <= halfSum_X && distance_Z <= halfSum_Z)
                {
                    isIntersect = true;
                }
                else
                {
                    isIntersect = false;
                }
            }
            for (int j = 0; j < TrapArr.Length; j++)
            {
                Vector3 WallPos = TrapArr[j].transform.position;
                Vector3 WallScale = TrapArr[j].transform.localScale;
                float halfSum_X = (midTransformScale.x * 0.5f) + (WallScale.x * 0.5f);
                float halfSum_Z = (midTransformScale.y * 0.5f) + (WallScale.y * 0.5f);
                float distance_X = Mathf.Abs(midTransformPos.x - WallPos.x);
                float distance_Z = Mathf.Abs(midTransformPos.y - WallPos.y);
                if (distance_X <= halfSum_X && distance_Z <= halfSum_Z)
                {
                    isIntersect = true;
                }
                else
                {
                    isIntersect = false;
                }
            }
            for (int j = 0; j < EnemyArr.Length; j++)
            {
                Vector3 WallPos = EnemyArr[j].transform.position;
                Vector3 WallScale = EnemyArr[j].transform.localScale;
                float halfSum_X = (midTransformScale.x * 0.5f) + (WallScale.x * 0.5f);
                float halfSum_Z = (midTransformScale.y * 0.5f) + (WallScale.y * 0.5f);
                float distance_X = Mathf.Abs(midTransformPos.x - WallPos.x);
                float distance_Z = Mathf.Abs(midTransformPos.y - WallPos.y);
                if (distance_X <= halfSum_X && distance_Z <= halfSum_Z)
                {
                    isIntersect = true;
                }
                else
                {
                    isIntersect = false;
                }
            }
            // Move to the following trap only when last trap is correctly set.
            if (!isIntersect)
            {
                i = i + 1;
                int InitiatedTrapId = Random.Range(0, 4);
                if (InitiatedTrapId == 0)
                {
                    var initiatedTrap = Instantiate<Trap_Activation>(buttonPrefab);
                    initiatedTrap.transform.position = midTransformPos;
                }
                else if(InitiatedTrapId == 1)
                {
                    var initiatedTrap = Instantiate<Trap_Lever>(leverPrefab);
                    initiatedTrap.transform.position = midTransformPos;
                }
                else if (InitiatedTrapId == 2)
                {
                    var initiatedTrap = Instantiate<Turret>(turretPrefab);
                    initiatedTrap.transform.position = midTransformPos;
                }
                else if (InitiatedTrapId == 3)
                {
                    var initiatedTrap = Instantiate<Trap_1>(platePrefab);
                    initiatedTrap.transform.position = midTransformPos;
                }
            }
            TrapArr = GameObject.FindGameObjectsWithTag("Trap");
            TrapList = new List<float>();
            TrapDic = new Dictionary<float, GameObject>();
        }
       
        for (int i = 0; i < dataRecorder.additional_enemy_num;)
        {
            isIntersect = false;
            // print("here!");
            Vector3 midTransformPos = new Vector3(Random.Range(randomRange_LeftUp.x, randomRange_RightDown.x), Random.Range(randomRange_LeftUp.y, randomRange_RightDown.y), 0);
            Transform midTransform = EnemyArr[0].transform;
            Vector3 midTransformScale = midTransform.localScale;
            // Give a random bias to the position of the trap 
            for (int j = 0; j < WallArr.Length; j++)
            {
                Vector3 WallPos = WallArr[j].transform.position;
                Vector3 WallScale = WallArr[j].transform.localScale;
                float halfSum_X = (midTransformScale.x * 0.5f) + (WallScale.x * 0.5f);
                float halfSum_Z = (midTransformScale.y * 0.5f) + (WallScale.y * 0.5f);
                float distance_X = Mathf.Abs(midTransformPos.x - WallPos.x);
                float distance_Z = Mathf.Abs(midTransformPos.y - WallPos.y);
                if (distance_X <= halfSum_X && distance_Z <= halfSum_Z)
                {
                    isIntersect = true;
                }
                else
                {
                    isIntersect = false;
                }
            }
            for (int j = 0; j < TrapArr.Length; j++)
            {
                Vector3 WallPos = TrapArr[j].transform.position;
                Vector3 WallScale = TrapArr[j].transform.localScale;
                float halfSum_X = (midTransformScale.x * 0.5f) + (WallScale.x * 0.5f);
                float halfSum_Z = (midTransformScale.y * 0.5f) + (WallScale.y * 0.5f);
                float distance_X = Mathf.Abs(midTransformPos.x - WallPos.x);
                float distance_Z = Mathf.Abs(midTransformPos.y - WallPos.y);
                if (distance_X <= halfSum_X && distance_Z <= halfSum_Z)
                {
                    isIntersect = true;
                }
                else
                {
                    isIntersect = false;
                }
            }
            for (int j = 0; j < EnemyArr.Length; j++)
            {
                Vector3 WallPos = EnemyArr[j].transform.position;
                Vector3 WallScale = EnemyArr[j].transform.localScale;
                float halfSum_X = (midTransformScale.x * 0.5f) + (WallScale.x * 0.5f);
                float halfSum_Z = (midTransformScale.y * 0.5f) + (WallScale.y * 0.5f);
                float distance_X = Mathf.Abs(midTransformPos.x - WallPos.x);
                float distance_Z = Mathf.Abs(midTransformPos.y - WallPos.y);
                if (distance_X <= halfSum_X && distance_Z <= halfSum_Z)
                {
                    isIntersect = true;
                }
                else
                {
                    isIntersect = false;
                }
            }
            // Move to the following trap only when last trap is correctly set.
            if (!isIntersect)
            {
                i = i + 1;
                var initiatedEnemy = Instantiate<Enemy>(enemyPrefab);
                initiatedEnemy.transform.position = midTransformPos;
            }
            EnemyArr = GameObject.FindGameObjectsWithTag("Enemy");
            EnemyList = new List<float>();
            EnemyDic = new Dictionary<float, GameObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
