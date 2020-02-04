using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateText : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextboxManager theTextBox;

    public bool requireClick;
    private bool waitForPress;

    public bool destroyWhenFinished;

    public bool makeStuffHappen;

	// Use this for initialization
	void Start ()
    {
        theTextBox = FindObjectOfType<TextboxManager>();
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(waitForPress && (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenFinished)
            {
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            if(requireClick)
            {
                waitForPress = true;
                return;
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenFinished)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            waitForPress = false;
        }
    }
}
