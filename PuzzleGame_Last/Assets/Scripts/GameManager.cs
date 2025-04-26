using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public UIManager uiManager;
    public PuzzleManager puzzleManager;
    public AudioManager audioManager; // İstersen

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManagers();
        } else {
            Destroy(gameObject);
        }
    }

    private void InitializeManagers() {
        // UIManager, PuzzleManager gibi diğer manager'ları sahneye ekleyerek initialize et.
        // Gerekirse bu manager'ları prefab olarak oluşturup, Instantiate edebilirsin.
    }
}

