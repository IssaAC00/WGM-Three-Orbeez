using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLife;
    public GameObject _explosionEffectPrefab; // Cambiado el nombre de la variable

    private void Start()
    {
      
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_explosionEffectPrefab != null)
            {
                Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
