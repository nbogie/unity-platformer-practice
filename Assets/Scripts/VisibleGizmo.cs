using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleGizmo : MonoBehaviour {
    [SerializeField]
    Color gizmoColour = Color.yellow;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColour;
        Gizmos.DrawWireSphere(transform.position, 0.9f);
    }
}
