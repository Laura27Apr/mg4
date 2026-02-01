using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _flyForce = 5f;
    [SerializeField] private AudioSource _audio;

    public delegate void Delegate();
    public event Delegate PlayerScored;
    public event Delegate PlayerLost;

    private bool _isDead;

    private void Update()
    {
        if (_isDead)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fly();
        }
    }

    private void Fly()
    {
        _rigidbody.velocity = Vector2.up * _flyForce;
        _audio.Play();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isDead)
            return;

        if (other.CompareTag("ScoreZone"))
        {
            PlayerScored?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDead)
            return;

        if (collision.gameObject.CompareTag("Pipe"))
        {
            _isDead = true;
            PlayerLost?.Invoke();
        }
    }

}

