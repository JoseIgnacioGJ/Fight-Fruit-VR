using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionEscudo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
//Destruimos los objetos que colisionan con el plano, tanto las bombas para que no te resten puntos,
//como las frutas.
   void OnTriggerEnter(Collider other){

       Destroy(other.gameObject);
       Debug.Log(other.gameObject.tag + "golpeada");
       
   }
}
