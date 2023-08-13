using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour


{
    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private float _timer = 2f;
  
    [SerializeField]
    private int _counter;

    [SerializeField]
    private int _maxCounter = 20;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(FireBullet_ME());
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator FireBullet_ME()
    {
        Debug.Log("comienzo");
        for (int i = 0; i< _maxCounter; i++)
        {
            _counter++;
            Instantiate(_bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(_timer);


            }
        Debug.Log("fin");

    }
}
