using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text;

public class TIMER : MonoBehaviour
{
    public Text time; //Texto que indica el tiempo que falta para terminar la partida
    public Text GameOver; //Texto que indica que el juego ha terminado

    private float t = 60f; //Temporizador de la partida
    private float reinicio = 10f; //Temporizador del reinicio

    private string nextScene; //Texto que indica qué escena se debe cargar al acabar el reinicio

    //Ponemos en marcha el juego
    void Start() 
    {
        time.text = "TIME: " + t.ToString("f0");
        GameOver.enabled = false; //Ocultamos el mensaje de final de partida

        
    }

    //Función que devuelve el temporizador de la partida
    public float getTiempo() 
    {
        return t;
    }

    void Update()
    {
        
        t -= Time.deltaTime; //Decrementamos el tiempo del juego


        if (t <= 0f) //Si se acaba el tiempo...
        {
            t = 0f; //...el temporizador termina...
            GameOver.enabled = true; //...al igual que el juego

            //Y ponemos en marcha el tiempo de reinicio
            reinicio -= Time.deltaTime;
            time.text = "REINICIO EN " + reinicio.ToString("f0");

            //En cuanto el reinicio termine, ponemos de nuevo el juego en marcha, cargando la misma escena
            //con los mismos componentes y valores anteriores
            if (reinicio <= 0f){
                nextScene = "JUEGO";
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(nextScene);
                
            }
            Debug.Log("GAME OVER");
            
        }
        else //Si el juego aún continua...
        {
            time.text = "TIME: " + t.ToString("f0"); //... mostramos el tiempo que queda
        }
        

    }
}
