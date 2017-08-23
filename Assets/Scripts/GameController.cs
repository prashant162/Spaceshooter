using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazards;
    public Vector3 spawnValues;
    public int hazardsCount;
    public float spawnWait;
    public float startWait;
    public float newWaveWait;
    public GUIText ScoreText;
    private int score;

    public GUIText gameOverText;
    public GUIText restartText;
    private bool gameOver;
    private bool restartGame;

	void Start ()
    {
        gameOver = false;
        restartGame = false;
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        UpdateScore();
       StartCoroutine(SpawnWaves());	
	}

    private void Update()
    {
        if(Input.GetKeyUp("r") || Input.GetKeyUp("R"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);// this is the time that will take when game starts for the first time
        while (true)
        {
            for (int i = 0; i < hazardsCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity; //identity means we dont want to rotate our hazards
                Instantiate(hazards, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait); //this pause the hazards for a moment without pausing the game
            }
            yield return new WaitForSeconds(newWaveWait);

            if(gameOver)
            {
                restartText.text = "Press 'R' to restart the Game";
                restartGame = true;
                break;
            }
        }
      
    }

    //This is exposed function to be called in the hazard destroyed's script so that value can be passed here in the GameController
    public void AddNewScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
