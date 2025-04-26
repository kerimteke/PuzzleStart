using UnityEngine;

public class GameStateManager : MonoBehaviour 
{
    public static GameStateManager Instance { get; private set; }

    private IGameState currentState;

    private void Awake() 
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void SetState(IGameState newState) 
    {
        // Eğer geçerli bir state varsa, çıkış metodunu çalıştır.
        if (currentState != null) {
            currentState.ExitState();
        }
        currentState = newState;
        currentState.EnterState();
    }

    private void Update() 
    {
        if (currentState != null) {
            currentState.UpdateState();
        }
    }
}
