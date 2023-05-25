using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManagerViewer : MonoBehaviour
{
    [SerializeField]
    private WorldManager worldManager;

    [SerializeField]
    private Transform worldTileParent;

    [ExecuteAlways]
    private void Awake()
    {
        worldManager = WorldManager.Singleton;
    }

    private void Start()
    {
        worldManager.CreateBaseMap(worldTileParent);
    }
}
