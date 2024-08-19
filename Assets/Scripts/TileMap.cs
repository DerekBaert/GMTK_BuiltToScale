using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{

    public TileInfo[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new TileInfo[10, 10];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = WorldPosToTilePos(GetMouseWorldPosition());
            Debug.Log("Pressed left-click at " + mousePos.x + ", " + mousePos.y);
            if ((GetMouseWorldPosition().z > -2) && (0 <= mousePos.x && mousePos.x < tiles.GetLength(0)) && (0 <= mousePos.y && mousePos.y < tiles.GetLength(1))) {
                Debug.Log("Inside");
                int x = (int)mousePos.x;
                int y = (int)mousePos.y;
                if (tiles[x, y] == null) {
                    tiles[x, y] = gameObject.AddComponent(typeof(TileInfo)) as TileInfo;
                    tiles[x, y].Initialize(1, x, y, tiles);
                } else if (tiles[x,y].contentType == 1) {
                    tiles[x,y].Kill();
                    tiles[x,y] = null;
                }

                UpdateTiles();
            }

        }

    }

    public void UpdateTiles() {
        for (int x = 0; x < tiles.GetLength(0); x++) {
            for (int y = 0; y < tiles.GetLength(1); y++) {
                if (tiles[x,y] != null && tiles[x,y].contentType == 1) { tiles[x,y].UpdateTile(); }
            }
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public static Vector2 WorldPosToTilePos(Vector3 worldpos) {
        return new Vector2((int)worldpos.x, (int)worldpos.y);
    }
}
