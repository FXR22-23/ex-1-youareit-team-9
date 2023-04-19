using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs = null; // Array of obstacle prefabs to use
    public Vector3 center = new Vector3(13.5f, -3f, -45.47f); // The center of the spawn area
    public LayerMask groundLayer; // The layer mask for the ground
    // Start is called before the first frame update
    void Start()
    {
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            obstaclePrefabs = new GameObject[] { GameObject.CreatePrimitive(PrimitiveType.Cube) };
        }

        // Generate random obstacles within spawn area
        for (int i = 0; i < Constants.numOfObstcales; i++)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // Generate random position within spawn area
            Vector3 position = center + Random.insideUnitSphere * Constants.spawnRadius;

            position.y = obstaclePrefab.transform.position.y;

            Quaternion randomRotaion = Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
            Instantiate(obstaclePrefab, position, randomRotaion);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
