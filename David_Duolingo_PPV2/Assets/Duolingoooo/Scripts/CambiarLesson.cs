using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarLesson : MonoBehaviour
{
    public bool pasarNivel;
    public int IndiceNivel;

    //Permite cambair de escena al presionar space
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           //Cambiara a la escena de la variable IndiceNivel
            CambiarNivel(IndiceNivel);
        }
        //Cambia la escena si la variable bool es = true.
        if (pasarNivel)
        {
            CambiarNivel(IndiceNivel);
        }
    }

    // Permite cambiar de escena 
    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
