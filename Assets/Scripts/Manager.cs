using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public int playerCoins = 0;
    public float playerHealth = 10f;
    public Transform playerTransform;
    public Text saveListText;
    private int saveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame(saveIndex: 1);
        UpdateSaveList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveGame()
    {
        saveCount++;
        PlayerPrefs.SetInt("PlayerCoins" + saveCount, playerCoins);
        PlayerPrefs.SetFloat("PlayerHealth" + saveCount, playerHealth);
        PlayerPrefs.SetFloat("PlayerPosX" + saveCount, playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY" + saveCount, playerTransform.position.y);
        PlayerPrefs.SetInt("SaveCount", saveCount); // сохраняем счётчик сохранений
        PlayerPrefs.Save();
        UpdateSaveList();
    }

    public void LoadGame(int saveIndex)
    {
        if (saveIndex <= saveCount)
        {
            playerCoins = PlayerPrefs.GetInt("PlayerCoins" + saveIndex, 0);
            playerHealth = PlayerPrefs.GetFloat("PlayerHealth" + saveIndex, 10f);
            float posX = PlayerPrefs.GetFloat("PlayerPosX" + saveIndex, 0f);
            float posY = PlayerPrefs.GetFloat("PlayerPosY" + saveIndex, 0f);
            playerTransform.position = new Vector3(posX, posY, playerTransform.position.z);
            Debug.Log($"Сохранение {saveIndex}: Монеты: {playerCoins}, Здоровье: {playerHealth}, Позиция: {playerTransform}");
        }
    }

    public void LoadButtonClicked(int saveIndex)
    {
        LoadGame(saveIndex);
    }

    public void UpdateSaveList()
    {
        saveCount = PlayerPrefs.GetInt("SaveCount", 0);
        saveListText.text = "Последнее сохранение:\n";

        for (int i = 1; i < saveCount; i++)
        {
            int coins = PlayerPrefs.GetInt("PlayerCoins" + i, 0);
            saveListText.text += $"Сохранение {i}: Монеты: {coins}\n";
        }
    }
}
