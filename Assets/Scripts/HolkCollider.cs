using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolkCollider : MonoBehaviour {

    public Collider collider1; //head collider
    public Collider collider2; //arms collider
    public Collider collider3; //body collider

    public int health;
    public Collider[] colliders;

    // Use this for initialization
    void Start ()
    {
        health = 10;
        colliders = new Collider[] { collider1, collider2, collider3};
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //void OnCollisionEnter(Collider other)
    //{
        //foreach(ContactPoint contact in other.coll)
        //{

        //}
    //}
}
