using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wasp : MonoBehaviour
{
    [SerializeField]
    private float maxDistanceDelta;

    [SerializeField]
    private float damage;

    [SerializeField]
    private List<Transform> waypoints;


    private SpriteRenderer renderer;

    private Vector2 destination;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        PickNewDestination();
    }

    private void PickNewDestination()
    {
        if (waypoints.Count < 1)
        {
            throw new UnityException("No Waypoints for wasp");
        }
        Transform waypoint = waypoints[Random.Range(0, waypoints.Count)];
        if (!waypoint)
        {
            throw new UnityException("Null waypoiint in wasp's waypoints");
        }
        destination = waypoint.position;
        renderer.flipX = (destination.x > transform.position.x);
    }

    void Update()
    {
        if (IsAtDestination())
        {
            PickNewDestination();
        }
        transform.position = Vector2.MoveTowards(transform.position, destination, maxDistanceDelta);
    }

    private bool IsAtDestination()
    {
        return (Vector2.Distance(transform.position, destination) < 0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.TakeDamage(damage);
            //Destroy(gameObject);
        }
    }
}

