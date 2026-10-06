using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentLevel;
    private int nextLevel;

    private int totalScenes;
    private static LevelManager instance;

    //private void Awake()
    //{
    //    if (instance != null && instance != this)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    //private void Update()
    //{
    //    currentLevel = SceneManager.GetActiveScene().buildIndex;
    //    totalScenes = SceneManager.sceneCountInBuildSettings - 1;

    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        nextLevel = currentLevel + 1;

    //        if (nextLevel < SceneManager.sceneCountInBuildSettings)
    //        {
    //            SceneManager.LoadScene(nextLevel);
    //        }
    //        else
    //        {
    //            SceneManager.LoadScene(0);
    //        }
    //    }

    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        SceneManager.LoadScene(0);
   
    //    }
        


    //}

    public void LoadLevel(int level)
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        nextLevel = level;

        SceneManager.LoadScene(nextLevel);
        return;
    }
}
