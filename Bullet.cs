using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BulletShoot(RaycastHit hit)
    {
        transform.Translate(hit.point.x, hit.point.y, hit.point.z);
    }
}
