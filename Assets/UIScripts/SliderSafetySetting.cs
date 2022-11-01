using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSafetySetting : MonoBehaviour
{
    [SerializeField] Slider destroyRate;
    [SerializeField] Slider spawnRate;

    public void setSafeDestroyValue(float value)
    {
        destroyRate.value = Mathf.Max(spawnRate.value, destroyRate.value);
    }

    public void setSafeSpawnValue(float value)
    {
        spawnRate.value = Mathf.Min(spawnRate.value, value);
    }
}
