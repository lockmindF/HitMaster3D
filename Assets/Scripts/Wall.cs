using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Transform wallAnim;
    public bool isTrigger = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (isTrigger == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, wallAnim.transform.position, Time.deltaTime * 4);
        }
    }
    public void WallAnimation()
    {
        isTrigger = true;
        
    }
}
