using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PointerMove : MonoBehaviour
{
    public Transform pointer;
    public Transform pointerStart;
    public Transform pointerEnd;

    public float laju = 1f;
    int direction = 1;

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        pointer.position = Vector2.MoveTowards(pointer.position, target, laju);

        float jarak = (target - (Vector2)pointer.position).magnitude;

        if( jarak <= 0.1f)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if(direction == 1)
        {
            return pointerStart.position;
        }
        else
        {
            return pointerEnd.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (pointer != null && pointerStart != null && pointerEnd != null)
        {
            Gizmos.DrawLine(pointer.transform.position, pointerStart.position);
            Gizmos.DrawLine(pointer.transform.position, pointerEnd.position);
        }
    }
}
