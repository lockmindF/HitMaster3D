using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int enemyCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyKill()
    {
        enemyCount--;
        if (enemyCount == 0)
        {
            FindObjectOfType<Player>().EnemyKill();
        }
     }
}
