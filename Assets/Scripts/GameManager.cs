using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public CameraMovement movement;
    public Transform metaballParent;

    public void LoseGame()
    {
        loseUI.SetActive(true);
        movement.enabled = false;
    }

    public void EndGame()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
