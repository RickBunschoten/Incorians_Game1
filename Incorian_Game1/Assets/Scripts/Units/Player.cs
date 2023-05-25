using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
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


    [SerializeField]
    private PlayerMovement _playerMovement = new PlayerMovement();
    [SerializeField]
    private PlayerInput _playerInput;


    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            //Singleton guarentee, destroy this component (not whole object) if the known singleton isn't this object.
            DestroyImmediate(this);
            return;
        }
    }

    public void Start()
    {
        if (_playerInput == null) Debug.LogError("player input was null, most likely didn't grab the input from sub-object");
        _playerInput.OnKeyPressing += (KeyCode kc, uint time) =>
        {
            if (kc == KeyCode.W) _playerMovement.MoveForward(this, time);
            if (kc == KeyCode.S) _playerMovement.MoveBackwards(this, time);
        };
    }
}
