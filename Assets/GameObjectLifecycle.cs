using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectLifecycle : MonoBehaviour
{
    [SerializeField] int field;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("Enable");
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    private void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    private void Reset()
    {
        Debug.Log("Reset");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
    }

    private void OnApplicationPause(bool pause)
    {
        Debug.Log("OnPause " + pause.ToString()) ;
    }

    private void OnApplicationQuit()
    {
        Debug.Log("OnQuit");
    }

    private void OnValidate()
    {
        Debug.Log("OnValidate");
    }

    private void OnApplicationFocus(bool focus)
    {
        Debug.Log("OnFocus " + focus.ToString());
    }
}
