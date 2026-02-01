using UnityEngine;
using System.Collections;

public class GameAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _scoreAudio;
    [SerializeField] private AudioSource _hitAudio;

    private void Start()
    {
        Locator.Instance.Player.PlayerScored += PlayScoreSound;
        Locator.Instance.Player.PlayerLost += PlayHitSound;
    }

    private void PlayScoreSound()
    {
        _scoreAudio.Play();
    }

    private void PlayHitSound()
    {
        _hitAudio.Play();
    }
}