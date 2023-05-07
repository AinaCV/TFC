using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText; //using TMPro;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices; //array de elecciones
    private TextMeshProUGUI[] choicesText; //array de cada texto para cada elección

    private Story currentStory; //using Ink.Runtime;

    public bool dialogueIsPlaying { get; private set; }//read only

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //inicializa choicesText
        choicesText = new TextMeshProUGUI[choices.Length]; //iguala el array de choicesText con la cantidad del array de choices
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++; //incrementa el indice despues de cada loop
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)//coge el json con los dialogos
    {
        currentStory = new Story(inkJSON.text);//se inicializa con la info del json
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = ""; // dejamos el texto en un string vacia por si acaso
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //set the text
            dialogueText.text = currentStory.Continue();//nos da la siguiente linea de dialogo y además la quita de la lista de lineas que pueden salir en el dialogo
            //Si hay elección el dialogo activo, display 
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices; //Devuele una lista de choices si la hay

        if (currentChoices.Count > choices.Length) //checkea la cantidad de decisiones y da error si sobrepasa el array
        {
            Debug.LogError("More coices than UI can support. Number of choices given:" + currentChoices.Count);
        }

        int index = 0;
        //buscar e inicializar los gobj de choices en UI, para las lineas de dialogo activas
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text; //choiceText es el UI text y lo igualamos al texto de las decisiones
            index++;
        }
        //Revisa las elecciones que quedan por hacer en UI y desactivalas
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }
}
