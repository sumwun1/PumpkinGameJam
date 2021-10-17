using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Activation : MonoBehaviour
{
    public float range;
    public GameObject activated_trap;
    public Turret turretPrefab;
    public Vector2 randomRange_LeftUp;
    public Vector2 randomRange_RightDown;
    public Trap_1 platePrefab;
    public bool mutualSetup = false;
    Transform playerTransform;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindObjectOfType<Player>().GetComponent<Transform>();
        if (!mutualSetup)
        {
            GameObject[] TrapArr = GameObject.FindGameObjectsWithTag("Trap");
            List<float> TrapList = new List<float>();
            Dictionary<float, GameObject> TrapDic = new Dictionary<float, GameObject>();
            GameObject[] WallArr = GameObject.FindGameObjectsWithTag("Wall");
            List<float> WallList = new List<float>();
            Dictionary<float, GameObject> WallDic = new Dictionary<float, GameObject>();
            GameObject[] EnemyArr = GameObject.FindGameObjectsWithTag("Enemy");
            List<float> EnemyList = new List<float>();
            Dictionary<float, GameObject> EnemyDic = new Dictionary<float, GameObject>();
            Vector3 midTransformPos = new Vector3(Random.Range(randomRange_LeftUp.x, randomRange_RightDown.x), Random.Range(randomRange_LeftUp.y, randomRange_RightDown.y), 0);
            Transform midTransform = TrapArr[0].transform;
            Vector3 midTransformScale = midTransform.localScale;
            bool isIntersect = false;
            bool CorrectSetup = false;
            while (!CorrectSetup)
            {
                isIntersect = false;

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
                    CorrectSetup = true;
                    int InitiatedTrapId = Random.Range(0, 2);
                    if (InitiatedTrapId == 0)
                    {
                        var initiatedTrap = Instantiate<Turret>(turretPrefab);
                        activated_trap = initiatedTrap.transform.gameObject;
                        initiatedTrap.transform.position = midTransformPos;
                        // initiatedTrap.SetActive(false);
                    }
                    else if (InitiatedTrapId == 1)
                    {
                        var initiatedTrap = Instantiate<Trap_1>(platePrefab);
                        activated_trap = initiatedTrap.transform.gameObject;
                        initiatedTrap.transform.position = midTransformPos;
                        // initiatedTrap.SetActive(false);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && (playerTransform.position - this.transform.localPosition).magnitude <= range)
        {
            // Debug.Log("pressed");
            animator.SetBool("IsPushed", true);
            activated_trap.SetActive(true);
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z) && collision.gameObject.tag == "Player"){
            Debug.Log("pressed");
            activated_trap.SetActive(true);
        }
    }*/


}
