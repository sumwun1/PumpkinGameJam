using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxVelocity;
    public float acceleration;
    public Animator animator;
    public Vector2 randomRange_LeftUp;
    public AudioSource fail;
    public Vector2 randomRange_RightDown;
    public AudioSource background;
    int state;
    private float velocity;
    private float speed;
    Vector3 zeroVector;
    public bool basicEnemyTrapReady;
    Vector3 up;
    Vector3 down;
    Vector3 left;
    Vector3 right;
    public bool Dead;
    // private GameObject[] targetArr;
    // private List<float> EnemyList;
    // private Dictionary<float, GameObject> EnemyDic;
        


    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("STARTED");
        basicEnemyTrapReady = false;
        state = 2;
        speed = 0;
        zeroVector = new Vector3(0, 0, 0);
        Dead = false;
        up = new Vector3(0, 1, 0);
        down = new Vector3(0, -1, 0);
        left = new Vector3(-1, 0, 0);
        right = new Vector3(1, 0, 0);
        
        // Get all the traps or enemies
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
        int loop_counter = 0;
        // Reset their position in a small range based on their original position
        for (int i = 0; i < TrapArr.Length;)
        {
            isIntersect = false;
            loop_counter = loop_counter + 1;
            if(loop_counter > 20)
            {
                continue;
            }
            // print("here!");
            TrapArr[i].transform.position = TrapArr[i].transform.position + new Vector3(Random.Range(randomRange_LeftUp.x, randomRange_RightDown.x), Random.Range(randomRange_LeftUp.y, randomRange_RightDown.y), 0);
            Transform midTransform = TrapArr[i].transform;
            Vector3 midTransformPos = midTransform.position;
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
            for (int j = 0; j < i; j++)
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
                loop_counter = 0;
            }
        }
        loop_counter = 0;
        for (int i = 0; i < EnemyArr.Length;)
        {
            isIntersect = false;
            loop_counter = loop_counter + 1;
            if (loop_counter > 20)
            {
                continue;
            }
            EnemyArr[i].transform.position = EnemyArr[i].transform.position + new Vector3(Random.Range(randomRange_LeftUp.x, randomRange_RightDown.x), Random.Range(randomRange_LeftUp.y, randomRange_RightDown.y), 0);
            Transform midTransform = EnemyArr[i].transform;
            Vector3 midTransformPos = midTransform.position;
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
            for (int j = 0; j < i; j++)
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
            // Move to the following trap only when last trap is correctly set.
            if (!isIntersect)
            {
                i = i + 1;
                loop_counter = 0;
            }
        }
        basicEnemyTrapReady = true;
    }

    void ifDead()
    {
        if (this.Dead)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = zeroVector;
        
        //ifDead();

        if (state != 0)
        {
            //Debug.Log("DEAD");
            return;
        }
        
        if (Input.GetKey("right") && Input.GetKey("up"))
        {
            velocity = maxVelocity - 2;
        }
        else if (Input.GetKey("right") && Input.GetKey("down"))
        {
            velocity = maxVelocity - 2;
        }
        else if (Input.GetKey("left") && Input.GetKey("up"))
        {
            velocity = maxVelocity - 2;
        }
        else if (Input.GetKey("left") && Input.GetKey("down"))
        {
            velocity = maxVelocity - 2;
        }
        else
        {
            velocity = maxVelocity;
        }

        if (Input.GetKey("up"))
        {
            animator.SetInteger("direction", 0);

            if (speed < velocity)
            {
                speed += acceleration;
            }
            if (speed > velocity)
            {
                speed -= acceleration;
            }
            transform.Translate(up * speed * Time.deltaTime, Space.World);
        }
        else if (!Input.GetKey("right") && !Input.GetKey("left") && !Input.GetKey("down"))
        {
            if (speed > 0)
            {
                speed -= acceleration;
            }
        }

        if (Input.GetKey("down"))
        {
            animator.SetInteger("direction", 1);

            if (speed < velocity)
            {
                speed += acceleration;
            }
            if (speed > velocity)
            {
                speed -= acceleration;
            }
            transform.Translate(down * speed * Time.deltaTime, Space.World);
        }
        else if (!Input.GetKey("left") && !Input.GetKey("right") && !Input.GetKey("up"))
        {
            if (speed > 0)
            {
                speed -= acceleration;
            }
        }
        

        if (Input.GetKey("left"))
        {
            animator.SetInteger("direction", 2);
            
            if (speed < velocity)
            {
                speed += acceleration;
            }
            if (speed > velocity)
            {
                speed -= acceleration;
            }
            transform.Translate(left * speed * Time.deltaTime, Space.World);
        }
        else if (!Input.GetKey("right") && !Input.GetKey("up") && !Input.GetKey("down"))
        {
            if (speed > 0)
            {
                speed -= acceleration;
            }
        }

        if (Input.GetKey("right"))
        {
            animator.SetInteger("direction", 3);
            
            if (speed < velocity)
            {
                speed += acceleration;
            }
            if (speed > velocity)
            {
                speed -= acceleration;
            }
            transform.Translate(right * speed * Time.deltaTime, Space.World);
        }
        else if (!Input.GetKey("left") && !Input.GetKey("up") && !Input.GetKey("down"))
        {
            if (speed > 0)
            {
                speed -= acceleration;
            }
        }
        
        if (!Input.GetKey("left") && !Input.GetKey("up") && !Input.GetKey("down") && !Input.GetKey("right"))
        {
            animator.SetInteger("direction", 4);
        }
    }
    
    public void Die()
    {
        state = 1;
        background.Stop();
        fail.Play();
        animator.SetInteger("direction", 4);
        Debug.Log("dang");
        
        // Setting the random reset range.
        // first reload the scene
        this.Dead = true;
    }

    public int GetState()
    {
        return (state);
    }
    
    public void SetState(int x)
    {
        state = x;
    }

}
