using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster: MonoBehaviour
{
    public GameObject bala; //Objeto bala, que es lanzado para destruir los objetos
    public GameObject pivote; //Pivote que se coloca dentro de la pistola y donde aparecen las balas

    //Lista donde se almacenarán todos los dispositivos obtenidos por GetDevices 
    List<InputDevice> devices;
    public XRNode nodo;

    //Almacenará el valor del gatillo si existe en el controlador 
    private float value;

    //Recogemos los dispositivos
    void Start()
    {
        devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(nodo, devices);
    }

    void Update()
    { 
        
        if (devices.Count > 0 ) //Hay dispositivos conectados 
        {
            value=0; //No se ha pulsado ningún botón del mando

            devices[0].TryGetFeatureValue(CommonUsages.trigger, out value); //Está función devuelve un valor en "value"
            Debug.Log("blast: " + value);
        
            if (value != 0 ) //Si se ha pulsado algún botón del mando...
            {
                Disparar(); //...se dispara la bala
                Debug.Log("bala");
            }
        }
        

    }

    //Función que crea una bala dentro de la pistola
    void Disparar()
    {
        Instantiate(bala, pivote.transform.position, pivote.transform.rotation);
    }

  
}