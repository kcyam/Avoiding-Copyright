using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    public Transform canvas;
    public Transform player;
    public Transform pauseMenu;
    public Transform controlsMenu;

	

	// Update is called once per frame
	void Update ()
    {


	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }	
	}

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
            {
                print("Pause");
                Cursor.visible = true;
                pauseMenu.gameObject.SetActive(true);
                controlsMenu.gameObject.SetActive(false);
            }

            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<MouseLook>().enabled = false;
        }

        else
        {
            canvas.gameObject.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
            player.GetComponent<MouseLook>().enabled = true;
        }
    }

    public void Controls(bool Open)
    {
        if(Open)
        {
            controlsMenu.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
        }

        if(!Open)
        {
            controlsMenu.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 1;
        player.GetComponent<MouseLook>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMainMenu()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 1;
        player.GetComponent<MouseLook>().enabled = true;
        SceneManager.LoadScene("Main Menu");
    }
}
