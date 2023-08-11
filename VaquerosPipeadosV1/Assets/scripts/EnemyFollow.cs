using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Player;
    public float movSpeed = 2f;
    private float distance = 0;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Player.position);
        if (distance < 18 && distance > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y,Player.position.z), movSpeed * Time.deltaTime);
            animator.SetBool("seguir", true);
        }
        else
        {
            animator.SetBool("seguir", false);
        }
        Vector3 playerPosition = Player.position;
        playerPosition.y = transform.position.y; // Mantener la posición Y del objeto

        if (GetComponent<EnemyDamage>() != null)
        {
            if (GetComponent<EnemyDamage>().damTime > 0)
            {
                animator.SetBool("seguir", false);
            }
        }

        transform.LookAt(playerPosition);
    }

    //En caso de colisión con el jugador
    void OnCollisionEnter(Collision collision)
    {
    }
}
