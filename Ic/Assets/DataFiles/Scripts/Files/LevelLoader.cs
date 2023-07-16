using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Scene scene;

    public void LoadLevel(int level)
    {
        //SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene(level);
    }
}
