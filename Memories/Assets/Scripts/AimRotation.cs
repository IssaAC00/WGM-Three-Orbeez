using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AinRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform _target;
    [SerializeField] 
    private float _rotationSpeed ; // Nueva variable para la velocidad de giro


    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetOrientation= _target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.green);

        Quaternion targetOrienQuater = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrienQuater, _rotationSpeed * Time.deltaTime);



    }
}
