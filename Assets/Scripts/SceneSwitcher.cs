using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
    void OnTriggerEnter()
    {
        if (gameObject.tag == "Main Door")
            SceneManager.LoadScene("TheMainHall");

        else if (gameObject.tag == "HallwayDoor")
            SceneManager.LoadScene("TheHallwayChase");

        else if (gameObject.tag == "Holk Door")
            SceneManager.LoadScene("HolkSmush");

        else if (gameObject.tag == "Pikachu World")
            SceneManager.LoadScene("PikachuMaze");

        else if (gameObject.tag == "Victory")
            SceneManager.LoadScene("Epilogue");
    }
}
