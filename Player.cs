using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isStart = false;
    public bool isRun = false;
    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float Wradius = 1;
    public Transform player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isRun = true;
            anim.SetBool("isRun", true);
            NextWayPoint();


        }
        

    }
    void NextWayPoint()
    {
        if (isRun == true)
        {
            
            player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
            
        }

    }
}

