<<<<<<< HEAD
﻿using System.Collections;
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
=======
﻿using System.Collections;
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
>>>>>>> 3eca2d77c50576be206f84248e78083dc6c2f363
