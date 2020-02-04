using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolkMove : MonoBehaviour {

    public Transform player;
    int MoveSpeed = 6;
    int MaxDist = 10;
    int MinDist = 1;
    public TextboxManager t_m;
    

    // Use this for initialization
    void Start ()
    {

    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (t_m.makeStuffHappen)
        {
            transform.LookAt(player);

            if (Vector3.Distance(transform.position, player.position) >= MinDist)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;


            }
        }
	}
}
