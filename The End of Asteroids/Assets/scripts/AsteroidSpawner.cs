using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns asteroid
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAsteroid(-8.5f, 0, Direction.Right);
        SpawnAsteroid(0, 4.5f, Direction.Down);
        SpawnAsteroid(8.5f, 0, Direction.Left);
        SpawnAsteroid(0, -4.5f, Direction.Up);
    }

    void SpawnAsteroid(float x, float y, Direction direction)
    {
        // set the center as location and create new asteroid in the screen
        Vector3 location = new Vector3(x, y, -Camera.main.transform.position.z);

        //Spawn asteroid in the world
        GameObject rock = Instantiate(prefabAsteroid) as GameObject;
        rock.GetComponent<Asteroid>().Initialize(direction, location);
    }
}
