using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

    public void MenuLoad()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
