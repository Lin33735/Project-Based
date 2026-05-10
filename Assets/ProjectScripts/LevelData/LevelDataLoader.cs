using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Net.Sockets;
using UnityEngine.Rendering;


public class LevelDataLoader : MonoBehaviour
{
    [SerializeField] private string jsonFileName = "levelData.json";
    [SerializeField] private Transform contentPanel;
    [SerializeField] private GameObject togglePrefab;
    [SerializeField] private GameObject dropDownPrefab;

    private ChecklistData level;
    private float score;

    private void Start()
    {
        score = 0;

        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);

        // Check if the file exists.
        if (File.Exists(filePath))
        {
            // Read the entire file into a string.
            string jsonContent = File.ReadAllText(filePath);
            Debug.Log(jsonContent);

            // Parse the JSON string into your data object.
            level = JsonUtility.FromJson<ChecklistData>(jsonContent);
            Debug.Log(level.checklistName);
            Debug.Log(level.items);

            for (int i = 0; i < level.items.Count; i++)
            {
                Debug.Log(level.items[i].InteractionName);
                Debug.Log(level.items[i].SafetyRating);

                GameObject dropDownObj = Instantiate(dropDownPrefab, contentPanel);
                dropDownObj.name = $"Task {i}";
                TMP_Text dropDownText = dropDownObj.GetComponent<TMP_Text>();
                dropDownText.text = level.items[i].InteractionName;
            }

            /*for (int i = 0; i < level.items.Count; i++)
            {
                Debug.Log(level.items[i].InteractionName);
                Debug.Log(level.items[i].SafetyRating);

                GameObject toggleObj = Instantiate(togglePrefab, contentPanel);
                toggleObj.name = "Task " + i;
                Toggle toggle = toggleObj.GetComponent<Toggle>();
                Text toggleText = toggleObj.GetComponentInChildren<Text>();

                toggleText.text = level.items[i].InteractionName;
                toggle.isOn = false;
            }*/
        }
        else
        {
            Debug.LogError($"JSON file not found at: {filePath}");
        }
    }
    public void ScoreCheck()
    {   
        for (int i = 0; i < level.items.Count; i++)
        {
            GameObject dropDownObj = GameObject.Find("Task " + i);
            TMP_Dropdown dropdown = dropDownObj.GetComponentInChildren<TMP_Dropdown>();
            Debug.Log(dropdown.captionText.text);
            if (level.items[i].SafetyRating == dropdown.captionText.text) { score++; }

            /*GameObject toggleObj = GameObject.Find("Task "+ i);
            Toggle toggle = toggleObj.GetComponent<Toggle>();
            if (level.items[i].InteractionActive == toggle.isOn)
            {
                score++;
            }*/
        }
        UIManager script = GetComponent<UIManager>();
        if (script != null)
        {
            script.LevelEnd(score/level.items.Count * 100f);
            Debug.Log(score);
            Debug.Log(level.items.Count);
            Debug.Log(score / level.items.Count * 100);
        }
    }
}
