using UnityEngine;
using System.Collections.Generic;

public class PuzzleLevelsManager : MonoBehaviour 
{
    public static PuzzleLevelsManager Instance { get; private set; }

    [Tooltip("Oynamak istediğin tüm seviye verilerini içeren liste (ScriptableObject referansları)")]
    public List<LevelData> levels;

    [Tooltip("Geçerli seviye indeksi (başlangıçta 0)")]
    public int currentLevelIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Oynanmak üzere aktif seviyeyi getirir.
    public LevelData GetCurrentLevel() 
    {
        if(levels != null && levels.Count > currentLevelIndex)
            return levels[currentLevelIndex];
        return null;
    }

    // İlerleyen zamanlarda, seviye geçişlerinde indeks güncellemesi yapabilirsin.
    public void GoToNextLevel()
    {
        currentLevelIndex++;
    }
}
