using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float Wradius = 1;

    void NextWayPoint()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < Wradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
