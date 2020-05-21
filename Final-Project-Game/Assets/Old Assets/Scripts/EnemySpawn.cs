 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int numberOfEnemies = 1;

    public GameObject[] waypoints;

    public GameObject enemySpawn;

    private bool randomWayFinding = false;
    public GameObject uiCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            randomWayFinding = !randomWayFinding;
            uiCounter.GetComponent<UITracking>().PathChange();
        }

        //Makes sure there are 10 enemies on the screen at all times
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < numberOfEnemies)
        {
            //When a new enemy is spawned
            GameObject enemy = Instantiate<GameObject>(enemySpawn);

            WayFinding enemyWayFinding = enemy.GetComponent<WayFinding>();

            //will follow the same flight behavior as the others
            enemyWayFinding.randomWayFinding = randomWayFinding;

            //will have the same list of waypoints
            enemyWayFinding.waypoints = waypoints;

            //will choose a random waypoint to start at
            enemyWayFinding.lastWaypoint = Random.Range(0, waypoints.Length);

            //will choose a random start position within the game bounds
            //Kind of rough would like to improve
            Vector2 randomVector = new Vector2(Random.Range(-70,70),Random.Range(-40,40));
            enemy.transform.position = randomVector;
        }

    }
}
