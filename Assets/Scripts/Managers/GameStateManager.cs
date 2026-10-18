using NUnit.Framework.Constraints;
using System.Threading;
using UnityEngine;
public enum GameState
{
    Gameplay,
    Paused,
    GameOver
    
}
public class GameStateManager : MonoBehaviour
{
    public LevelManager levelManager;
    public UiManager uiManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();

       
    }
    private void Awake()
    {
        SetState(GameState.Gameplay);
    }


    public GameState currentState {  get; private set; }
    public GameState previousState { get; private set; }

    [Header("Debug (read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;



    private void SetState(GameState state)
    {
        
        if (currentState == state) return;

        previousState = currentState;
        currentState = state;

        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();

        OnGameStateChanged(previousState, currentState);


    }

    private void OnGameStateChanged(GameState previousState, GameState currentState)
    {
        switch(currentState)
        {

            case GameState.Gameplay:
                Time.timeScale = 1;
                uiManager.Unpause();
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                uiManager.ShowPauseScreen();
                break;
            case GameState.GameOver:
                Time.timeScale = 1;
                uiManager.ShowGameOverScreen();
                break;
            default:
                Time.timeScale = 1;
                break;



        }

    }

    public void TogglePause()
    {
        if(currentState == GameState.Paused)
        {
            if (currentState == GameState.Gameplay) return;
            SetState(GameState.Gameplay);
        }
        else if(currentState == GameState.Gameplay)
        {
            if (currentState == GameState.Paused) return;
            SetState(GameState.Paused);
        }
        
    }

    public void Lose()
    {
        SetState(GameState.GameOver);
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
