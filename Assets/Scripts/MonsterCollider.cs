using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterCollider : MonoBehaviour {

    public Door door;
    public TextboxManager t_m;
	// Use this for initialization
	void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        //print(t_m.makeStuffHappen);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else if(other.CompareTag("Chill Pill") && t_m.makeStuffHappen)
        {
            door.taps = 1;
            Destroy(this.gameObject);
        }
    }
}
