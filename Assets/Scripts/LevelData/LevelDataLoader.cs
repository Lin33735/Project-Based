using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class LevelDataLoader : MonoBehaviour
{
    [SerializeField] private string jsonFileName = "levelData.json";
    [SerializeField] private Transform contentPanel;
    [SerializeField] private GameObject togglePrefab;

    private void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);

        // Check if the file exists.
        if (File.Exists(filePath))
        {
            // Read the entire file into a string.
            string jsonContent = File.ReadAllText(filePath);
            Debug.Log(jsonContent);

            // Parse the JSON string into your data object.
            ChecklistData level = JsonUtility.FromJson<ChecklistData>(jsonContent);
            Debug.Log(level.checklistName);
            Debug.Log(level.items);

            for (int i = 0; i < level.items.Count; i++)
            {
                Debug.Log(level.items[i].InteractionActive);
                Debug.Log(level.items[i].InteractionName);

                GameObject toggleObj = Instantiate(togglePrefab, contentPanel);
                Toggle toggle = toggleObj.GetComponent<Toggle>();
                Text toggleText = toggleObj.GetComponentInChildren<Text>();

                toggleText.text = level.items[i].InteractionName;
                toggle.isOn = false;
            }
        }
        else
        {
            Debug.LogError($"JSON file not found at: {filePath}");
        }
    }
}
