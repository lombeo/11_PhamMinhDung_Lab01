using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject asteroidSpawner;
    public GameObject GameOverGO;
    public GameObject scoreUITextGO;
    public GameObject instructionImg;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver
    }

    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                GameOverGO.SetActive(false);
                playButton.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                playButton.SetActive(false);
                playerShip.GetComponent<PlayerControl>().Init();
                asteroidSpawner.GetComponent<AsteroidSpawner>().ScheduleAsteroidSpawner();
                break;

            case GameManagerState.GameOver:
                asteroidSpawner.GetComponent<AsteroidSpawner>().UnscheduleAsteroidSpawner();
                GameOverGO.SetActive(true);
                Invoke("ChangeToOpeningState", 8f);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void Instruction()
    {
        instructionImg.SetActive(!instructionImg.activeSelf);
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
