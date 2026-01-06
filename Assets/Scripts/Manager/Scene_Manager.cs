using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager Instance { get; private set; }

    void InitializedSceneManager()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        InitializedSceneManager();
        StartScene();
    }

    void StartScene()
    {
        if(SceneManager.GetActiveScene().name == "Scene_Managers")
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }
}
