using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    //マップの元の縦の幅
    [SerializeField] const int mapHeight = 50;

    //マップの元の横の幅
    [SerializeField] const int mapWidth = 50;

    [SerializeField] int[,] map;

    [SerializeField] const int wall = 9;

    [SerializeField] const int road = 0;

    //壁のタイル
    [SerializeField] Tile WallTile;
    //道のタイル
    [SerializeField] Tile RoadTile;

    [SerializeField] Tilemap layerBuilding;

    // Start is called before the first frame update
    void Start()
    {
        InitializeMapData();

        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeMapData()
    {
        map = new int[mapHeight, mapWidth];
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                if (j == 0 || i == 0 || i == mapHeight - 1 || j == mapWidth - 1 )
                {
                    map[i, j] = wall;
                    Debug.Log(i);
                    Debug.Log(j);
                }
                else
                {
                    map[i, j] = road;
                }
            }
        }
    }

    private void CreateMap()
    {
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                if (map[i, j] == wall)
                {
                    Vector3Int wallPosition = new Vector3Int(i, j, 0);
                    layerBuilding.SetTile(wallPosition, WallTile);
                }
                else
                {
                    Vector3Int roadPosition = new Vector3Int(i, j, 0);
                    layerBuilding.SetTile(roadPosition, RoadTile);
                }
            }

        }
    }
}
