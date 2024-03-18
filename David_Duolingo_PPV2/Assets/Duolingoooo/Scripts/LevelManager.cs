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

            //Establece la pregunta.
            question = currentLesson.lessons;

            //Establece cual es la pregunta correcta convirtiendola en correctAnswer.
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];

            //Llama a la UI para que aparezca la pregunta.
            textQuestion.text = question;

            //Establece las opciones 
            for (int i = 0; i < currentLesson.options.Count; i++)
            {

                // Dice que cada Question tiene un  Option
                Question[i].GetComponent<Option>().OptionName = currentLesson.options[i];

                Question[i].GetComponent<Option>().OptionID = i;

                //Actualiza el texto mostrado en Option
                Question[i].GetComponent<Option>().UpdateText();
            }
        }
        else
        {
           //Lanza un mensaje al acabar
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
                    //Si es correcta hace que image sea verde
                    AnswerContainer.GetComponent<Image>().color = Green;
                   //Confrima que es correcta y da una respuesta
                    textGood.text = "Respuesta correcta. " + question + ": " + correctAnswer;
                }
                else
                {
                    //Si no es correcta actualiza image a un rojo
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
            
        }
    }

   
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        //Ajusta el tiempo que deseas mostrar el resultado
        yield return new WaitForSeconds(2.5f);

        //Oculta el contenedor de respuestas.
        AnswerContainer.SetActive(false);

        //Carga una nueva pregunta
        LoadQuestion();

        //Activa el botón después de mostrar el resultado.
      
        CheckPlayerState();
    }

    //Asigna la respuesta del jugador
    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    //Revisa si el jugador interactua con un boton para cambiarle el color 
    public bool CheckPlayerState()
    {
        // Checamos que al interactuar con los botones, estos cambien de color al ser seleccionados.
        if (answerFromPlayer != 9)
        {
            /
            CheckButton.GetComponent<Button>().interactable = true;
            //Actualiza image para cambiar el color.
            CheckButton.GetComponent<Image>().color = Color.grey;
            return true;
        else
        {
        }
            CheckButton.GetComponent<Button>().interactable = false;
            //Cambia el color de image
            CheckButton.GetComponent<Image>().color = Color.white;
            return false;
        }
    }
}
