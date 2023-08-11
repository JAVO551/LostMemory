using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSec1 : MonoBehaviour
{
    public bool active;
    float timer1 = 7000;//7000;
    public Transform Player;
    public float movSpeed = 4f;
    Vector3 targetPlayer;
    public Rigidbody rb;
    float distance;
    //Preparar disparos
    public GameObject Bullet1;
    float i = 0;
    public GameObject myPlayer;
    Vector3 dirGolpe;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        targetPlayer = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = Player.position;
        playerPosition.y = transform.position.y; // Mantener la posición Y del objeto
        transform.LookAt(playerPosition);

        distance = Vector3.Distance(transform.position, Player.position);
        if (myPlayer.GetComponent<PlayerNumbers>().memScore >= 9 && distance < 50 && distance > 0.5f)
        {
            active = true;
        }
        else
        {
            active = false;
        }
        
        if (active)
        {
            if (timer1 > 5000)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y, Player.position.z), movSpeed * Time.deltaTime);
            }

            if (timer1 == 4700 || timer1 == 4200 || timer1 == 3700 || timer1 == 3200 || timer1 == 3200)
            {
                while (i < 20)
                {
                    Instantiate(Bullet1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    i = i + 1;
                }
                i = 0;
            }

            if (timer1 < 2700)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPlayer, 10 * Time.deltaTime);

                Vector3 floor = transform.TransformDirection(Vector3.down);
                if (Physics.Raycast(transform.position, floor, transform.localScale.y + 0.03f))
                {
                    targetPlayer = Player.position;
                    rb.AddForce(0, 850, 0, ForceMode.Impulse);
                    if (timer1 <= 0)
                    {
                        timer1 = 7000;
                    }
                }
            }
            timer1--;
        }
    }
}
