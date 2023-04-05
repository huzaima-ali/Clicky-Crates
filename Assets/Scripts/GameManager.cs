using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float SpawnRate = 1;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    private int Score;
    public bool isGameActive;
    public Button RestartButton;
    public GameObject TitleScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartGame(int Difficulty)
    {
        isGameActive = true;
        Score = 0;
        SpawnRate /= Difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        TitleScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        ScoreText.text = "Score: " + Score;
    }

    public void GameOver()
    {
        isGameActive = false;
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
