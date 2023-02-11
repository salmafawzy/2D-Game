using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoints;
    private int cwpi = 0;
    [SerializeField] private float speed = 2f;
    
    private void Update()
    {
        if(Vector2.Distance(Waypoints[cwpi].transform.position,transform.position)< .1f)
        {
            cwpi++;
            if (cwpi >= Waypoints.Length)
            {
                cwpi = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[cwpi].transform.position, Time.deltaTime * speed);
    }
}
