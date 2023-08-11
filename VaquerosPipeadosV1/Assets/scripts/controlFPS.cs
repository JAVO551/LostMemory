using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlFPS : MonoBehaviour
{
    Rigidbody rb;
    Vector2 inputMov;
    Vector2 inputRot;
    public float velCamina = 12;

    public float sensMouse = 10;
    Transform cam;
    float rotX;
    
    //Preparar el salto
    public float fuerzaSalto = 10;
    bool floorDetected = false;
    
    //Preparar disparos
    public GameObject Bullet1;
    public GameObject Pistola;
    
    public Transform spawnPoint;
    public float shotForce = 1500;

    public AudioSource audioSource;

    //Para la pausa
    private bool juegoEnPausa = false;
    
    //Para atorar al jugador
    public bool disableDir;

    //Para el respawn
    public Vector3 basePosition;

    // Start is called before the first frame update
    void Start()
    {
        //Para el audio
        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0);
        rotX = cam.eulerAngles.x;

        // Ocultar el cursor del mouse
        Cursor.visible = false;

        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        //Estado de los controles
        disableDir = false;

        //Punto de creación
        basePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Lectura de movimiento
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        //Detección de piso
        Vector3 floor = transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(transform.position, floor, transform.localScale.y + 0.03f))
        {
            floorDetected = true;
        }
        else
        {
            floorDetected = false;
        }

        //Salto
        if (Input.GetButtonDown("Jump") && floorDetected)
            rb.AddForce(0, fuerzaSalto, 0);

        //Disparar
        if (Input.GetButtonDown("Fire1") && juegoEnPausa == false)
        {
            GameObject newBullet;

            newBullet = Instantiate(Bullet1, new Vector3(Pistola.transform.position.x, Pistola.transform.position.y, Pistola.transform.position.z), Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
            audioSource.Play();
        }

        //Para´poner pausa
        if (Input.GetButtonDown("Cancel"))
        {
            if (juegoEnPausa)
            {
                ReanudarJuego();
            }
            else
            {
                Pausar();
            }
        }
    }

    //Nose xd
    private void FixedUpdate()
    {
        //Input de movimiento
        float vel = velCamina;
        if (disableDir == false)
        {
            rb.velocity =
                transform.forward * vel * inputMov.y + //Movimiento adelante y atrás
                transform.right * vel * inputMov.x + //Movimiento derecha e izquierda
                new Vector3(0, rb.velocity.y, 0);
        }

        //Input movimiento de cámara
        inputRot.x = Input.GetAxis("Mouse X") * sensMouse;
        inputRot.y = Input.GetAxis("Mouse Y") * sensMouse;

        transform.rotation *= Quaternion.Euler(0, inputRot.x, 0);

        rotX -= inputRot.y;
        rotX = Mathf.Clamp(rotX, -50, 50);
        cam.localRotation = Quaternion.Euler(rotX, 0, 0);
    }

    private void Pausar()
    {
        Time.timeScale = 0f;
        juegoEnPausa = true;
        // Aquí puedes agregar cualquier otra lógica que desees al poner el juego en pausa
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void ReanudarJuego()
    {
        Time.timeScale = 1f;
        juegoEnPausa = false;
        // Aquí puedes agregar cualquier otra lógica que desees al reanudar el juego
        
        // Ocultar el cursor del mouse
        Cursor.visible = false;
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }
}
