using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryUnlock : MonoBehaviour
{
    public GameObject myPlayer;
    public int memRequired;
    Vector3 originalLocation;
    // Start is called before the first frame update
    void Start()
    {
        originalLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.GetComponent<PlayerNumbers>().memScore < memRequired)
        {
            //Desaparece objeto
            transform.position = new Vector3(transform.position.x, -20000, transform.position.z);
        }
        else
        {
            //Aparece objeto
            transform.position = originalLocation;
        }
    }
}
