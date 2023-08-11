using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCube1 : MonoBehaviour
{
    //Preparar el salto
    Rigidbody rb;
    public float fuerzaSalto = 10;
    bool floorDetected = false;
    public GameObject bulletCol;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Detección de piso
        Vector3 floor = transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(transform.position, floor, transform.localScale.y + 0.03f))
        {
            floorDetected = true;
        }
        else
        {
            floorDetected = false;
        }

        //Salto
        if (floorDetected)
        {
            rb.AddForce(0, fuerzaSalto, 0);
        }
    }
}
