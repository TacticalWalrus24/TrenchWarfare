using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    public Text livesText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
        healthText.text = "Health: " + GameManager.instance.playerHealth;
        livesText.text = "Lives: " + GameManager.instance.playerLives;
    }
}
