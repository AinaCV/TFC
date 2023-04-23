using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Variables para el manejo de inventario
    public List<Item> inventory = new List<Item>();
    public Text inventoryText;

    // Variables para el manejo de diálogos
    public Text dialogueText;
    public GameObject dialogueBox;
    public bool dialogueActive;
    public string[] dialogueLines;
    public int currentLine;
    public bool canMove;
    public bool choicesActive;
    public string[] choices;
    public int selectedChoice;

    // Variables para el guardado y carga de datos
    private string SAVE_FILE_NAME = "data.json";
    [System.Serializable]
    private struct SaveData
    {
        public List<Item> inventory;
        public int currentLine;
        public bool canMove;
    }

    void Awake()
    {
        // Singleton pattern para GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Cargar los datos guardados
        LoadData();
    }

    void Update()
    {
        // Abrir el diálogo si está activo
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (choicesActive)
            {
                ChooseOption();
            }
            else
            {
                ContinueDialogue();
            }
        }
    }

    public void AddItem(Item newItem)
    {
        // Añadir item al inventario
        inventory.Add(newItem);
        UpdateInventoryText();
    }

    public void RemoveItem(Item itemToRemove)
    {
        // Quitar item del inventario
        inventory.Remove(itemToRemove);
        UpdateInventoryText();
    }

    private void UpdateInventoryText()
    {
        // Actualizar texto del inventario
        string inventoryString = "";
        foreach (Item item in inventory)
        {
            inventoryString += item.name + "\n";
        }
        inventoryText.text = inventoryString;
    }

    public void StartDialogue(string[] lines)
    {
        // Iniciar diálogo
        dialogueActive = true;
        dialogueLines = lines;
        currentLine = 0;
        dialogueBox.SetActive(true);
        canMove = false;
        ContinueDialogue();
    }

    public void ContinueDialogue()
    {
        // Continuar diálogo
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        // Finalizar diálogo
        dialogueActive = false;
        dialogueBox.SetActive(false);
        canMove = true;
    }

    public void ChooseOption()
    {
        // Seleccionar opción
        for (int i = 0; i < choices.Length; i++)
        {
            if (i == selectedChoice)
            {
                dialogueLines = choices[i].Split(';');
                currentLine = 0;
                choicesActive = false;
                ContinueDialogue();
            }
        }
    }

    public void SaveData()
    {
        // Guardar datos
        SaveData saveData = new SaveData();
        saveData.inventory = inventory;
        saveData.currentLine = currentLine;
        saveData.canMove = canMove;

        string json = JsonUtility.ToJson(saveData);

    }
}
