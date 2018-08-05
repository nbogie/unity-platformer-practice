using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float timeToStopShaking;

    [SerializeField]
    private float shakeRadius;

    void Start()
    {
        timeToStopShaking = 0;
    }

    public void StartToShake(float duration)
    {
        if (StillShaking())
        {
            return;
        }
        timeToStopShaking = Time.realtimeSinceStartup + duration;
    }

    bool StillShaking()
    {
        return (timeToStopShaking > Time.realtimeSinceStartup);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartToShake(2f);
        }

        if (timeToStopShaking > Time.realtimeSinceStartup)
        {
            Vector2 vec = Random.insideUnitCircle * shakeRadius;
            transform.position = (Vector3)(transform.position + new Vector3(vec.x, vec.y, 0));
        }

    }
}
