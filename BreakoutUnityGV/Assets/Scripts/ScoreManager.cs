using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum ScoreState { Win, Lose, Pause, Playing };

public class ScoreManager : MonoBehaviour {

    public GameObject WinnerButton;
    public GameObject Ball;
    
    public static int Lives = 3;
    public static int Level = 1;
    public static int Score = 0;
    public static int NumberOfBlocks = 0;

    public static ScoreState state = ScoreState.Playing;

    Texture2D paddle;
    public Text LivesText, LevelText, ScoreText;
   
    Vector2 scoreLoc, livesLoc, levelLoc;

    private static void SetupNewGame()
    {
        Lives = 3;
        Level = 1;
        Score = 0;
    }

    public void ScoreAdd()
    {
        Score = Score + 1;
    }

    public void ScoreReset()
    {
        Score = 0;
    }

    public void LiveSubtract()
    {
        Lives = Lives - 1;
    }

    public void LiveReset()
    {
        Lives = 3;
    }

    public void NextLevel()
    {
        Level = Level + 1;
    }

    public void LevelReset()
    {
        Level = 1;
    }

    void Awake()
    {
        ScoreManager.SetupNewGame();
    }

    // Use this for initialization
	void Start () {
        LivesText.text = "Lives: " + ScoreManager.Lives.ToString();
        LevelText.text = "Level: " + ScoreManager.Level.ToString();
        ScoreText.text = "Score: " + ScoreManager.Score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        LivesText.text = "Lives: " + ScoreManager.Lives.ToString();
        LevelText.text = "Level: " + ScoreManager.Level.ToString();
        ScoreText.text = "Score: " + ScoreManager.Score.ToString();

        AllBlocksGone();
	}

    private void AllBlocksGone()
    {
        if (state == ScoreState.Win)
        {
            WinnerButton.SetActive(true);
            Ball.SetActive(false);
        }
    }
}
