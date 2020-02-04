using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTrigger : MonoBehaviour {

    public AudioSource audio_source;
	// Use this for initialization
	void Start ()
    {
        audio_source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Hello");
        if (other.CompareTag("Player") && Input.GetKeyDown("e"))
        {
            //Debug.Log("hey");
            audio_source.Play();
        }
    }
}
