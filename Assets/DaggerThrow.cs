using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerThrow : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    public PlayerStats stats;
    public float spawnDistance;
    public float throwingForce;
    public float angleMin;
    public float angleMax;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomCircle(player.transform.position, spawnDistance);
        transform.LookAt(player.transform);
        Throw();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.angularVelocity = Vector3.zero;
            transform.position = RandomCircle(player.transform.position, spawnDistance);
            transform.LookAt(player.transform);
            Throw();
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.Range(angleMin, angleMax);
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.y = center.y+5f;
        return pos;
    }

    void Throw()
    {
        rb.velocity = transform.forward * (throwingForce + stats.score);
    }
}
