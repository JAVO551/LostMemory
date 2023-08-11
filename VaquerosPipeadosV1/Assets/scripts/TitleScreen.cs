using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public string map1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CambiarAEscenaDestino();
        }
    }

    void CambiarAEscenaDestino()
    {
        SceneManager.LoadScene(map1);
    }
}
