using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    Rigidbody enemyRb;
    GameObject player;

    PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
        if (playerController.isPlayerOn == true)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }
        else
        {
            Vector3 lookDirection = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FallDetector"))
        {
            Destroy(gameObject);
        }
    }
}
