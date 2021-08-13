using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private GameObject player;

    private Rigidbody enemyRigidBody;
    public float speed = 3.0f;    
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRigidBody.AddForce(lookDirection * speed);

        if(transform.position.y < -8)
            Destroy(gameObject);
    }
}
