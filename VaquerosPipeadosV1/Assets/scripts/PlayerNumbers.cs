using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNumbers : MonoBehaviour
{
    public Text MemScoreText;
    public Text HPText;
    public int memScore = 0;
    public int HPVal;
    public int maxScore;
    public int MaxHP;

    //Aparentemente tengo que programar un knockback especial para el jugador cuando choque con balas
    public float damTimeMax;
    float damTime;
    public float damSpeed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        memScore = 0;
        MaxHP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        MemScoreText.text = "Memorias: " + memScore;
        HPText.text = "HP: " + HPVal;

        //Para reiniciar al jugador
        if (HPVal <= 0)
        {
            Muerte();
        }

        //Secuencia de golpe
        if (damTime > 0)
        {
            if (damTime > (damTimeMax - 90))
            {
                transform.position = transform.position - transform.forward * damSpeed;
            }
            if (damTime == (damTimeMax - 90))
            {
                GetComponent<controlFPS>().disableDir = false;
            }
            damTime--;
        }
    }

    //Para la muerte del jugador
    void Muerte()
    {
        transform.position = GetComponent<controlFPS>().basePosition;
        HPVal = MaxHP;
        GetComponent<controlFPS>().disableDir = false;
    }

    //En caso de colisión con el jugador
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BottomEnd")
        {
            Muerte();
        }
        //Colisión con bala especial
        if (collision.gameObject.tag == "EnemyBullet")
        {
            HPVal = HPVal - 1;
            rb.AddForce(Vector3.up * 300);
            damTime = damTimeMax;
            //posFixed = transform.position;
            GetComponent<controlFPS>().disableDir = true;
        }
    }

}
