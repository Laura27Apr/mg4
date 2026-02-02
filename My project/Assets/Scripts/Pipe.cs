using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _minSpace = -1.5f;
    [SerializeField] private float _maxSpace = 1.5f;

    //private bool _scored = false;

    private void Start()
    {
        float randomSpace = Random.Range(_minSpace, _maxSpace);
        transform.position = new Vector3(transform.position.x, randomSpace, 0);
    }

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    
}