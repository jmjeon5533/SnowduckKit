using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable2 : MonoBehaviour
{
    public Rigidbody rb;
    public CapsuleCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            //rigidbody.isKinematic = true;
            //sphereCollider.isTrigger = true;
        }
        if (collision.collider.CompareTag("Duck"))
        {
            collision.collider.GetComponent<DuckObject>().DeleteTime += collision.collider.GetComponent<DuckObject>().RecoveryTime;
            ToyDatabase.This.RemoveToy(transform.gameObject);

        }
    }

}
