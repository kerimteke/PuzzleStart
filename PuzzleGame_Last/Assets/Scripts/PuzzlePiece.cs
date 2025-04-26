using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Tooltip("Bu parçanın ana puzzle alanındaki doğru pozisyonu (genellikle 2D projelerde Z=0)")]
    public Vector3 correctPosition;
    
    [HideInInspector]
    public bool isPlaced = false;

    private Vector3 originalPosition;

    private void Start()
    {
        // Parçanın başlangıç pozisyonunu sakla
        originalPosition = transform.position;
    }
    
    // Drag işlemine başlamadan önce yapılacaklar (opsiyonel)
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Örneğin, parçanın biraz büyümesi veya gölgesinin aktif olması gibi efektler ekleyebilirsin.
    }

    // Parça sürüklenirken fare/touch pozisyonunu takip eder.
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // Parça bırakıldığında, doğru pozisyona yakınsa snap yapılır ve isPlaced true olarak işaretlenir.
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Vector3.Distance(transform.position, correctPosition) < 50f)
        {
            transform.position = correctPosition;
            isPlaced = true;
            Debug.Log("Puzzle piece placed correctly!");
        }
        else
        {
            transform.position = originalPosition;
        }
    }
}
