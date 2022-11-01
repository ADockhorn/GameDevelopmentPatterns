using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;           // object to be spawned
    [SerializeField] List<GameObject> poolObjects;      // list of objects to be (de-)activated
    [SerializeField] int nrOfActiveObjects = 0;         // number of active objects in the list
    [SerializeField] int initialPoolSize = 10;          // initial size of the pool, to be doubled each time the limit is reached

    [SerializeField] int spawnRate = 1;                 // number of objects to be (re-)activated 
    [SerializeField] int destroyRate = 1;               // number of objects to be destroyed
    [SerializeField] bool autoSpawn = true;             // either spawn/destroy on button press or after a cooldown
    [SerializeField] float cooldown = 1.0f;             // set the cooldown for spawning new objects in case autospawn=true
    [SerializeField] float timeToNextSpawn;             // countdown timer

    [SerializeField] public float lastDeltaTime;       // store the last deltaTime to estimate the processing speed

    public void SetSpawnRate(float spawnRate)
    {
        this.spawnRate = (int) spawnRate;
    }

    public void SetDestroyRate(float destroyRate)
    {
        this.destroyRate = (int) destroyRate;
    }

    void Start()
    {
        // initialize object pool by setting a capacity and initializing deactivated gameObjects
        // Note, that this results in a higher loading time at the beginning, since all objects need to be created
        poolObjects = new List<GameObject>(initialPoolSize);
        for (int i = 0; i< initialPoolSize; i++)
            poolObjects.Add(createNewObject());

        // set the cooldown until the next spawn (if autoSpawn is activated)
        timeToNextSpawn = cooldown;

    }

    void Update()
    {
        lastDeltaTime = Time.deltaTime;

        if (autoSpawn) // automatically deactivates/activates new objects everytime the timer hits 0
        {
            timeToNextSpawn -= Time.deltaTime;
            if (timeToNextSpawn < 0)
            {
                // deactivate <objectsToDestroy> objects
                var objectsToDestroy = Mathf.Min(nrOfActiveObjects, destroyRate);
                for (int i = 0; i < objectsToDestroy; i++)
                {
                    
                    DestroyObject(Random.Range(0, nrOfActiveObjects));
                }

                // reactivate <spawnRate> objects
                for (int i = 0; i < spawnRate; i++)
                {
                    SpawnObject();
                }
                timeToNextSpawn = cooldown;
            }
        }
        else
        {
            // everytime we press X, deactivate <objectsToDestroy> objects
            if (Input.GetKeyDown(KeyCode.X))
            {
                var objectsToDestroy = Mathf.Min(nrOfActiveObjects, destroyRate);
                for (int i = 0; i < objectsToDestroy; i++)
                {
                    DestroyObject(Random.Range(0, nrOfActiveObjects));
                }
            }

            // everytime we press S, activate <spawnRate> objects
            if (Input.GetKeyDown(KeyCode.S))
            {
                for (int i = 0; i < spawnRate; i++)
                {
                    SpawnObject();
                }
            }
        }
        
    }

    
    GameObject createNewObject()
    {
        // create a new object, deactivate it and assign its parent transform to the spawner
        var go = Instantiate<GameObject>(objectPrefab);
        go.transform.parent = transform;
        go.SetActive(false);
        return go;
    }

    void IncreasePool()
    {
        // Double the size of the pool, fill empty slots with newly created objects
        // Note, other implementations involve an incremental increase of x elements, to not overshoot to much
        poolObjects.Capacity *= 2;
        for (int i = nrOfActiveObjects; i < poolObjects.Capacity; i++)
        {
            poolObjects.Add(createNewObject());
        }   
    }

    void SpawnObject()
    {
        // in case all pool objects are already in use, resize the pool
        if (nrOfActiveObjects == poolObjects.Capacity)
            IncreasePool();

        // get the first deactivated object and activate it
        var currentGo = poolObjects[nrOfActiveObjects];
        currentGo.SetActive(true);

        // set a new random position
        // draw debug line starting from the previous position to the new one
        var prevPosition = currentGo.transform.position;
        currentGo.transform.position = new Vector3(Random.Range(-3f, 3f), Random.RandomRange(-3f, 3f), 0);
        Debug.DrawLine(prevPosition, currentGo.transform.position, Color.red, cooldown);

        // get a random color from our singleton
        currentGo.GetComponent<SpriteRenderer>().color = Singleton.Instance.getColor();

        // increase active objects counter
        nrOfActiveObjects += 1;
    }

    void DestroyObject(int destroyIndex)
    {
        // deactivate the selected object immediately
        poolObjects[destroyIndex].SetActive(false);

        // swap with last activated object to keep the list sorted
        var tmp = poolObjects[destroyIndex];
        poolObjects[destroyIndex] = poolObjects[nrOfActiveObjects - 1];
        poolObjects[nrOfActiveObjects - 1] = tmp;

        // reduce active objects counter
        nrOfActiveObjects -= 1;
    }
}

