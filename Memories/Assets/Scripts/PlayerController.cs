using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    Rigidbody rb;

    [SerializeField]
    float speed;

    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    float jumpForce;

    //public GameObject cube;

    void Awake()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {

            Vector3 target = transform.position + new Vector3(x, 0, z);

            transform.LookAt(target);

            rb.velocity = new Vector3(x, 0, z).normalized * speed + Vector3.up * rb.velocity.y;


        }
        else
        {

            rb.velocity = new Vector3(0, rb.velocity.y, 0);

        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {


            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        }

        /*   if (Input.GetButtonDown("Fire1")) {

               GameObject go = GameObject.Instantiate(cube, transform.position + transform.forward * 2 , Quaternion.identity, null) as GameObject;
               go.GetComponent<Rigidbody>().AddForce(transform.forward * 100 + Vector3.up * 100);

           }

   */

    }

    private bool IsGrounded()
    {

        RaycastHit info;
        return Physics.SphereCast(transform.position, 0.4f, Vector3.down, out info, 0.15f);


    }
}
