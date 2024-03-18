using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    //Crea el texto
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Actualiza el texto.
    public void UpdateText()
    {
        //Actualiza el hijo del texto
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Permite selecionar una opcion
    public void SelectOption()
    {
        //Asigna  cual es la respuesta correcta 
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        //Comprueba que se seleccione una respuesta 
        LevelManager.Instance.CheckPlayerState();
    }
}
