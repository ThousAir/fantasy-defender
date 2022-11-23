using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public List<Vector2> wayPoints = new List<Vector2>();
    public static List<Vector2> staticWaypoint;
    private void Awake()
    {
        staticWaypoint = wayPoints;
    }

    private void OnDrawGizmos()
    {
        foreach (var item in wayPoints)
        {
            Gizmos.DrawSphere(item, 0.2f);
        }
    }
}
