using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAdjustment : MonoBehaviour
{
    public Vector2 randomRange_LeftUp;
    public Vector2 randomRange_RightDown;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] WallArr = GameObject.FindGameObjectsWithTag("Wall");
        List<float> WallList = new List<float>();
        Dictionary<float, GameObject> WallDic = new Dictionary<float, GameObject>();
        GameObject[] TrapArr = GameObject.FindGameObjectsWithTag("Trap");
        List<float> TrapList = new List<float>();
        Dictionary<float, GameObject> TrapDic = new Dictionary<float, GameObject>();
        GameObject[] EnemyArr = GameObject.FindGameObjectsWithTag("Enemy");
        List<float> EnemyList = new List<float>();
        Dictionary<float, GameObject> EnemyDic = new Dictionary<float, GameObject>();
        bool isIntersect = false;
        bool CorrectSetup = false;
        Vector3 OriginalPosition = transform.position;
        while (!CorrectSetup)
        {
            Vector3 midTransformPos = transform.position + new Vector3(Random.Range(randomRange_LeftUp.x, randomRange_RightDown.x), Random.Range(randomRange_LeftUp.y, randomRange_RightDown.y), 0);
            Vector3 midTransformScale = transform.localScale;
            for (int j = 0; j < WallArr.Length; j++)
            {
                Vector3 WallPos = WallArr[j].transform.position;
                Vector3 WallScale = WallArr[j].transform.localScale;
                float halfSum_X = (midTransformScale.x * 0.5f) + (WallScale.x * 0.5f);
                float halfSum_Z = (midTransformScale.y * 0.5f) + (WallScale.y * 0.5f);
                float distance_X = Mathf.Abs(midTransformPos.x - WallPos.x);
                float distance_Z = Mathf.Abs(midTransformPos.z - WallPos.z);
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
                float distance_Z = Mathf.Abs(midTransformPos.z - WallPos.z);
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
                float distance_Z = Mathf.Abs(midTransformPos.z - WallPos.z);
                if (distance_X <= halfSum_X && distance_Z <= halfSum_Z)
                {
                    isIntersect = true;
                }
                else
                {
                    isIntersect = false;
                }
            }
            if (!isIntersect)
            {
                CorrectSetup = true;
                transform.position = midTransformPos;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
