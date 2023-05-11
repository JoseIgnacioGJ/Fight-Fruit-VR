using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCORE : MonoBehaviour
{
    public Text score; //Texto que indica la puntuación
    public int puntuacion = 0; //Contador de puntos
    public TIMER tiempo; //Objeto de la clase TIMER
    
    //Mostramos la puntuación a 0
    void Start()
    {
        score.text = " " + puntuacion;
    }

    //Función que devuelve la puntuación del jugador
    public int punt()
    {
        return puntuacion;
    }

    //Función que muestra los puntos por pantalla
    void Update()
    {
        score.text = "SCORE: " + puntuacion.ToString("f0"); 
    }

    //Función que aumenta la puntuación, si el juego aún continua. Esta función se asocia 
    //a las frutas y a las bombas
    public void incrementar(int puntos)
    {
        if (tiempo.getTiempo() > 0)
            puntuacion += puntos;
    }

    //Función que disminuye la puntuación, si el juego aún continua. Esta función se asocia 
    //a las frutas y a las bombas
    public void decrementar(int puntos)
    {
        if (tiempo.getTiempo() > 0)
        {
            if (puntuacion - puntos >= 0) //Al descontar los puntos, el valor es positivo
                puntuacion -= puntos;
            else                          //Al descontar los puntos, el valor es negativo
                puntuacion = 0;
        }
            
    }
}
