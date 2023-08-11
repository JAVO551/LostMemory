using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMeAt : MonoBehaviour
{
    public GameObject myPlayer;
    public int memRequired;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.GetComponent<PlayerNumbers>().memScore < memRequired)
        {
        }
        else
        {
            //Aparece objeto
            Destroy(gameObject);
        }
    }
}
