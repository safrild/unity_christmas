using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject groundPrefab;
    public Random rand = new Random();
    public Transform playerTransform;
    public float spawnX = -15.0f;
    public float groundSpawnX = -15.0f;
    public float tileLength = 5.0f;
    public float groundLength = 29.44f;
    public int amountOfTilesOnScreen = 10;
    public int amountOfGroundOnScreen = 2;
    private List<GameObject> activeTiles;
    private List<GameObject> activeGround;
    void Start()
    {
        activeTiles = new List<GameObject>();
        activeGround = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Santa").transform;
        for (int i = 0; i < amountOfTilesOnScreen; i++)
        {
            SpawnTile();
        }
        for (int i = 0; i < amountOfGroundOnScreen; i++)
        {
            SpawnGround();
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x > (spawnX - amountOfTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
        if (playerTransform.position.x >= (groundSpawnX - 0.3 *  groundLength))
        {
            SpawnGround();
            DeleteGround();
        }

    }

    void SpawnTile()
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

    void SpawnGround()
    {
        GameObject ground = Instantiate(groundPrefab) as GameObject;
        ground.transform.SetParent(transform);
        ground.transform.position = new Vector3(this.groundSpawnX, -8.0f, 0.0f);
        groundSpawnX = groundSpawnX + groundLength;
        activeGround.Add(ground);
    }

    void DeleteGround()
    {
        Destroy(activeGround[0]);
        activeGround.RemoveAt(0);
    }
}
