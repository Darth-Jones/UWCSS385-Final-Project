using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayFinding : MonoBehaviour
{

    public GameObject[] waypoints;

    public bool randomWayFinding = false;

    public bool waypointMode = true;

    public float turnRate = 5f;

    public int lastWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            randomWayFinding = !randomWayFinding;

        if (waypointMode)
            TurnTowardsWaypoint();
    }

    //Chooses the next waypoint based on the last waypoint or if randomWayFinding is
    //true choose the next point randomly
    private GameObject ChooseNextWaypoint()
    {

        int numOfWaypoints = waypoints.Length;
        //checks to see if the length is not 0 indicating a empty array of waypoints
        if (numOfWaypoints > 0) {
            if (randomWayFinding)
            {
                int randWaypoint = Random.Range(0, numOfWaypoints);

                Debug.Log("Random #: " + randWaypoint);

                lastWaypoint = randWaypoint;

                return waypoints[randWaypoint];
            }
            else
            {
                int nextWaypoint;

                if (lastWaypoint == numOfWaypoints - 1)
                    nextWaypoint = 0;
                else
                    nextWaypoint = lastWaypoint + 1;

                lastWaypoint = nextWaypoint;

                return waypoints[nextWaypoint];
            }

        }
        return null;
    }

    //
    private void TurnTowardsWaypoint()
    {
        //Makes sure there are waypoints in the array or gives an debug error
        if (waypoints.Length == 0)
        {
            Debug.Log("No Waypoints Entered");
            return;
        }

        Vector2 pos = gameObject.transform.position;

        Vector2 posWaypoint = waypoints[lastWaypoint].transform.position;

        float distance = Vector2.Distance(pos, posWaypoint);

        if (distance < 2)
            posWaypoint = ChooseNextWaypoint().transform.position;

        Vector2 vec = posWaypoint - pos;

        transform.up = Vector2.LerpUnclamped(transform.up,vec,turnRate * Time.smoothDeltaTime);
    }
    
}
