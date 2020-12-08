using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject groundPrefab;
    public GameObject[] backgroundPrefabs;

    public Random rand = new Random();

    public Transform playerTransform;

    public float spawnX = -5.0f;
    public float groundSpawnX = -15.0f;
    public float backgroundSpawnX = -15.0f; 

    public float tileLength = 5.0f;
    public float groundLength = 29.44f;
    public float backgroundLength = 13.0f;

    public int amountOfTilesOnScreen = 10;
    public int amountOfGroundOnScreen = 2;
    public int amountOfBGOnScreen = 6;

    public List<GameObject> activeTiles;
    public List<GameObject> activeGround;
    public List<GameObject> activeBG;

    void Start()
    {
        activeTiles = new List<GameObject>();
        activeGround = new List<GameObject>();
        activeBG = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Santa").transform;

        for (int i = 0; i < amountOfTilesOnScreen; i++)
        {
            SpawnTile();
        }
        for (int i = 0; i < amountOfGroundOnScreen; i++)
        {
            SpawnGround();
        }
        for (int i = 0; i < amountOfBGOnScreen; i++)
        {
            SpawnBG();
        }

    }

    void Update()
    {
        if (playerTransform.position.x > (spawnX - amountOfTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }

        if (playerTransform.position.x >= (groundSpawnX - 0.1 * groundLength))
        {
            SpawnGround();
            DeleteGround();
        }

        if (playerTransform.position.x >= (backgroundSpawnX - amountOfBGOnScreen * backgroundLength))
        {
            SpawnBG();
            DeleteBG();
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

    public void SpawnBG(bool respawnCase = false)
    {
        GameObject bg1 = Instantiate(backgroundPrefabs[0]) as GameObject;
        GameObject bg2 = Instantiate(backgroundPrefabs[1]) as GameObject;
        bg1.transform.SetParent(transform);
        bg2.transform.SetParent(transform);
        if (respawnCase)
        {
            backgroundSpawnX = -15.0f;
            DeleteBG();
            respawnCase = false;
        }
        bg1.transform.position = new Vector3(this.backgroundSpawnX, -7.0f, 0.0f);
        bg2.transform.position = new Vector3(this.backgroundSpawnX, -7.0f, 0.0f);
        backgroundSpawnX = backgroundSpawnX + backgroundLength;
        activeBG.Add(bg1);
        activeBG.Add(bg2);
    }

    public void DeleteBG()
    {
        Destroy(activeBG[0]);
        activeBG.RemoveAt(0);
        Destroy(activeBG[0]);
        
        activeBG.RemoveAt(0);
    }   
}
