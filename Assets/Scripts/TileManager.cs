using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject groundPrefab;

    public Random rand = new Random();

    public Transform playerTransform;

    public float spawnX = -10.0f;
    public float groundSpawnX = -15.0f;

    public float tileLength = 5.0f;
    public float groundLength = 29.44f;

    public int amountOfTilesOnScreen = 10;
    public int amountOfGroundOnScreen = 2;

    public List<GameObject> activeTiles;
    public List<GameObject> activeGround;

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

    public void SpawnTile(bool respawnCase = false)
    {
        GameObject go = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length)]) as GameObject;        
        go.transform.SetParent(transform);
        
        if (respawnCase)
        {
           spawnX = -10.0f;
           DeleteTile();
            respawnCase = false;
        }
        
        go.transform.position = new Vector3(spawnX, Random.Range(-4.0f, 1.0f), 0.0f);
        spawnX = spawnX + tileLength * 2;
        activeTiles.Add(go);
    }
    
    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public void SpawnGround(bool respawnCase = false)
    {
        GameObject ground = Instantiate(groundPrefab) as GameObject;
        ground.transform.SetParent(transform);
        if (respawnCase)
        {
            groundSpawnX = -15.0f;
            DeleteGround();
            respawnCase = false;
        }
        ground.transform.position = new Vector3(this.groundSpawnX, -8.0f, 0.0f);
        groundSpawnX = groundSpawnX + groundLength - 7;
        activeGround.Add(ground);
    }

    void DeleteGround()
    {
        Destroy(activeGround[0]);
        activeGround.RemoveAt(0);
    }
}
