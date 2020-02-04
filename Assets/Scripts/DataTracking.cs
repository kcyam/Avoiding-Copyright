using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTracking : MonoBehaviour {

    public bool level1 = false; //Sonic chase scene
    public bool level2 = false; //Something with hulk
    public bool level3 = false; //Trivia sounds nice
    public bool level4 = false; //Jumping
    public bool level5 = false; //Stealth probably

    public bool[] levels;

    static DataTracking instance;

    public static DataTracking GetInstance()
    {
        return instance;
    }

    // Use this for initialization
    void Start ()
    {
        levels = new bool[] { level1, level2, level3, level4, level5 };
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        //GameObject.DontDestroyOnLoad(this.gameObject);

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void completeLevel(int s)
    {
        levels[s] = true;
    }

    public bool[] getProgress()
    {
        return levels;
    }
}
