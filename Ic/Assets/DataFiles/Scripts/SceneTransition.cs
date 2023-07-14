using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void LoadOpenScene() //give any name 
    {
        SceneManager.LoadScene("OpenScreen");
    }
   
    public void ExitApp()
    {
        Application.Quit();
        Debug.Log("You have quit the app");
    }

    public void LoadIntro1()
    {
        SceneManager.LoadScene("Intro_Page1");
    }

    public void LoadIntro2()
    {
        SceneManager.LoadScene("Intro_Page2");
    }
    public void LoadIntro3()
    {
        SceneManager.LoadScene("Intro_Page3");
    }
    public void LoadIntro4()
    {
        SceneManager.LoadScene("Intro_Page4");
    }
    public void LoadIntro5()
    {
        SceneManager.LoadScene("Intro_Page5");
    }
    public void LoadIntro6()
    {
        SceneManager.LoadScene("Intro_Page6");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadMainMenuAR()
    {
        SceneManager.LoadScene("MainMenuAR");
    }

    public void LoadInstruction()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadDefinition()
    {
        SceneManager.LoadScene("Definitions");
    }

}
