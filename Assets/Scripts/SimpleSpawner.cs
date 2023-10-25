using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;   // object to be spawned

    [SerializeField] int spawnRate = 1;         // number of objects to be spawned 
    [SerializeField] int destroyRate = 1;       // number of objects to be destroyed
    [SerializeField] bool autoSpawn = true;     // either spawn/destroy on button press or after a cooldown
    [SerializeField] float cooldown = 1.0f;     // set the cooldown for spawning new objects in case autospawn=true
    [SerializeField] float timeToNextSpawn;     // countdown timer

    [SerializeField] public float lastDeltaTime;       // store the last deltaTime to estimate the processing speed

    public void SetSpawnRate(float spawnRate)
    {
        this.spawnRate = (int)spawnRate;
    }

    public void SetDestroyRate(float destroyRate)
    {
        this.destroyRate = (int)destroyRate;
    }

    void Start()
    {
        // set the cooldown until the next spawn (if autoSpawn is activated)
        timeToNextSpawn = cooldown; 
    }

    void Update()
    {
        lastDeltaTime = Time.deltaTime;

        if (autoSpawn)  // automatically destroys/spawns new objects everytime the timer hits 0
        {
            timeToNextSpawn -= Time.deltaTime;
            if (timeToNextSpawn < 0)
            {
                // spawn <objectsToDestroy> objects
                var objectsToDestroy = Mathf.Min(transform.childCount, destroyRate);
                for (int i = 0; i < objectsToDestroy; i++)
                {
                    DestroyObject(Random.Range(0, transform.childCount));
                }

                // spawn <spawnRate> objects
                for (int i = 0; i < spawnRate; i++)
                {
                    SpawnObject();
                }
                timeToNextSpawn = cooldown;
            }
        }   
        else
        {
            // everytime we press X, spawn <objectsToDestroy> objects
            if (Input.GetKeyDown(KeyCode.X))
            {
                var objectsToDestroy = Mathf.Min(transform.childCount, destroyRate);
                Debug.Log("Objects to destroy " + objectsToDestroy);
                for (int i = 0; i < objectsToDestroy; i++)
                {
                    DestroyObject(Random.Range(0, transform.childCount));
                }
            }

            // everytime we press S, spawn <spawnRate> objects
            if (Input.GetKeyDown(KeyCode.S))
            {
                for (int i = 0; i < spawnRate; i++)
                {
                    SpawnObject();
                }
            }
        }
    }

    void SpawnObject()
    {
        // create a new object, position it randomly and assign its parent transform to the spawner
        var go = Instantiate<GameObject>(objectPrefab);
        go.transform.parent = transform;
        go.transform.localPosition = new Vector3(Random.Range(-3f, 3f), Random.RandomRange(-3f, 3f), 0);

        // get a random color from our singleton
        if (Singleton.Instance != null)
            go.GetComponent<SpriteRenderer>().color = Singleton.Instance.getColor();
    }

    void DestroyObject(int destroyIndex)
    {
        // destroy the selected object immediately
        DestroyImmediate(transform.GetChild(destroyIndex).gameObject);
    }
}

