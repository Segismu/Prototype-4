using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator transition;

    PlayerController playerController;
    GameObject player;
    ScoreManager scoreManager;
    SpawnManager spawnManager;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    void Update()
    {

    }

    public void Restart()
    {
        StartCoroutine("RestartGame");
    }

    public IEnumerator RestartGame()
    {
        scoreManager.isScoreIncreasing = false;
        transition.SetTrigger("start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
        scoreManager.scoreCount = 0;
        spawnManager.enemyCount = 0;
        scoreManager.isScoreIncreasing = true;
    }
}
