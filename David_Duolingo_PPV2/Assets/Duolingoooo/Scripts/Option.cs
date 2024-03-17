using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    //Se obtiene el componente TMP del texto para poder actualizarlo
    //al texto que tiene la pregunta en el scriptable object.
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Función que actualiza el texto.
    public void UpdateText()
    {
        //Obtiene el children que tiene el texto para
        // ser actualizado al de las listas del scriptable object
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    // Función que checa que se selecione una de las opciones
    public void SelectOption()
    {
        //Asigna la respuesta correcta en función del ID que se encuentre en el script de Subject.
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        //Comprueba que con la funcion levelmanager se seleccione una respuesta y cheque si se puede interactuar con los botones
        LevelManager.Instance.CheckPlayerState();
    }
}
