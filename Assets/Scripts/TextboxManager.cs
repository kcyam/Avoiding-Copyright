using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour {

    public GameObject textbox;

    public Text text;
  
    public TextAsset textfile;
    public string[] textlines;

    public int currentLine;
    public int endAtLine;

    public PlayerMovement player; //maybe PlayerController?

    public bool isActive;

    public bool stopPlayerMovement;

    public bool makeStuffHappen;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        if (textfile != null)
        {
            textlines = (textfile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textlines.Length - 1;
        }

        if(isActive)
        {
            EnableTextBox();
        }

        else
        {
            DisableTextBox();
        }

        makeStuffHappen = false;
    }

    void Update()
    {

        if(!isActive)
        {
            return;
        }

        text.text = textlines[currentLine];

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) 
        {
            currentLine += 1;
        }

        if(currentLine > endAtLine)
        { 
            DisableTextBox();
            isActive = false;
        }
    }

    public void EnableTextBox()
    {
        textbox.SetActive(true);
        isActive = true;

        if(stopPlayerMovement)
        {
            Time.timeScale = 0;
            player.canMove = false;
        }
    }

    public void DisableTextBox()
    {
        textbox.SetActive(false);
        player.canMove = true;
        Time.timeScale = 1;
        makeStuffHappen = true;
    }

    public void ReloadScript(TextAsset t)
    {
        if(t != null)
        {
            textlines = new string[1];
            textlines = (t.text.Split('\n'));
        }
    }
}
