using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFlickering : MonoBehaviour
{

    public Material[] material;
    public static int timer;
    CanvasRenderer crend;

    void Start()
    {
        crend = GetComponent<CanvasRenderer>();
        crend.SetMaterial(material[0],0);

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        if (timer > 300)
        {
            if (timer % 360 >= 330 || (timer % 360 < 50 && timer % 360 > 30))
            {
                crend.SetMaterial(material[0], 0);
                print("yes");
            }



            else
            {
                crend.SetMaterial(material[1], 0);
                print("no");
            }
        }


    }
        
}
