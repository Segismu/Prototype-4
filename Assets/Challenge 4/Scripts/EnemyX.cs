using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    public SpawnManagerX spawnManagerXscript;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerXscript = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        speed = spawnManagerXscript.enemySpeedInc;
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("PlayerGoal");
        playerGoal = GameObject.Find("Player Goal"); 
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime) ;

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.CompareTag("EnemyGoal"))
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.CompareTag("PlayerGoal"))
        {
            Destroy(gameObject);
        }

    }

}
