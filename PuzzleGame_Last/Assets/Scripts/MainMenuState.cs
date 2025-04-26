using UnityEngine;

public class MainMenuState : IGameState 
{
    public void EnterState() 
    {
        Debug.Log("MainMenuState: Girildi, ana menü gösteriliyor.");
        // Örneğin UIManager üzerinden ana menünün görünmesini sağla:
        UIManager.Instance.ShowMainMenu();
    }

    public void UpdateState() 
    {
        // Kullanıcı etkileşimlerini kontrol et. (Basit örnek: Enter tuşu ile oyuna başla)
        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("MainMenuState: 'Enter' tuşuna basıldı. Oyun başlayacak.");
            GameStateManager.Instance.SetState(new GameplayState());
        }
    }

    public void ExitState() 
    {
        Debug.Log("MainMenuState: Çıkılıyor, ana menü gizleniyor.");
        UIManager.Instance.HideMainMenu();
    }
}
