using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{
    public Vector2 coords;
    public static WorldTile CreateWorldTile(Transform parent)
    {
        GameObject GO = Instantiate(Resources.Load("Prefabs/World/FloorBase")) as GameObject;
        GO.transform.parent = parent;
        return GO.AddComponent<WorldTile>();
    }

    public void SetTileCoordinates(int x, int y)
    {
        coords = new Vector2(x, y);
        this.transform.position = new Vector3(x*10, 0, y*10);
    }
}
