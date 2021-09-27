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
    float rotSpeed;
    public float speed;
    float Wradius = 1;
    public Transform player;
    public Animator anim;
    public Camera camera;
    public GameObject camShootPoint;
    public GameObject bullet;
    public float Power;
    public Rigidbody rbBullet;
    public int count = 3;
    public Transform mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mainCamera.transform.position = camera.transform.position;
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

        
        if (isRun == true && player.transform.position != waypoints[current].transform.position)
        {

            Run();
            
        }
        if (isShoot == true && isRun == false)
        {
            Shoot();
        }

        


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
            
            isShoot = true;
            isRun = false;
            anim.SetBool("isRun", false);
            anim.SetBool("isShoot", true);
            current++;


        }
    }
    void Shoot()
    {
        
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, camShootPoint.transform.position, Time.deltaTime * speed);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)); // создание луча из точки нажатия мыши на экран, 1 z можно менять, если положение получается не корректным
            RaycastHit hit; // контейнер для результата столкновения луча с мешем

            if (Physics.Raycast(ray, out hit)) // пускаем луч
            {
                
                GameObject b = Instantiate(bullet, new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z -5f), Quaternion.identity);
                b.GetComponent<Rigidbody>().AddForce(Vector3.forward * Power, ForceMode.Impulse);
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

