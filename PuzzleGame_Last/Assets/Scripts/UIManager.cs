using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton örneği
    public static UIManager Instance { get; private set; }

    [Header("UI Panelleri")]
    [Tooltip("Ana menü panelinin referansı")]
    public GameObject mainMenuPanel;
    [Tooltip("Oyun içi UI panelinin referansı")]
    public GameObject gameplayUIPanel;
    [Tooltip("Seviye tamam panelinin referansı (opsiyonel)")]
    public GameObject levelCompletePanel;

    private void Awake()
    {
        // Singleton kurulumu: Eğer bu nesne ilk oluşturulan ise yoksa mevcut olanı koru.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Sahne geçişlerinde yok edilmesini engelle
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Ana menü UI'sını gösterir ve diğerlerini kapatır
    public void ShowMainMenu()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);
        if (gameplayUIPanel != null)
            gameplayUIPanel.SetActive(false);
        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);
    }

    public void HideMainMenu()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);
    }

    // Oyun içi UI'yi aktif eder
    public void ShowGameplayUI()
    {
        if (gameplayUIPanel != null)
            gameplayUIPanel.SetActive(true);
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);
        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);
    }

    public void HideGameplayUI()
    {
        if (gameplayUIPanel != null)
            gameplayUIPanel.SetActive(false);
    }

    // Opsiyonel: Seviye tamam ekranının görünmesi için
    public void ShowLevelCompleteUI()
    {
        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(true);
    }

    public void HideLevelCompleteUI()
    {
        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        // Butona tıklandığında, doğrudan state geçişini yap:
        GameStateManager.Instance.SetState(new GameplayState());
    }

}
