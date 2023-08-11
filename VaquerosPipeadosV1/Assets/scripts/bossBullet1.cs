using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet1 : MonoBehaviour
{
    int myTime = 300;
    float nativeX;
    float nativeY;
    float nativeZ;

    // Start is called before the first frame update
    void Start()
    {
        nativeX = Random.Range(-0.12f, 0.12f);
        nativeY = Random.Range(0.09f, 0.13f);
        nativeZ = Random.Range(-0.12f, 0.12f);
    }

    // Update is called once per frame
    void Update()
    {
        if (myTime > 100)
        {
            transform.position += new Vector3(nativeX, nativeY, nativeZ);
        }

        if (myTime < 100)
        {
            transform.position += new Vector3(0, -0.15f, 0);
        }

        if (transform.position.y < -60)
        {
            Destroy(gameObject);
        }

        myTime--;
    }
}
