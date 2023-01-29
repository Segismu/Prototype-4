using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    GameObject focalPoint;
    public bool hasPowerUP = false;

    public PowerUpType currentPowerUp;
    public GameObject rocketPrefab;

    GameObject tmpRocket;
    Coroutine powerupCountdown;

    [SerializeField] float speed = 10f;
    [SerializeField] float powerUpForce = 15f;
    [SerializeField] GameObject powerUpIndicator;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < -10)
        {
            //Load Game Over Scene
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUP"))
        {
            hasPowerUP = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUP = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 repuseDirection = collision.gameObject.transform.position - transform.position;

        if (collision.gameObject.CompareTag("Enemy") && hasPowerUP)
        {
            enemyRigidbody.AddForce(repuseDirection * powerUpForce, ForceMode.Impulse);
        }
    }
}
