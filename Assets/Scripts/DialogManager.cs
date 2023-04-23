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

    private Queue<DialogData> dialogQueue = new Queue<DialogData>();
    private Coroutine currentCoroutine;

    public void AddDialog(string characterName, string dialogText)
    {
        DialogData dialog = new DialogData();
        dialog.characterName = characterName;
        dialog.dialogText = dialogText;
        dialogQueue.Enqueue(dialog);
    }

    public void ShowNextDialog()
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

    IEnumerator TypeText(string text)
    {
        foreach (char c in text)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textDelay);
        }

        yield return new WaitForSeconds(dialogDelay);

        ShowNextDialog();
    }
}
