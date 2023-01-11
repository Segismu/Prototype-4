using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    Rigidbody enemyRb;
    GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
        enemyRb.AddForce ((player.transform.position - transform.position).normalized * speed);
    }
}
