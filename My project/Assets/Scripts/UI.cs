using UnityEngine;
using System.Collections;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _score;

    private void Start()
    {
        Locator.Instance.Player.PlayerScored += AddPoints;
    }

    private void AddPoints()
    {
        _score++;
        _scoreText.text = "Score: " + _score;
    }

}