using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePoolToggle : MonoBehaviour
{
    [SerializeField] GameObject poolSpawner;
    [SerializeField] GameObject simpleSpawner;
   
    public void togglePool(bool toggleValue)
    {
        poolSpawner.SetActive(toggleValue);
        simpleSpawner.SetActive(!toggleValue);
    }
}
