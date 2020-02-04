using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicAnimation : MonoBehaviour {

    public Material[] material;
    Renderer rend;
    public static int timer;

    public TextboxManager t_m;
	
	void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        timer = 0;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (t_m.makeStuffHappen)
        {
            timer += 1;

            if (timer % 4 == 0 || timer % 4 == 2)
                rend.sharedMaterial = material[0];

            else if (timer % 4 == 1)
                rend.sharedMaterial = material[1];
            else if (timer % 4 == 3)
                rend.sharedMaterial = material[2];
        }
    }
}
