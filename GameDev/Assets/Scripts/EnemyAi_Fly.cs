using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(AIPath))]
[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(AIDestinationSetter))]
public class EnemyAi_Fly : MonoBehaviour
{

    AIPath path;
    AIDestinationSetter destinationSetter;
    Transform target;
    public Transform graphics;
    public float nextWayPointDistance;
    public float maxSpeed;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        path = GetComponent<AIPath>();
        path.orientation = OrientationMode.YAxisForward;
        path.gravity = new Vector3(0, 0, 0);
        path.updateRotation = false;
        path.pickNextWaypointDist = nextWayPointDistance;
        path.maxSpeed = maxSpeed;
        destinationSetter = GetComponent<AIDestinationSetter>();
        
    }

   

   

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) < distance)
        {
            destinationSetter.target = target;
        }
        else
        {
            destinationSetter.target = null;
        }



        if(path.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (path.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
