using UnityEngine;
using System.Collections;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _gameOverText;

    private int _score;

    private void Start()
    {
        Locator.Instance.Player.PlayerScored += AddPoints;

        Locator.Instance.Player.PlayerLost += GameOver;

        _gameOverText.text = "";
    }


    private void AddPoints()
    {
        _score++;
        _scoreText.text = "Score: " + _score;
    }

    private void GameOver()
    {
        _gameOverText.text = "Game Over";
    }

}