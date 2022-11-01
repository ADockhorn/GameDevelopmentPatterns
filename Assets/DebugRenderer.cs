using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRenderer : MonoBehaviour
{
    void Update()
    {
        // draws a red debug line in scene biew when pressing D
        // the line will vanish after 2.5 seconds
        if (Input.GetKeyDown(KeyCode.D))
            Debug.DrawLine(Vector3.zero, new Vector3(5, 0, 0), Color.red, 2.5f);
    }
}
