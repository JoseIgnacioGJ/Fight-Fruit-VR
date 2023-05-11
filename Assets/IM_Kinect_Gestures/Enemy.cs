using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxDist = 2.0f;
    public float velocity = 1.0f;

    public GameObject bulletPrefab;
    public float bulletTime = 1.2f;
    public float bulletRandomAngle = 10;

    public float bulletVelocity = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot",1,bulletTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localPosition;
        p.x = Mathf.Sin(Time.time * velocity * Mathf.PI) * maxDist; 
        transform.localPosition = p;
    }

    void Shoot() 
    {
        GameObject b = Instantiate(
            bulletPrefab, 
            transform.position, 
            transform.rotation * Quaternion.Euler(0,Random.Range(-bulletRandomAngle, bulletRandomAngle),0));

        b.GetComponent<Bullet>().speed = bulletVelocity;

        Destroy(b, 10);
    }

}
