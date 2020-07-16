using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public TransformMovement movement;
    public Transform metaballParent;
    public MetaballManager metaballManager;
    public bool mainMenu = false;

    public void LoseGame()
    {
        if (mainMenu || movement == null || loseUI == null)
            return;
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
