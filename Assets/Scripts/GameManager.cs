using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
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

        SaveLoadManager.Save(playerData);
    }

    public void LoadGameData()
    {
        playerData = SaveLoadManager.Load();

        inventory.SetInventoryData(playerData.inventory, null);
        DecisionManager.SetDecisionData(playerData.decisions);
        if (playerData.position != null)
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
        playerData = new PlayerData();
        inventory.ResetInventory();
        decisionManager.ResetDecisions();
        SaveLoadManager.Save(playerData);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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