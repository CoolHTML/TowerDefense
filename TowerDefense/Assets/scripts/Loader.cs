using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject manager;


    private void Awake()
    {
        if(first_scene_manager.instance == null)
        {
            Instantiate(manager);
        }
    }
}
