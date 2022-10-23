using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class DuckObject : MonoBehaviour
{
    NavMeshAgent nav;
    public float DeleteTime;
    public Vector3 DestinationPoint;
    public bool Move;
    public bool isSelected = false;
    public float RecoveryTime;
    public BoxCollider BC;

    // Start is called before the first frame update
    void Start()
    {
        BC = GetComponent<BoxCollider>();
        RecoveryTime = 10f;
        Move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&isSelected)
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hit = Physics.RaycastAll(ray);
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].collider.CompareTag("Floor"))
                    {
                        DestinationPoint = hit[i].point;
                        if (nav != null)
                        {
                            nav.isStopped = false;
                        }
                    }
                }
                //if (Physics.Raycast(ray, out hit))
                //{
                //    if (hit.collider.CompareTag("Floor"))
                //    {
                //        DestinationPoint = hit.point;
                //        if (nav != null)
                //        {
                //            nav.isStopped = false;
                //        }
                //    }

                //}
            }
        }
        if (Move&&isSelected)
        {
            nav.SetDestination(DestinationPoint);
        }
        DeleteTime -= Time.deltaTime;
        if (DeleteTime < 0)
        {
            isSelected = false;
            //Destroy(transform.gameObject);
            StartCoroutine(DestroyDuck());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            if (!BC.isTrigger)
            {
                BC.isTrigger = true;
            }
            DestinationPoint.y = transform.position.y;
            nav = GetComponent<NavMeshAgent>();
            nav.enabled = true;
            StartCoroutine(MoveStart());
        }
        else if (collision.collider.gameObject.CompareTag("Duck"))
        {
            if (nav != null)
            {
                nav.isStopped = true;
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            if (!BC.isTrigger)
            {
                BC.isTrigger = true;
            }
            DestinationPoint.y = transform.position.y;
            nav = GetComponent<NavMeshAgent>();
            nav.enabled = true;
            StartCoroutine(MoveStart());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vegetable"))
        {
            DeleteTime += RecoveryTime;
            ToyDatabase.This.RemoveToy(other.gameObject);
        }
    }
    IEnumerator DestroyDuck()
    {
        yield return new WaitForSeconds(2f);
        ToyDatabase.This.RemoveToy(transform.gameObject);
    }

    IEnumerator MoveStart()
    {
        yield return new WaitForSeconds(2f);
        Move = true;
    }
}
