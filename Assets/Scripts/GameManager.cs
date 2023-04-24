using SaveLoadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Data")]
    public PlayerData playerData;

    [Header("Inventory")]
    public Inventory inventory;

    [Header("Decision Manager")]
    public DecisionManager decisionManager;

    [Header("Dialog Manager")]
    public DialogueManager dialogueManager;

    [Header("Action Manager")]
    public ActionManager actionManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        decisionManager = new DecisionManager();
        actionManager = new ActionManager();
    }

    private void Start()
    {
        LoadGameData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveGameData();
            Application.Quit();
        }
    }
    public void SaveGameData()
    {
        playerData.position = GetPlayerPosition();
        playerData.inventory = inventory.GetInventoryData();
        playerData.decisions = decisionManager.GetDecisionData();

        SaveLoadManager.currentSaveData = playerData;
        SaveLoadManager.Save();
    }

    public void LoadGameData()
    {
        SaveLoadManager.Load();
        inventory.SetInventoryData(playerData.inventory);

        decisionManager.SetDecisionData(playerData.decisions);

        if (playerData.position != Vector3.zero) //Modificar la comparación
        {
            SetPlayerPosition(playerData.position);
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

    public void ShowDialogue(string dialogID)
    {
        dialogueManager.ShowDialogue(dialogID);
    }

    public void StartAction(string actionID)
    {
        Action action = actionManager.GetAction(actionID);
        if (action != null && CanAffordAction(action))
        {
            action.StartAction();
        }
    }

    private bool CanAffordAction(Action action)
    {
        if (action.cost == null)
        {
            return true;
        }
        return inventory.HasResources(action.cost);
    }

}