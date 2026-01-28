using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour
{
    [System.Serializable]
    public class Achievement
    {
        public string id;
        public string title;
        public string description;
        public bool isUnlocked;
        public Sprite icon;
    }

    [SerializeField] private Transform achievementsContainer;
    [SerializeField] private GameObject achievementPrefab;
    [SerializeField] private Button backButton;

    [SerializeField] private List<Achievement> achievements = new List<Achievement>();

    private MainMenuManager mainMenuManager;

    private void Start()
    {
        mainMenuManager = Object.FindFirstObjectByType<MainMenuManager>();
        backButton.onClick.AddListener(mainMenuManager.ShowMainMenu);

        LoadAchievements();
        DisplayAchievements();
    }

    private void LoadAchievements()
    {
        // Cargar logros desbloqueados desde PlayerPrefs
        foreach (Achievement achievement in achievements)
        {
            achievement.isUnlocked = PlayerPrefs.GetInt("Achievement_" + achievement.id, 0) == 1;
        }
    }

    private void DisplayAchievements()
    {
        // Limpiar contenedor
        foreach (Transform child in achievementsContainer)
        {
            Destroy(child.gameObject);
        }

        // Crear UI para cada logro
        foreach (Achievement achievement in achievements)
        {
            GameObject achievementObj = Instantiate(achievementPrefab, achievementsContainer);
            AchievementUI achievementUI = achievementObj.GetComponent<AchievementUI>();

            if (achievementUI != null)
            {
                achievementUI.Setup(achievement);
            }
        }
    }

    public void UnlockAchievement(string achievementId)
    {
        Achievement achievement = achievements.Find(a => a.id == achievementId);
        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.isUnlocked = true;
            PlayerPrefs.SetInt("Achievement_" + achievementId, 1);
            DisplayAchievements(); // Actualizar UI
        }
    }
}