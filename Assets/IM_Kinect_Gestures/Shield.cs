using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int id = 0;

    public UnityEngine.UI.Text label;
    
    void OnCollisionEnter(Collision col) {
        Bullet b = col.gameObject.GetComponentInParent<Bullet>();
        if ((b != null) && (b.id == id)) {
            Destroy(b.gameObject,0.2f);
            b.speed = 0.0f;
            GetComponent<AudioSource>().Play();

            int cont = 0;
            int.TryParse(label.text, out cont);
            cont ++;
            label.text = cont.ToString();
        }
    }
}
