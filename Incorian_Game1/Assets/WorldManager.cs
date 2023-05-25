using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldManager
{
    private static WorldManager _instance;
    public static WorldManager Singleton
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WorldManager();
            }
            return _instance;
        }
    }

    private WorldManager()
    {
        //define private parameterless constructor to not have a public creator available
    }

    public void CreateBaseMap(Transform parent) 
    {
        for (int x = 0; x < StartingGridDimensions.x; x++)
        {
            for (int y = 0; y < StartingGridDimensions.y; y++)
            {
                WorldTile tile = WorldTile.CreateWorldTile(parent);
                tile.SetTileCoordinates(x, y);
                GridMap.Add(tile);
            }
        }
    }

    public List<WorldTile> GridMap = new List<WorldTile>();

    public Vector2 StartingGridDimensions = new Vector2(10, 10);
}
