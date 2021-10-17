using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Vector2 dir_upLeft;
    public Vector2 dir_downRight;
    private int bulletSentCounter;
    public int defaultBar;
    private GameObject[] targetArr;
    private List<float> EnemyList;
    private Dictionary<float, GameObject> EnemyDic;

    // Start is called before the first frame update
    void Start()
    {
        EnemyDic = new Dictionary<float, GameObject>();     
        EnemyList = new List<float>();
        targetArr = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject obj = CountDistance();
        bulletSentCounter = 0;
    }

    GameObject CountDistance()
    {
        targetArr = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyDic = new Dictionary<float, GameObject>();
        EnemyList = new List<float>();
        for (int i = 0; i < targetArr.Length; i++)
        {
            float dis = Vector3.Distance(targetArr[i].transform.localPosition, transform.localPosition);
            EnemyDic.Add(dis, targetArr[i].gameObject);
            //Debug.Log(dis);
            if (!EnemyList.Contains(dis))
            {
                EnemyList.Add(dis);
            }
        }
        EnemyList.Sort();
        GameObject obj;
        EnemyDic.TryGetValue(EnemyList[0], out obj);
        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        bulletSentCounter += 1;
        if(bulletSentCounter >= defaultBar)
        {
            // var bullet = Instantiate<Bullet>(bulletPrefab);
            float Random_x = Random.Range(dir_upLeft.x, dir_downRight.x);
            float Random_y = Random.Range(dir_upLeft.y, dir_downRight.y);
            GameObject Target = CountDistance();
            Vector3 dir = Target.transform.position - this.transform.localPosition;
            Vector2 bias = new Vector2(0f, 0f);
            if(dir.x < 0)
            {
                bias.x += -0.6f;
            }
            else
            {
                bias.x += 0.6f;
            }
            if (dir.y < 0)
            {
                bias.y += -0.6f;
            }
            else
            {
                bias.y += 0.6f;
            }
            Vector3 bullet_position = new Vector3(transform.position.x + bias.x, transform.position.y + bias.y, 0);
            // Vector3 dir = new Vector3(Random_x, Random_y, 0);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var bullet = Instantiate<Bullet>(bulletPrefab, bullet_position, Quaternion.AngleAxis(angle, Vector3.forward));
            bullet.dir = dir;
            bullet.GetComponent<Bullet>().Turret = gameObject;
            bulletSentCounter = 0;
        }
        
    }
}
