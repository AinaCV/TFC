using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI dialogueText;
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
        // Crear el diccionario dialogDictionary y poblarlo con los datos de diálogo
        dialogDictionary = new Dictionary<string, DialogData>();
        foreach (DialogData dialogData in dialogList)
        {
            dialogDictionary.Add(dialogData.dialogID, dialogData); //Replace the ellipsis with dialogData
        }
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(string dialogue)
    {
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }

    public void AddDialogue(string characterName, string dialogText)
    {
        DialogData dialog = new DialogData();
        dialog.characterName = characterName;
        dialog.dialogText = dialogText;
        dialogQueue.Enqueue(dialog);
    }

    public void ShowNextDialogue()
    {
        if (dialogQueue.Count == 0)
        {
            return;
        }

        DialogData dialog = dialogQueue.Dequeue();
        characterNameText.text = dialog.characterName;
        dialogueText.text = "";

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        currentCoroutine = StartCoroutine(TypeText(dialog.dialogText));
    }

    IEnumerator TypeText(string text)
    {
        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textDelay);
        }

        yield return new WaitForSeconds(dialogDelay);

        ShowNextDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueBox.activeSelf)
        {
            HideDialogue();
        }
    }

    public void ShowDialogue(string dialogID)
    {
        dialogueBox.SetActive(true);
        dialogue = DialogueDatabase.GetDialogueByID(dialogID);
        dialogueText.text = dialogue;
    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
        dialogue = "";
        dialogueText.text = "";
    }

    //public void ShowDialogue(string dialogID)
    //{
    //    DialogData dialogData = dialogDictionary[dialogID];

    //    if (dialogData != null)
    //    {
    //        if (dialogPanel != null)
    //        {
    //            dialogPanel.SetActive(true);
    //            characterNameText.text = dialogData.characterName;
    //            dialogText.text = dialogData.dialogText;
    //        }
    //        else
    //        {
    //            Debug.LogWarning("DialogPanel is not set.");
    //        }

    //        if (dialogData.isPlayer)
    //        {
    //            dialogTextInputField.gameObject.SetActive(true);
    //            dialogTextInputField.text = dialogData.dialogText;
    //            GameManager.Instance.StartAction(new ForestAction(dialogData.dialogID));
    //        }
    //        else
    //        {
    //            dialogTextInputField.gameObject.SetActive(false);
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogWarning("DialogData not found for ID: " + dialogID);
    //    }
    //}
}
