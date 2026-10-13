using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinStateTrigger : MonoBehaviour
{
    public UiManager uiManager;

    private int currentScene;
    private int nextScene;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);

            
        }
    }

}
