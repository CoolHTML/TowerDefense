using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int target = 0;
    public Transform exit;
    public Transform[] wayPoints;
    public float navigation;

    Transform enemy;
    float navigationTime = 0;



    void Start()
    {
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wayPoints != null)
        {
            navigationTime += Time.deltaTime;
            if(navigationTime > navigation)
            {
                if (target < wayPoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, navigationTime);
                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exit.position, navigationTime);
                }
                navigationTime = 0;
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MovePoint")
        {
            target += 1;
        }
        if(collision.tag == "Finish")
        {
            Destroy(gameObject);
            first_scene_manager.instance.RemoveEnemyFromScreen();
        }
    }
}
