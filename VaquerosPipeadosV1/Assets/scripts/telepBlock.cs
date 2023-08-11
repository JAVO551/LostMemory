using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telepBlock : MonoBehaviour
{
    public GameObject myPlayer;
    private Transform objetoTransform;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        objetoTransform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nuevaRotacion = objetoTransform.eulerAngles;
        nuevaRotacion.y++;
        objetoTransform.eulerAngles = nuevaRotacion;
        if (nuevaRotacion.y >= 360)
        {
            nuevaRotacion.y = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Colisión con la bala
        if (collision.gameObject.tag == "BulletTag")
        {
            myPlayer.transform.position = transform.position;
            myPlayer.GetComponent<controlFPS>().basePosition = transform.position;
            audioSource.Play();
        }
    }
}
