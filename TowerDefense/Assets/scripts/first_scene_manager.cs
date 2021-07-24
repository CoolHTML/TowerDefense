using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_scene_manager : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] Enemies;
    public int maxEnOnScreen;
    public int totalEnOnLevel;
    public int enemiesSpawnTogether;
    private int enemiesOnScreen = 0;
    public static first_scene_manager instance = null;


    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }



    public void Spawn() {
        if (enemiesSpawnTogether > 0 && enemiesOnScreen < totalEnOnLevel)
        {
            for (int i =0; i< enemiesSpawnTogether;i++)
            {
                if(enemiesOnScreen < maxEnOnScreen)
                {
                    GameObject newEnemy = Instantiate(Enemies[0] as GameObject);
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen += 1;
                }
            }
        }
    }


    public void RemoveEnemyFromScreen()
    {
        if(enemiesOnScreen > 0)
        {
            enemiesOnScreen -= 1;
        }
    }
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
