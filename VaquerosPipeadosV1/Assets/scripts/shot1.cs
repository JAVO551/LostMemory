using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot1 : MonoBehaviour
{
    public float bulletTime = 0.2f;
    public GameObject bulletPath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject,bulletTime);
        //Pruebas de la bala
        //Instantiate(bulletPath, transform.position, Quaternion.identity);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
