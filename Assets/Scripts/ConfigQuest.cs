using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigQuest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Configuración de Oculus Quest
        UnityEngine.XR.XRDevice.SetTrackingSpaceType(UnityEngine.XR.TrackingSpaceType.RoomScale);
    }

}
