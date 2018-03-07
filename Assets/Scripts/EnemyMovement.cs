using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target; // The position we want to move to.
    private Enemy enemy; // The enemy script that belongs to this enemy.

    private int waypointIndex = 0;
   
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        //transform.rotation = Quaternion.LookRotation(dir);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            GetNextWaypoint();

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesKilled++;
        Destroy(gameObject);
    }
}
