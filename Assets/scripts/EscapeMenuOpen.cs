using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenuOpen : MonoBehaviour
{
    public GameObject GameMenuCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    public void SetMenuOff()
    {
        GameMenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
