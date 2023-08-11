using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject myPlayer;
    public float enemyHP;
    float maxHP;
    public float damTimeMax;
    public float damTime;
    public float damSpeed;
    Vector3 dirGolpe;
    Vector3 posFixed;
    Vector3 origPosition;
    public GameObject texto;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        damTime = 0;
        audioSource = GetComponent<AudioSource>();
        origPosition = transform.position;
        maxHP = enemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            if (maxHP > 10)
            {
                texto.GetComponent<MemoryText>().soyBoss = true;
            }
            audioSource.Play();
            Destroy(gameObject);
        }

        if (damTime > 0)
        {
            transform.position = posFixed;
            if (damTime > (damTimeMax - 90))
            {
                myPlayer.transform.position = myPlayer.transform.position - myPlayer.transform.forward * damSpeed;
            }
            if (damTime == (damTimeMax - 90))
            {
                myPlayer.GetComponent<controlFPS>().disableDir = false;
            }
            damTime--;
        }


    }

    //En caso de colisión
    void OnCollisionEnter(Collision collision)
    {
        //Colisión con el jugador
        if ((collision.gameObject.tag == "playerTag") && (damTime < (damTimeMax - 90)))
        {
            audioSource.Play();
            myPlayer.GetComponent<PlayerNumbers>().HPVal = myPlayer.GetComponent<PlayerNumbers>().HPVal - 1;
            myPlayer.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
            Vector3 dirGolpe = myPlayer.transform.position - transform.position;
            transform.position = transform.position - dirGolpe.normalized * 0.3f;
            damTime = damTimeMax;
            posFixed = transform.position;
            myPlayer.GetComponent<controlFPS>().disableDir = true;
        }
        //Colisión con la bala
        if (collision.gameObject.tag == "BulletTag")
        {
            audioSource.Play();
            enemyHP = enemyHP - 1;
        }
        //Colisión con el fondo
        if (collision.gameObject.tag == "BottomEnd")
        {
            audioSource.Play();
            transform.position = origPosition;
        }
    }
}
