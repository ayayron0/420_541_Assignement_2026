using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score{ get; private set; }
    private int levelStartScore;

    void Awake(){

        if (Instance != null && Instance != this){

            Destroy(gameObject);
            return;

        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount){

        Score += amount;
        Debug.Log("Score: " + Score);

    }

    public void ResetScore(){

        Score = 0;

    }

    public void SaveLevelStartScore(){

        levelStartScore = Score;

    }

    public void RestoreLevelStartScore(){

        Score = levelStartScore;

    }

}
