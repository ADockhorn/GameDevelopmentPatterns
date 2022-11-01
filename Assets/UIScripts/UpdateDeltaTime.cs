using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateDeltaTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI deltaTimeLabel;

    [SerializeField] Toggle usePoolToggle;
    [SerializeField] ObjectPool objectPool;
    [SerializeField] SimpleSpawner simpleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (usePoolToggle.isOn)
        {
            deltaTimeLabel.text = Mathf.Round(objectPool.lastDeltaTime*1000).ToString() + "ms";
        } else
        {
            deltaTimeLabel.text = Mathf.Round(simpleSpawner.lastDeltaTime * 1000).ToString() + "ms";
        }
    }
}
