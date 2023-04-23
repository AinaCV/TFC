using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instancia �nica del GameManager

    [Header("Player Data")]
    public PlayerData playerData;

    [Header("Inventory")]
    public Inventory inventory;

    [Header("Decision Manager")]
    public DecisionManager decisionManager = new DecisionManager();

    [Header("Dialog Manager")]
    public DialogManager dialogManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        LoadGameData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Si se presiona la tecla "Escape", guarda los datos del juego y cierra la aplicaci�n
        {
            SaveGameData();
            Application.Quit();
        }
    }

    public void SaveGameData()
    {
        playerData.position = GetPlayerPosition();//Obtiene la posici�n del jugador
        playerData.inventory = inventory.GetInventoryData();  //Obtiene los datos del inventario
        playerData.decisions = decisionManager.GetDecisionData(); //Obtiene las decisiones tomadas por el jugador

        SaveLoadManager.currentSaveData = playerData; //Guarda los datos del jugador en la clase SaveLoadManager
        SaveLoadManager.Save();
    }

    public void LoadGameData()
    {
        SaveLoadManager.Load(); //Carga los datos del archivo de guardado
        playerData = SaveLoadManager.currentSaveData; //Obtiene los datos del jugador SaveLoadManager

        inventory.SetInventoryData(playerData.inventory, null); //Establece los datos del inventario
        DecisionManager.SetDecisionData(playerData.decisions); //Establece las decisiones tomadas por el jugador
        if (playerData.position != null) //Si se tienen los datos de la posici�n del jugador
        {
            SetPlayerPosition(playerData.position); //Establece la posici�n del jugador
        }
    }

    private Vector3 GetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) 
        {
            return player.transform.position; 
        }
        return Vector3.zero; 
    }

    private void SetPlayerPosition(Vector3 position)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player != null) 
        {
            player.transform.position = position; 
        }
    }

    public void StartNewGame()
    {
        playerData = new PlayerData(); //Crea nuevos datos del jugador
        inventory.ResetInventory(); //Reinicia el inventario
        decisionManager.ResetDecisions(); //Reinicia las decisiones tomadas
        SaveLoadManager.currentSaveData = playerData; //Establece los nuevos datos del jugador en la clase SaveLoadManager
        SaveLoadManager.Save(); //Guarda los nuevos datos del jugador en el archivo de guardado
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reinicia la escena actual
    }

    public void EndGame()
    {
        SaveGameData();
        Application.Quit();
    }

    public void ShowDialog(string dialogID)
    {
        dialogManager.ShowDialog(dialogID);
    }
}