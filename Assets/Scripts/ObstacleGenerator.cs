using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs = null; // Array of obstacle prefabs to use
    public Vector3 center = new Vector3(13.5f, -3f, -45.47f); // The center of the spawn area
    public float spawnRadius = 40f; // The radius in which obstacles should be spawned
    public int numObstacles = 10; // The number of obstacles to generate
    public LayerMask groundLayer; // The layer mask for the ground
    // Start is called before the first frame update
    void Start()
    {
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            obstaclePrefabs = new GameObject[] { GameObject.CreatePrimitive(PrimitiveType.Cube) };
        }

        // Generate random obstacles within spawn area
        for (int i = 0; i < numObstacles; i++)
        {
            // Generate random position within spawn area
            Vector3 position = center + Random.insideUnitSphere * spawnRadius;

            // Ensure that obstacle is placed on the ground
            RaycastHit hit;
            if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
            {
                position = hit.point;
            }

            // Instantiate random obstacle prefab at random position
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab, position, Random.rotation);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
