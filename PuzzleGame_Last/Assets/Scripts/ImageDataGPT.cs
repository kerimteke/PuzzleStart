using UnityEngine;


[CreateAssetMenu(menuName = "Puzzle/ImageData")]
public class ImageData : ScriptableObject
{
    public int imageID;          // Benzersiz kimlik
    public string imageName;     // Editörde gözüksün
    public Sprite sourceSprite;  // Puzzle'ın ana resmi
}
