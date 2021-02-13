using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    // this is the prefab object containing the waypoints
    [SerializeField] GameObject path;
    public float moveSpeed = 2f;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // we need to access the individual waypoint as a child of the linked prefab object
        this.transform.position = path.transform.GetChild(waypointIndex).transform.position;

        print("ship position " + this.transform.position);
        Debug.Log("waypoint position" + this.transform.position);
        print("n. waypoints " + path.transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {
        // check enemy didn't reach last waypoint yet
        if (waypointIndex < path.transform.childCount)
        {
            // target position. NOTE: using the 'var' keyword let's Unity select the appropriate type for us
            var targetPosition = path.transform.GetChild(waypointIndex).transform.position;

            // actual speed, to make it from independent
            float move = moveSpeed * Time.deltaTime;
            // now move
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, move);
            // check whether we reached a waypoint. If so, increment counter
            if (transform.position == targetPosition)
            { waypointIndex++; }
        }
    }
}
