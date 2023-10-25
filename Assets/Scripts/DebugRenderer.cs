using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRenderer : MonoBehaviour
{
    void Update()
    {
        // We can draw lines for debugging purposes, e.g. visualizing the current view direction.
        // Press Space while the game is running to see the lines.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.DrawLine(Vector3.zero, new Vector3(1, 1, 0), Color.red, 2.5f);
            Debug.DrawLine(Vector3.zero, new Vector3(1,-1, 0), Color.red, 2.5f);
            Debug.DrawLine(Vector3.zero, new Vector3(-1, 1, 0), Color.red, 2.5f);
            Debug.DrawLine(Vector3.zero, new Vector3(-1, -1, 0), Color.red, 2.5f);
        }
    }

    private void OnDrawGizmos()
    {
        // This function will draw gizmos in the scene view.
        // They are only visible in play mode in case you activated the "Gizmos" option
        // in the top right of the Game tab. They won't be part of the final build.
        Vector2 position = transform.position;
        Vector2 direction = transform.right;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, position - direction);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(position, position + direction);
    }

    private void OnDrawGizmosSelected()
    {
        // This function will draw gizmos in the scene view as long as the object is selected.
        // They are only visible in play mode in case you activated the "Gizmos" option
        // in the top right of the Game tab. They won't be part of the final build.
        Vector2 position = transform.position;
        Vector2 direction = transform.right;

        Gizmos.color = Color.red;
        Gizmos.DrawCube(position - direction, new Vector3(0.1f, 0.1f, 0.1f));

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(position + direction, 0.1f);
    }
}
