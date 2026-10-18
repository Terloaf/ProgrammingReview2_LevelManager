using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseStateTrigger : MonoBehaviour
{
    
    public GameStateManager gameStateManager;
    public LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                
            Destroy(collision.gameObject);
            gameStateManager.Lose();
        }
    }

}

