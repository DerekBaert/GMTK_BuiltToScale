using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int contentType = 0;
    public GameObject myTile;
    private TileInfo[,] owner;
    private int xPos;
    private int yPos;

    public void Initialize(int type, int x, int y, TileInfo[,] o) {

        contentType = type;
        xPos = x;
        yPos = y;
        owner = o;

        CreateTile();
    }

    public void CreateTile() {
        myTile = Instantiate(Resources.Load("Tiles/Tile_" + DetermineHouseTile()) as GameObject, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    public string DetermineHouseTile() {

        int tileType = 14;

        bool[] neighbours = new bool[9];

        int k = 0;

        for (int i = yPos - 1; i < yPos + 2; i++) {
            for (int j = xPos - 1; j < xPos + 2; j++) {
                if ((0 <= i && i < owner.GetLength(1)) && (0 <= j && j < owner.GetLength(0))) {
                    neighbours[k] = (owner[j,i] != null && owner[j,i].contentType == 1);
                }   
                k++;
            }
        }

        if (neighbours[1] && neighbours[3] && neighbours[5] && neighbours[7]) {
            tileType = 5;
        } else if (neighbours[1] && neighbours[3] && neighbours[5]) {
            tileType = 2;
        } else if (neighbours[1] && neighbours[3] && neighbours[7]) {
            tileType = 6;
        } else if (neighbours[1] && neighbours[5] && neighbours[7]) {
            tileType = 4;
        } else if (neighbours[3] && neighbours[5] && neighbours[7]) {
            tileType = 8;
        } else if (neighbours[1] && neighbours[3]) {
            tileType = 3;
        } else if (neighbours[1] && neighbours[5]) {
            tileType = 1;
        } else if (neighbours[1] && neighbours[7]) {
            tileType = 16;
        } else if (neighbours[3] && neighbours[5]) {
            tileType = 15;
        } else if (neighbours[3] && neighbours[7]) {
            tileType = 9;
        } else if (neighbours[5] && neighbours[7]) {
            tileType = 7;
        } else if (neighbours[1]) {
            tileType = 13;
        } else if (neighbours[3]) {
            tileType = 11;
        } else if (neighbours[5]) {
            tileType = 10;
        } else if (neighbours[7]) {
            tileType = 12;
        }

        string typeString = tileType.ToString();

        if (Math.Floor((double)tileType/10) == 0) { typeString = "0" + typeString; }

        return typeString;
    }

    public void UpdateTile() {
        Destroy(myTile);
        CreateTile();
    }

    public void Kill() {
        Destroy(myTile.gameObject);
        Destroy(this);
    }

}
