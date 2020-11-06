using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    

    public Random rand = new Random();

    public Transform playerTransform;
    public float spawnX = 80.0f;
    public float tileLength = 1.0f;
    public int amountOfTilesOnScreen = 10;
    private List<GameObject> activeTiles;
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Santa").transform;
        for (int i = 0; i < amountOfTilesOnScreen; i++)
        {
            SpawnTile();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x > (spawnX - amountOfTilesOnScreen * tileLength))
        {
            SpawnTile();
        }

    }

    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go = Instantiate(tilePrefabs[Random.Range(0, 3)]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(this.spawnX, Random.Range(-4.0f, 1.0f), 0.0f);
        spawnX = spawnX + tileLength * Random.Range(1.0f, 2.0f);
        activeTiles.Add(go);

    }
    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
