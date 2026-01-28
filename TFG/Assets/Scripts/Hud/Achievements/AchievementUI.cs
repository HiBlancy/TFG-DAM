using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Text titleText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject lockedOverlay;
    [SerializeField] private GameObject unlockedOverlay;

    public void Setup(AchievementsManager.Achievement achievement)
    {
        titleText.text = achievement.title;
        descriptionText.text = achievement.description;

        if (achievement.icon != null)
        {
            iconImage.sprite = achievement.icon;
        }

        // Mostrar estado del logro
        lockedOverlay.SetActive(!achievement.isUnlocked);
        unlockedOverlay.SetActive(achievement.isUnlocked);

        // Ajustar color si está bloqueado
        if (!achievement.isUnlocked)
        {
            iconImage.color = Color.gray;
            titleText.color = Color.gray;
            descriptionText.color = Color.gray;
        }
        else
        {
            iconImage.color = Color.white;
            titleText.color = Color.white;
            descriptionText.color = Color.white;
        }
    }
}
