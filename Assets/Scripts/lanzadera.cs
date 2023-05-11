using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzadera : MonoBehaviour
{
    public GameObject fruta; //objetos que se crean/lanzan
    private float tiempo; //contador de tiempo

    public float LimiteTiempo; //ttiempo que tarda en generarse cada objeto

    public float fuerzaDisparo = 1000; //fuerza por defecto con la que se impulsan los objetos

    // Start is called before the first frame update
    void Start()
    {

    }

    // Creamos las frutas cada X tiempo / variable limiteTiempo
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo > LimiteTiempo) //si pasa el tiempo de espera...
        {
            tiempo = 0;
            // Instanciar fruta
            GameObject frutaobj = Instantiate(fruta, transform.position = transform.position + new Vector3(0, 0, 0), Quaternion.identity);

            // Aplicar fuerza en la dirección forward de lanzadera
            Rigidbody rb = frutaobj.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * fuerzaDisparo,ForceMode.Acceleration);
        }



    }
}