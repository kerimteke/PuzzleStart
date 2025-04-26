using UnityEngine;

public class GameplayState : IGameState 
{
    public void EnterState() 
    {
        Debug.Log("GameplayState: Oyun başlıyor, oyun içi UI aktif ediliyor.");
        UIManager.Instance.ShowGameplayUI();
        // PuzzleManager üzerinden mevcut seviyeyi yüklüyoruz
        LevelData currentLevel = PuzzleLevelsManager.Instance.GetCurrentLevel();
        PuzzleManager.Instance.LoadLevel(currentLevel);
    }

    public void UpdateState() 
    {
        // Gameplay sırasında puzzle durumunu kontrol et
        if (PuzzleManager.Instance.IsLevelComplete()) {
            Debug.Log("GameplayState: Seviye tamamlandı!");
            
            // Örneğin seviye tamamlandığında skor güncellemesi, geçiş vb. işlemler yapılabilir.
            // Bu örnek, basitçe ana menüye dönüşü tetikler.
            GameStateManager.Instance.SetState(new MainMenuState());
        }
    }

    public void ExitState() 
    {
        Debug.Log("GameplayState: Oyun bitiyor, oyun içi UI gizleniyor.");
        UIManager.Instance.HideGameplayUI();
    }
}
