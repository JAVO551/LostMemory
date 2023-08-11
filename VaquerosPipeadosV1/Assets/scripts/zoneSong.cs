using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneSong : MonoBehaviour
{
    public Vector3 origPosition;

    public GameObject meObj;
    public GameObject obj1;
    public GameObject obj2;

    public AudioSource myAudioSource;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public Transform myTransform;
    public Transform transform1;
    public Transform transform2;

    // Start is called before the first frame update
    void Start()
    {
        origPosition = myTransform.position;

        myAudioSource = GetComponent<AudioSource>();
        audioSource1 = obj1.GetComponent<AudioSource>();
        audioSource2 = obj2.GetComponent<AudioSource>();
}

    // Update is called once per frame
    void Update()
    {

    }

    //En caso de colisión
    void OnCollisionEnter(Collision collision)
    {
        //Colisión con el jugador
        if (collision.gameObject.tag == "playerTag")
        {
            myTransform.position = new Vector3(20000000, -20000000, 20000000);
            transform1.position = obj1.GetComponent<zoneSong>().origPosition;
            transform2.position = obj2.GetComponent<zoneSong>().origPosition; ;

            //audioSource1 = GetComponent<AudioSource>();
            //audioSource2 = GetComponent<AudioSource>();
            audioSource1.Stop();
            audioSource2.Stop();

            myAudioSource.Play();
            myAudioSource.volume = 1;
        }
    }
}
