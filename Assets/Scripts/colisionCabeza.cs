using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionCabeza : MonoBehaviour
{
    
    public SCORE score; //Objeto de la clase SCORE
    
    private void OnTriggerEnter(Collider other)
    {
        //Nos aseguramos que las armas no afecten a la cabeza del jugador. En caso contrario esto ocasionaria un error
        //en el programa
        if(other.gameObject.tag != "projectile")
        {
            //Si lo que le ha tocado al jugador es una bomba...
            if (other.gameObject.tag == "bomba")
            {
                score.decrementar(60); //...le restamos puntos...

                Debug.Log(score.punt().ToString());
                //...y destruimos la bomba
                Destroy(other.gameObject);
                Debug.Log("bomba");
            }

        }

    }

}
