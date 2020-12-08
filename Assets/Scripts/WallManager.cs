using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject[] wallPrefabs;
    public float zSpawn = 0;
    public float wallLength = 30;
    public int numberOfWalls = 3;
    private List<GameObject> activeWalls = new List<GameObject>();

    public Transform playerTransform;
    void Start()
    {
        for (int i = 0; i < numberOfWalls; i++)
        {
            if (i == 0)
                SpawnWall(0);
            else
                SpawnWall(Random.Range(0, wallPrefabs.Length));
        }

    }
    void Update()
    {
        if (playerTransform.position.z - 30 > zSpawn - (numberOfWalls * wallLength))
        {
            SpawnWall(Random.Range(0, wallPrefabs.Length));
            DeleteWall();
        }

    }
    public void SpawnWall(int tileIndex)
    {

        GameObject go = Instantiate(wallPrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeWalls.Add(go);
        zSpawn += wallLength;
    }

    private void DeleteWall()
    {
        Destroy(activeWalls[0]);
        activeWalls.RemoveAt(0);
    }
}