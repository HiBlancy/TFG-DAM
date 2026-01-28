using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Botones del Menú")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button achievementsButton;
    [SerializeField] private Button quitButton;

    [Header("Paneles")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelSelectPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject achievementsPanel;

    [Header("Configuración")]
    [SerializeField] private string firstLevelScene = "Level1";

    private void Start()
    {
        // Configurar listeners de botones
        playButton.onClick.AddListener(OpenLevelSelect);
        optionsButton.onClick.AddListener(OpenOptions);
        achievementsButton.onClick.AddListener(OpenAchievements);
        quitButton.onClick.AddListener(QuitGame);

        // Mostrar solo el menú principal al inicio
        ShowMainMenu();
    }

    private void OpenLevelSelect()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    private void OpenOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    private void OpenAchievements()
    {
        mainMenuPanel.SetActive(false);
        achievementsPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        // Desactivar todos los paneles
        levelSelectPanel.SetActive(false);
        optionsPanel.SetActive(false);
        achievementsPanel.SetActive(false);

        // Activar menú principal
        mainMenuPanel.SetActive(true);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(firstLevelScene);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
