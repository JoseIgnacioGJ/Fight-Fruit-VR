using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System;
using System.Text;

public class Voz : MonoBehaviour
{
    //Palabras que el jugador puede decir
    public string[] palabras = new string[] { "espada", "pistola"};

    public ConfidenceLevel umbral = ConfidenceLevel.Medium;
    protected KeywordRecognizer recognizer;

    //Comprobadores de si hay armas en las manos
    Boolean izq_pis = false, der_pis = true, izq_esp = true, der_esp = false;

    //Se crean 4 armas para que el usuario use dos armas del mismo tipo en ambas manos
    public GameObject pistola_izq, pistola_der;
    public GameObject espada_izq, espada_der;

    //Las manos del jugador
    public GameObject cubo_izq;
    public GameObject cubo_der;

    //Lista donde se almacenarán todos los dispositivos obtenidos por GetDevices
    List<InputDevice> devicesIzq, devicesDer;
    public XRNode nodo;

    private float valueIzq, valueDer; //Almacenará el valor del gatillo si existe en el controlador
    
    void Start()
    {
        pistola_izq.SetActive(izq_pis);
        pistola_der.SetActive(der_pis);
        espada_izq.SetActive(izq_esp);
        espada_der.SetActive(der_esp);
        //Cogemos una pistola
        if (izq_pis)
        {
            pistola_izq.SetActive(true);
        }
        else
        {
            if (der_pis)
            {
                pistola_der.SetActive(true);
            }
        }

        //Cogemos una espada
        if (izq_esp)
        {
            espada_izq.SetActive(true);
        }
        else
        {
            if (der_esp)
            {
                espada_der.SetActive(true);
            }
        }

        //Dispositivos izquierdos y derechos
        devicesIzq = new List<InputDevice>();
        devicesDer = new List<InputDevice>();

        //Devuelve todos los dispositivos que cumplan las especificaciones de las manos
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devicesIzq);
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devicesDer);

        //El jugador ha dicho algo
        if (palabras != null)
        {
            recognizer = new KeywordRecognizer(palabras, umbral);
            recognizer.OnPhraseRecognized += PalabraReconocida;
            recognizer.Start();
        }
    }

    private void PalabraReconocida(PhraseRecognizedEventArgs args)
    {
        //Palabra recogida
        switch (args.text)
        {
            case "espada":

                //Decidimos leer los dos mandos
                if (devicesIzq.Count > 0 || devicesDer.Count > 0)
                {
                    valueIzq = 0;
                    valueDer = 0;

                    //Comprobamos si se ha pulsado el botón grip
                    devicesIzq[0].TryGetFeatureValue(CommonUsages.grip, out valueIzq);
                    devicesDer[0].TryGetFeatureValue(CommonUsages.grip, out valueDer);

                    Debug.Log("MANDO IZQUIERDA: " + valueIzq);
                    Debug.Log("MANDO DERECHA: " + valueDer);

                    //Si se ha dicho la palabra por el mando izquierdo...
                    if (valueIzq != 0)
                    {
                        //Si tiene una pistola,...
                        if (izq_pis)
                        {
                            //...se la quitamos...
                            pistola_izq.SetActive(false);
                            izq_pis = false;

                            //...y le añadimos la espada
                            izq_esp = true;
                            espada_izq.SetActive(true);
                        }

                        
                        Debug.Log("ESPADA IZQUIERDA");
                    }
                    else
                    {
                        //Si se ha dicho la palabra por el mando derecho...
                        if (valueDer != 0)
                        {
                            //Si tiene una pistola,...
                            if (der_pis)
                            {
                                //...se la quitamos...
                                pistola_der.SetActive(false);
                                der_pis = false;

                                //...y le añadimos la espada
                                der_esp = true;
                                espada_der.SetActive(true);
                            }

                           
                            Debug.Log("ESPADA DERECHA");
                        }
                    }
                }
                break;

            case "pistola":

                //Decidimos leer los dos mandos
                if (devicesIzq.Count > 0 || devicesDer.Count > 0)
                {
                    valueIzq = 0;
                    valueDer = 0;

                    //Comprobamos si se ha pulsado el botón grip
                    devicesIzq[0].TryGetFeatureValue(CommonUsages.grip, out valueIzq);
                    devicesDer[0].TryGetFeatureValue(CommonUsages.grip, out valueDer);

                    Debug.Log("MANDO IZQUIERDA: " + valueIzq);
                    Debug.Log("MANDO DERECHA: " + valueDer);

                    //Si se ha dicho la palabra por el mando izquierdo...
                    if (valueIzq != 0)
                    {
                        //Si tiene una espada,...
                        if (izq_esp)
                        {
                            //...se la quitamos...
                            espada_izq.SetActive(false);
                            izq_esp = false;

                            //...y le añadimos la pistola
                            izq_pis = true;
                            pistola_izq.SetActive(true);
                        }

                       
                        Debug.Log("PISTOLA IZQUIERDA");
                    }
                    else
                    {
                        //Si se ha dicho la palabra por el mando derecho...
                        if (valueDer != 0)
                        {
                            //Si tiene una espada,...
                            if (der_esp)
                            {
                                //...se la quitamos...
                                espada_der.SetActive(false);
                                der_esp = false;

                                //...y le añadimos la pistola
                                der_pis = true;
                                pistola_der.SetActive(true);
                            }

                            
                            Debug.Log("PISTOLA DERECHA");
                        }
                    }
                }
                break;


        }


    }

}