using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class colisionFrutas : MonoBehaviour
{

    public SCORE score; //Objeto de la clase SCORE
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //Nos aseguramos que las armas no afecten a la cabeza del jugador. En caso contrario esto ocasionaria un error
        //en el programa
        if (other.gameObject.tag != "cabeza")
    {
        //Si el objeto colisionado es una fruta, se aumenta el contador según el tipo de fruta
        if (other.gameObject.tag == "Platano")
        {
            Debug.Log("Platano");
        score.incrementar(20);
          
        }
        else
        {
               if (other.gameObject.tag == "manzana")
                {
                    score.incrementar(30);
                    Debug.Log("manzana");

                }
                else
            {
                if (other.gameObject.tag == "pina")
                {
                    score.incrementar(10);
                    Debug.Log("pina");

                }
                else
                {
                        //Si el objeto colisionado es una bomba, se resta puntos
                        if (other.gameObject.tag == "bomba")
                        {
                            score.decrementar(60);
                            Debug.Log("bomba");

                        }

                    }
            }

        }
            Destroy(other.gameObject); //destruimos el objeto colisionado

            Debug.Log(score.punt().ToString());
        
    }
}

 
}
