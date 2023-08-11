using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memSoundManager : MonoBehaviour
{
    public GameObject myPlayer;
    float myVal1 = 0;
    float myVal2 = 0;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        myVal1 = myPlayer.GetComponent<PlayerNumbers>().memScore;
        if (myVal1 !=  myVal2)
        {
            audioSource.Play();
        }
        myVal2 = myVal1;
        
    }
}
