using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    private bool shouldMove;

    private bool triggered;

    [SerializeField]
    private float maxDistanceDelta;

    [SerializeField]
    private Transform position1 = null;
    [SerializeField]
    private Transform position2 = null;

    private Transform destination;
    private Transform comingFrom;
    private float totalDistance;

    void Start()
    {
        shouldMove = false;
        destination = position2;
        comingFrom = position1;

    }
    void SetToFartherDestination()
    {
        if (Vector2.Distance(transform.position, position2.position) > Vector2.Distance(transform.position, position1.position))
        {
            destination = position2;
            comingFrom = position1;
        }
        else
        {
            destination = position1;
            comingFrom = position2;
        }
    }

    void Update()
    {
        if (shouldMove)
        {
            Vector2 newPos = Vector2.MoveTowards(transform.position, destination.position, maxDistanceDelta);
            transform.position = newPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("PlatformDestination"))
        {
            SetToFartherDestination();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p)
        {
            if (!triggered)
            {

                p.gameObject.transform.SetParent(transform);
                shouldMove = true;
                triggered = true;
            }
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {

        Player p = collision.gameObject.GetComponent<Player>();
        if (p)
        {
            if (triggered)
            {
                p.gameObject.transform.SetParent(null);
                shouldMove = false;
                triggered = false;
            }
        }
    }


}
