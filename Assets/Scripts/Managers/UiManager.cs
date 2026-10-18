using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseCanvas;
    private Canvas gameOverCanvas;

    private void Awake()
    {

        pauseCanvas = GameObject.Find("PauseScreen").GetComponent<Canvas>();
        pauseCanvas.enabled = false;
        gameOverCanvas = GameObject.Find("GameOverScreen").GetComponent<Canvas>();
        
        gameOverCanvas.enabled = false;
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
}
