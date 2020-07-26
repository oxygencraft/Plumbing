using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public TransformMovement cameraMovement;
    public TransformMovement backgroundMovement;
    public TransformMovement environmentGenMovement;
    public Transform metaballParent;
    public WaterDropper waterDropper;
    public bool mainMenu = false;

    public void LoseGame()
    {
        if (mainMenu || cameraMovement == null || backgroundMovement == null || environmentGenMovement == null || loseUI == null)
            return;
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
