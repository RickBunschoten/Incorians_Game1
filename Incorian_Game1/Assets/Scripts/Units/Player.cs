using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private static string prefabPath = "Resources/Prefab/Player.prefab";
    private static Player _instance;
    public static Player Singleton
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load(prefabPath) as GameObject);
                _instance = go.AddComponent<Player>();
            }
            return _instance;
        }
    }


    private PlayerMovement playerMovement;


    public void Start()
    {
        if (_instance != this)
        {
            //Singleton guarentee, destroy this component (not whole object) if the known singleton isn't this object.
            DestroyImmediate(this);
            return;
        }
    }
}
