using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPosition = Player.position;
        playerPosition.y = transform.position.y; // Mantener la posición Y del objeto
        transform.LookAt(playerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
