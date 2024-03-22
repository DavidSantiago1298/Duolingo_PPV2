using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubjectContainer
{
    [Header("GameObject Configuration")]
    [SerializedField]
    public int Lesson = 0;

    [Header("Lession Quest Configuration")]
    [SerializedField]
    public List<Leccion> leccionList;
}
