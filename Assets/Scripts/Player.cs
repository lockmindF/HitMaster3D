using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isStart = false;
    public bool isRun = false;
    public bool isShoot = false;
    public bool isShooting = true;
    public GameObject[] waypoints;
    public int current = 0;
    public float speed;
    public Transform player;
    public Animator anim;
    public Camera camera;
    public GameObject camShootPoint;
    public GameObject bullet;
    public float Power;
    public Rigidbody rbBullet;
    public int count = 3;
    public Transform mainCamera;
    public Transform bulletSpawn;

    void Start()
    {
        anim = GetComponent<Animator>();
        mainCamera.transform.position = camera.transform.position;
    }

    void Update()
    {
        

        
        if (isRun == true && player.transform.position != waypoints[current].transform.position)
        {
            Run(); 
        }
        if (isShoot == true && isRun == false)
        {
            Shoot();
        }
    }
    public void StartGame()
    {
        isRun = true;
        isStart = true;
        anim.SetBool("isRun", true);
        anim.SetBool("isStart", true);
    }
    public void EnemyKill()
    {
        isRun = true;
        isShoot = false;
        anim.SetBool("isRun", true);
        anim.SetBool("isShoot", false);
    }
    public void Run()
    {
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, mainCamera.transform.position, Time.deltaTime * speed);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        if (player.position == waypoints[current].transform.position)
        {
            if (waypoints.Length == current+1)
            {
                isStart = false;
                isRun = false;
                anim.SetBool("isStart", false);
                anim.SetBool("isRun", false);
                FindObjectOfType<GameManager>().LevelCompleted();

            }
            else
            {
                isShoot = true;
                isRun = false;
                anim.SetBool("isRun", false);
                anim.SetBool("isShoot", true);

                current++;
            }
            
        }
        
        
    }
    void Shoot()
    {
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, camShootPoint.transform.position, Time.deltaTime * speed);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                GameObject b = Instantiate(bullet, new Vector3(bulletSpawn.position.x, bulletSpawn.position.y, bulletSpawn.position.z), Quaternion.identity);
                b.GetComponent<Rigidbody>().AddForce(new Vector3(hit.point.x/5, hit.point.y/7, 1)* Power, ForceMode.Impulse);
            }
            if (isShooting == true)
            {
                anim.SetBool("isShooting", false);
                isShooting = false;
            }
            else 
            {
                anim.SetBool("isShooting", true);
                isShooting = true;
            }
            
            

        }
        

    }
}

