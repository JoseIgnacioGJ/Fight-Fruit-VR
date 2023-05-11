using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureExample : MonoBehaviour
{
    public GestureSourceManager source;
    public GameObject shield;

    private bool lastShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool gShield = source.getGesture("hacer_escudo") || Input.GetButton("Fire2");
   

        if (shield != null)
            shield.SetActive(gShield);

      
    }

}
