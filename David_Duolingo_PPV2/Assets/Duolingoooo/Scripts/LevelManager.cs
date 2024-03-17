using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Level Data")]
    public Leccion Lesson;

    [Header("User interface")]
    public TMP_Text textQuestion;
    public TMP_Text textGood;
    public List<Option> Question;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 9;

    [Header("Current Lesson")]
    public Subject currentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        //Define la cantidad de preguntas en la leccion 
        questionAmount = Lesson.leccionList.Count;
        // Carga la 1er pregunta
        LoadQuestion();

        // Checa si tienes una opcion selecionada.
        CheckPlayerState();
    }

    //Hace que se cargue la siguiente pregunta.
    private void LoadQuestion()
    {
        if (currentQuestion < questionAmount)
        {
            //Busca si estamos en la lección actual.
            currentLesson = Lesson.leccionList[currentQuestion];

            //Establecemos la pregunta.
            question = currentLesson.lessons;

            //Establece cual es la pregunta correcta convirtiendola en correctAnswer.
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];

            //Llama a la UI para que aparezca la pregunta.
            textQuestion.text = question;

            //Establecemos las opciones con for que recorre todas las opciones.
            for (int i = 0; i < currentLesson.options.Count; i++)
            {

                // Dice que cada Question tiene un componente Option
                Question[i].GetComponent<Option>().OptionName = currentLesson.options[i];

                Question[i].GetComponent<Option>().OptionID = i;

                //Actualiza el texto mostrado en Option
                Question[i].GetComponent<Option>().UpdateText();
            }
        }
        else
        {
            //Si no se cumple las reglas anteriores se manda un mensaje el cual dice:
            // "llegamos al final de las preguntas."
            Debug.Log("Fin de las preguntas");
        }
    }

    //Hace que se pase a la siguiente pregunta.
    public void NextQuestion()
    {
        if (CheckPlayerState())
        {
            //Asegura que la pregunta este dentro de los limites de la cantidad de preguntas 
            if (currentQuestion < questionAmount)
            {
                //Revisam si la pregunta es correcta
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                // Se activa la ventana que comprueba la respuesta en la UI.
                AnswerContainer.SetActive(true);

                // Se revisa si la respuesta es correcta o no es correcta.
                if (isCorrect)
                {
                    //Si sí es correcta, se actualizara el componente Image
                    //y se pondra de color verde para referencias que esta correcta la respuesta.
                    AnswerContainer.GetComponent<Image>().color = Green;
                    //Se actualiza el texto, usando un arreglo para poner el mensaje que deseamos mostrar y las variables
                    //string que contienen una cadena de letras.
                    textGood.text = "Respuesta correcta. " + question + ": " + correctAnswer;
                }
                else
                {
                    //Si no es correcta actualiza image al color rojo
                    AnswerContainer.GetComponent<Image>().color = Red;
                    //Actualiza para decir que esta incorrecta la respuesta
                    textGood.text = "Respuesta incorrecta. " + question + ": " + correctAnswer;
                }

                // Incrementa el indice de la pregunta para que no se repita 
                currentQuestion++;

                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                // reinicia la respuesta
                answerFromPlayer = 9;
                
            }
            else
            {
                //Cambia la escena
            }
        }
    }

   
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        //Ajusta el tiempo que deseas mostrar el resultado
        yield return new WaitForSeconds(2.5f);

        //Ocultar el contenedor de respuestas.
        AnswerContainer.SetActive(false);

        //Carga una nueva pregunta
        LoadQuestion();

        //Activa el botón después de mostrar el resultado.
      
        CheckPlayerState();
    }

    //Función que asigna la respuesta del jugador
    public void SetPlayerAnswer(int _answer)
    {
     //Esta línea actualiza la respuesta del jugador con el valor proporcionado como argumento a la función.
        answerFromPlayer = _answer;
    }

    //Revisa si el jugador interactua con un boton para cambiar el color de los botones 
    public bool CheckPlayerState()
    {
        // Checamos que al interactuar con los botones, estos cambien de color al ser seleccionados.
        if (answerFromPlayer != 9)
        {
            //Si no se interactua se pondra de color gris indicando que se puede interactuar con el.
            //Actualiza el button para hacer que se pueda pulsar otravez
            CheckButton.GetComponent<Button>().interactable = true;
            //Actualiza image para cambiar el color.
            CheckButton.GetComponent<Image>().color = Color.grey;
            return true;
        }
        else
        {
            // Si no sí interactua hace que se ponga de color blanco 
            CheckButton.GetComponent<Button>().interactable = false;
            //Cambia el color de image
            CheckButton.GetComponent<Image>().color = Color.white;
            return false;
        }
    }
}
