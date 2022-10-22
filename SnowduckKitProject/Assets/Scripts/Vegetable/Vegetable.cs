using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public Rigidbody rb;
    public SphereCollider sphereCollider;
    public float DestroyTime;
    // Start is called before the first frame update
    void Start()
    {
        DestroyTime = 60f;
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTime -= Time.deltaTime;
        if (DestroyTime < 0)
        {
            ToyDatabase.This.RemoveToy(transform.gameObject);
        }
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
