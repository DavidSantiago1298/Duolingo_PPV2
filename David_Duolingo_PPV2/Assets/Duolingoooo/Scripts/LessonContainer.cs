using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLessons = 0;
    public bool AreAllLessonsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject LessonData;

    public void Start()
    {
        //Comprueba que lessonContainer no es null. 
        if (lessonContainer != null)
        {
            //Se encarga de actualizar la interfaz del usuario dependiendo de la lección.
            OnUpdateUI();
        }
        else
        {
            //Permite que se emita un mensaje en la consola en caso de que uno de los objetos sea null
            Debug.LogWarning("GameObject Nulo, revisa las variables del tipo GameObject LessonContainer");
        }
    }

    //Actualiza en la UI el texto que diga lesson.
    public void OnUpdateUI()
    {
        //Comprueba si los objetos StageTitle o LessonStage no son null
        if (StageTitle != null || LessonStage != null)
        {
            //Permite que el texto se actualize para indicar la leccion actual
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLession + " de " + TotalLessons;
        }
        else
        {
            //Hace que la consola mande un mensaje que avisa que no se han asignado los objetos en sus slots bien
            
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text");
        }
    }

    // Activa o desactiva la ventana del LessonContainer
    public void EnableWindow()
    {
        OnUpdateUI();

        if (lessonContainer.activeSelf)
        {
            // La esactiva si está activa.
            lessonContainer.SetActive(false);
        }
        else
        {
            //La activa si está desactivada.
            lessonContainer.SetActive(true);
        }
    }
}