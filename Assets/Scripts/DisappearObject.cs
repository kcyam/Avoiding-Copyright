using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearObject : MonoBehaviour {

    public bool canBeDestroyed;
    public TextboxManager t_m;
    public Door door;


    // Use this for initialization
    void Start ()
    {
        t_m = FindObjectOfType<TextboxManager>();
        canBeDestroyed = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        canBeDestroyed = t_m.makeStuffHappen;

    }

    void OnTriggerStay(Collider other)
    {
        //print(other.tag);
        if(canBeDestroyed && other.CompareTag("Player"))
        {
            door.taps = 40;
            Destroy(gameObject);
        }
    }
}
