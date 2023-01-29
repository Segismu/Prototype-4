using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    ScoreManager scoreManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreManager = FindObjectOfType<ScoreManager>();

        scoreManager.scoreCount = 0;
        scoreManager.isScoreIncreasing = true;
    }

    void Update()
    {
        if(player.transform.position.y < -10)
        {
            scoreManager.isScoreIncreasing = false;
        }
    }
}
