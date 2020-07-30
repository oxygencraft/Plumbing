using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public TransformMovement cameraMovement;
    public TransformMovement backgroundMovement;
    public TransformMovement environmentGenMovement;
    public Transform metaballParent;
    public WaterDropper waterDropper;
    public bool mainMenu = false;
    public float timeUntilScoreStart = 3.5f;
    public float scoreUpdateTime = 0.05f;
    public TMP_Text scoreCounter;
    public TMP_Text gameOverScoreCounter;
    public TMP_Text highScoreCounter;
    public TMP_Text gameOverHighScoreCounter;

    private int score = 0;
    private int highScore = 0;
    private Coroutine scoreCoroutine = null;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreCounter.text = highScore.ToString();
        gameOverHighScoreCounter.text = highScore.ToString();
        Invoke("StartScoreCounter", timeUntilScoreStart);
    }

    private void StartScoreCounter()
    {
        scoreCoroutine = StartCoroutine(UpdateScore());
    }

    private IEnumerator UpdateScore()
    {
        for (;;)
        {
            score++;
            scoreCounter.text = score.ToString();
            gameOverScoreCounter.text = score.ToString();
            yield return new WaitForSeconds(scoreUpdateTime);
        }
    }

    public void LoseGame()
    {
        StopCoroutine(scoreCoroutine);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }
        waterDropper.StopAllCoroutines();
        loseUI.SetActive(true);
        backgroundMovement.enabled = false;
        cameraMovement.enabled = false;
        environmentGenMovement.enabled = false;
        foreach (var selfDestruct in FindObjectsOfType<SelfDestruct>())
        {
            if (selfDestruct.gameObject.layer != 9)
                continue;
            Destroy(selfDestruct);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
