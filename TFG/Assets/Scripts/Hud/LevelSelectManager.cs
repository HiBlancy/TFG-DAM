using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private Transform levelButtonContainer;
    [SerializeField] private GameObject levelButtonPrefab;
    [SerializeField] private Button backButton;

    [SerializeField] private List<string> levelNames = new List<string> { "Level1", "Level2", "Level3" };
    [SerializeField] private List<string> levelDisplayNames = new List<string> { "Nivel 1", "Nivel 2", "Nivel 3" };

    private MainMenuManager mainMenuManager;

    private void Start()
    {
        mainMenuManager = Object.FindFirstObjectByType<MainMenuManager>();
        backButton.onClick.AddListener(mainMenuManager.ShowMainMenu);

        CreateLevelButtons();
    }

    private void CreateLevelButtons()
    {
        // Limpiar contenedor si ya tiene botones
        foreach (Transform child in levelButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // Crear botones para cada nivel
        for (int i = 0; i < levelNames.Count; i++)
        {
            GameObject buttonObj = Instantiate(levelButtonPrefab, levelButtonContainer);
            Button levelButton = buttonObj.GetComponent<Button>();
            Text buttonText = buttonObj.GetComponentInChildren<Text>();

            if (buttonText != null)
            {
                buttonText.text = levelDisplayNames[i];
            }

            // Capturar el índice para el listener
            int levelIndex = i;
            levelButton.onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    private void LoadLevel(int index)
    {
        if (index < levelNames.Count)
        {
            mainMenuManager.LoadLevel(levelNames[index]);
        }
    }
}
