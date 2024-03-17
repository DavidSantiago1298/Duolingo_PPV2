using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lesson", menuName = "ScriptableObject/NeeLesson", order = 1)]

public class Leccion : ScriptableObject
{
    //Permite crear una lección que cual herede información y que se pueda alterar sin mover el codigo principal


    
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    [Header("Lesson Quest Configuration")]
    public List<Subject> leccionList;
}