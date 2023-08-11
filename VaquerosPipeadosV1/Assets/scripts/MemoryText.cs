using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryText : MonoBehaviour
{
    public GameObject myPlayer;
    public int memRequired;
    public bool gastado = false;
    public float timer;
    public bool soyBoss;

    // Start is called before the first frame update
    void Start()
    {
        Image image = GetComponent<Image>();
        Color c = image.color;
        c.a = 0;
        image.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        if ((myPlayer.GetComponent<PlayerNumbers>().memScore >= memRequired && !gastado)||(soyBoss == true))
        {
            Image image = GetComponent<Image>();
            Color c = image.color;
            c.a = 255;
            image.color = c;
            soyBoss = false;
            gastado = true;
        }
        if (gastado == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Destroy(gameObject);
            }
            timer -= 0.5f;
            if (timer < 50)
            {
                GetComponent<Transform>().localScale = new Vector3(0.8f*timer / 50, 0.8f*timer / 50, 0.8f*timer / 50);
            }
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
