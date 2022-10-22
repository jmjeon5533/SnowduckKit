using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public Rigidbody rigidbody;
    public SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            rigidbody.isKinematic = true;
            sphereCollider.isTrigger = true;
        }
        if (collision.collider.CompareTag("Duck"))
        {
            Debug.Log("Triiger");
            collision.collider.GetComponent<DuckObject>().DeleteTime += collision.collider.GetComponent<DuckObject>().RecoveryTime;
            ToyDatabase.This.RemoveToy(transform.gameObject);

        }
    }

}
