using UnityEngine;

[CreateAssetMenu(fileName = "PuzzlePieceData", menuName = "PuzzleGame/PuzzlePieceData")]
public class PuzzlePieceData : ScriptableObject 
{
    [Tooltip("Puzzle parçasının görseli")]
    public Sprite pieceSprite;

    [Tooltip("Bu parçanın ana puzzle alanındaki doğru konumu")]
    public Vector2 correctPosition;

    // Gerekirse, parçanın diğer özelliklerini (örneğin, collider tipi veya özel efektler) ekleyebilirsin.
}
