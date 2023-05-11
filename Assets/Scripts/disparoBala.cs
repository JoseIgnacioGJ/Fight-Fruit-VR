using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoBala : MonoBehaviour
{
    void Start()
    {
        
    }

    // Función que mueve la bala al dispararse
    void Update()
    {
        // 22 VELOCIDAD
        transform.Translate(Vector3.forward * 22.0f * Time.deltaTime);

    }
}
