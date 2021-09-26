using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isStart = false;
    public bool isRun = false;
    public bool isShoot = false;
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
        if (isStart == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isRun = true;
                isStart = true;
                anim.SetBool("isRun", true);
                anim.SetBool("isStart", true);
            }
        }

        
        if (isRun == true)
        {
            
            player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
            if (player.position == waypoints[current].transform.position)
            {
                current++;
                isShoot = true;
                isRun = false;
                anim.SetBool("isRun", false);
                anim.SetBool("isShoot", true);
            }
            
        }

    }
    void NextWayPoint()
    {


    }
}

