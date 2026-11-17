
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseCanvas;
    private Canvas gameOverCanvas;
    [SerializeField]
    private Canvas interactableUI;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeSceneObjects();
    }
    private void InitializeSceneObjects()
    {
        if (SceneManager.GetActiveScene().name != "Level1") return;
        pauseCanvas = GameObject.Find("PauseScreen").GetComponent<Canvas>();
        pauseCanvas.enabled = false;
        gameOverCanvas = GameObject.Find("GameOverScreen").GetComponent<Canvas>();
        interactableUI = GameObject.Find("InteractableUi").GetComponent<Canvas>();
        gameOverCanvas.enabled = false;
        interactableUI.enabled = false;
    }
    public void ShowPauseScreen()
    {

        if (pauseCanvas == null) return;
        pauseCanvas.enabled = true;
    }

    public void Unpause()
    {

        if (pauseCanvas == null) return;
         pauseCanvas.enabled = false;
    }

    public void ShowGameOverScreen()
    {

        gameOverCanvas.enabled = true;
        Destroy(pauseCanvas.gameObject);
        
    }

    public void ShowInteractionUI()
    {

        interactableUI.enabled = true;

    }
    public void HideInteractionU()
    {
        if(interactableUI!= null)
        interactableUI.enabled = false;
    }
}
