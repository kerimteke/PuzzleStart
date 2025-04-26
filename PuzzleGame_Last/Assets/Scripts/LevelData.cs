using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelData", menuName = "PuzzleGame/LevelData")]
public class LevelData : ScriptableObject 
{
    [Tooltip("Seviye adı (örn. Level 1)")]
    public string levelName;

    [Tooltip("Seviye indeksi")]
    public int levelIndex;

    [Tooltip("Puzzle ızgarasının (grid) boyutu örneğin, 5x5 gibi")]
    public Vector2Int gridSize;

    [Tooltip("Seviye içerisindeki tüm puzzle parçalarının verileri")]
    public List<PuzzlePieceData> puzzlePieces;

    [Tooltip("Seviye zorluk derecesi (örneğin 1 ile 5 arasında)")]
    public int difficulty;
    
    // İlerleyen yaşamlarda, arka plan görseli veya ek ayarlar ekleyebilirsin.
}
