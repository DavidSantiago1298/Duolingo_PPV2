using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Subject
{
    //Variables para los otros scripts que ayudaran a asignar las respuestas.
    public int ID;
    public string lessons;
    public List<string> options;
    public int correctAnswer;

}

