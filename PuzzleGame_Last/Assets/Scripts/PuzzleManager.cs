using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    // Singleton örneği
    public static PuzzleManager Instance { get; private set; }

    [Header("Puzzle Prefab")]
    [Tooltip("Puzzle parçası prefab'ı, her seviye için kullanılır.")]
    public GameObject puzzlePiecePrefab;

    // Aktif seviye içindeki tüm puzzle parçalarını saklamak için
    private List<PuzzlePiece> activePieces = new List<PuzzlePiece>();
    
    // Şu anda yüklenmiş seviye verisi
    private LevelData currentLevel;

    private void Awake()
    {
        // Singleton kontrolü ve sahne geçişlerinde yok edilmesini engelleme
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

    /// <summary>
    /// Verilen seviye verisine göre, puzzle parçalarını sahneye yükler.
    /// </summary>
    /// <param name="level">LevelData Scriptable Object</param>
    public void LoadLevel(LevelData level)
    {
        // Var olan parçaları temizle
        ClearLevel();
        currentLevel = level;

        // LevelData içindeki her PuzzlePieceData için döngü
        foreach (PuzzlePieceData data in level.puzzlePieces)
        {
            // Puzzle prefab'ından yeni bir nesne oluşturuyoruz.
            GameObject pieceObject = Instantiate(puzzlePiecePrefab, transform);

            // PuzzlePiece bileşenini al, eğer yoksa hata ver.
            PuzzlePiece pieceComp = pieceObject.GetComponent<PuzzlePiece>();
            if (pieceComp != null)
            {
                // SO'dan alınan doğru pozisyon bilgisini uyguluyoruz
                // (2D projelerde Z=0 olarak ayarlanır)
                pieceComp.correctPosition = new Vector3(data.correctPosition.x, data.correctPosition.y, 0);

                // SpriteRenderer aracılığıyla parçanın görselini atıyoruz.
                SpriteRenderer renderer = pieceObject.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    renderer.sprite = data.pieceSprite;
                }
                
                // İstediğin şekilde başlangıç pozisyonunu belirleyebilirsin.
                // Örneğin, rastgele bir noktaya yerleştirebilir veya özel bir spawn noktasına koyabilirsin.
                pieceObject.transform.position = new Vector3(
                    Random.Range(100, Screen.width - 100),
                    Random.Range(100, Screen.height - 100),
                    0);

                // Listeye ekleyerek daha sonra kontrol edebilelim.
                activePieces.Add(pieceComp);
            }
            else
            {
                Debug.LogError("PuzzlePiece bileşeni prefab üzerinde bulunamadı.");
            }
        }
    }

    /// <summary>
    /// Tüm puzzle parçalarının doğru konumda yerleşip yerleşmediğini kontrol eder.
    /// </summary>
    /// <returns>Doğru yerleştirme gerçekleştiyse true döner.</returns>
    public bool IsLevelComplete()
    {
        // Her aktif parçanın isPlaced flag'ı kontrol ediliyor.
        foreach (PuzzlePiece piece in activePieces)
        {
            if (!piece.isPlaced)
                return false;
        }
        return true;
    }

    /// <summary>
    /// Geçerli seviyeye ait tüm instantiated puzzle parçalarını sahneden temizler.
    /// </summary>
    private void ClearLevel()
    {
        foreach (PuzzlePiece piece in activePieces)
        {
            if (piece != null)
            {
                Destroy(piece.gameObject);
            }
        }
        activePieces.Clear();
    }
}
