using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public int score = 0;
    public bool isGaming;
    public TMP_Text scoreText;
    public GameObject gameOverPanel;
    public GameObject titlePanel;
    private float spawnRate = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titlePanel.SetActive(false);
        isGaming = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while(isGaming)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void GameOver()
    {
        isGaming = false;
        gameOverPanel.SetActive(true);
    }

    public void UpdateScore(int increment)
    {
        score += increment;
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
