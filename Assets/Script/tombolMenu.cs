using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tombolMenu : MonoBehaviour {
    
    public void GotoSimulasi()
    {
        SceneManager.LoadScene("Simulasi");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GotoTentang()
    {
        SceneManager.LoadScene("Tentang");
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
