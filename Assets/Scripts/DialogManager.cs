using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI dialogText;
    public float textDelay = 0.1f;
    public float dialogDelay = 1f;
    public GameObject dialogPanel;
    public TMP_InputField dialogTextInputField;

    private Queue<DialogData> dialogQueue = new Queue<DialogData>();
    private Coroutine currentCoroutine;
    private Dictionary<string, DialogData> dialogDictionary;

    // Lista de diálogos
    public List<DialogData> dialogList;

    private void Awake()
    {
        // Inicializar la lista dialogList
        List<DialogData> dialogList = new List<DialogData>();

        // Agregar datos de diálogo a la lista dialogList

        // Crear el diccionario dialogDictionary y poblarlo con los datos de diálogo
        dialogDictionary = new Dictionary<string, DialogData>();
        foreach (DialogData dialogData in dialogList)
        {
            dialogDictionary.Add(dialogData.dialogID, dialogData);
        }
    }


    public void AddDialog(string characterName, string dialogText) // Agregar un diálogo a la cola
    {
        DialogData dialog = new DialogData();
        dialog.characterName = characterName;
        dialog.dialogText = dialogText;
        dialogQueue.Enqueue(dialog);
    }

    public void ShowNextDialog() // Mostrar el siguiente diálogo en la cola
    {
        if (dialogQueue.Count == 0)
        {
            return;
        }

        DialogData dialog = dialogQueue.Dequeue();
        characterNameText.text = dialog.characterName;
        dialogText.text = "";

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        currentCoroutine = StartCoroutine(TypeText(dialog.dialogText));
    }

    IEnumerator TypeText(string text)    // Escribir el texto letra por letra con un pequeño retraso entre cada letra
    {
        foreach (char c in text)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textDelay);
        }

        yield return new WaitForSeconds(dialogDelay);

        ShowNextDialog();
    }

    public void ShowDialog(string dialogID)    // Mostrar un diálogo según su ID
    {
        DialogData dialogData = dialogDictionary[dialogID];

        if (dialogData != null)
        {
            if (dialogPanel != null)
            {
                dialogPanel.SetActive(true);
                characterNameText.text = dialogData.characterName;
                dialogText.text = dialogData.dialogText;
            }
            else
            {
                Debug.LogWarning("DialogPanel is not set.");
            }

            if (dialogData.isPlayer)
            {
                characterNameText.text = GameManager.instance.playerData.characterName;
                dialogTextInputField.gameObject.SetActive(true);
                dialogTextInputField.text = dialogData.dialogText;
            }
            else
            {
                characterNameText.text = dialogData.characterName;
                dialogTextInputField.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("DialogData not found for ID: " + dialogID);
        }
    }
}