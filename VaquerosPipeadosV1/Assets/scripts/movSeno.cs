using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movSeno : MonoBehaviour
{
    private float sinVal;
    // Start is called before the first frame update
    void Start()
    {
        sinVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (sinVal < 3.1416 * 2)
        {
            sinVal = sinVal + 0.05f;
        }
        else
        {
            sinVal = 0;
        }
        transform.position = transform.position + new Vector3(0, Mathf.Sin(sinVal), 0) * 0.01f;
    }
}
