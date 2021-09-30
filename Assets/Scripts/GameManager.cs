using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool start = false;
    public bool finish = false;
    public GameObject finishUI;
    public GameObject startUI;
    private int enemyCount = 3;
    void Start()
    {
        finishUI.SetActive(false);
    }

    void Update()
    { 
        if (Input.GetMouseButtonDown(0) && start == false)
        {

            FindObjectOfType<Player>().StartGame();
            start = true;
            finishUI.SetActive(false);
            startUI.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && finish == true)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
    public void LevelCompleted()
    {
        finishUI.SetActive(true);
        finish = true;
        
        
    }
    public void EnemyKill()
    {
        enemyCount--;
        if (enemyCount == 0)
        {
            FindObjectOfType<Player>().EnemyKill();
            FindObjectOfType<Wall>().WallAnimation();

        }
     }

}
