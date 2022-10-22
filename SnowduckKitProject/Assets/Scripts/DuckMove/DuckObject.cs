using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckObject : MonoBehaviour
{
    NavMeshAgent nav;
    public float DeleteTime;
    public Vector3 DestinationPoint;
    public bool Move;

    // Start is called before the first frame update
    void Start()
    {
        Move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Floor"))
                {
                    DestinationPoint = hit.point;
                    if (nav != null)
                    {
                        nav.isStopped = false;
                    }
                }

            }
        }
        if (Move)
        {
            nav.SetDestination(DestinationPoint);
        }
        DeleteTime -= Time.deltaTime;
        if (DeleteTime < 0)
        {
            //Destroy(transform.gameObject);
            ToyDatabase.This.RemoveToy(transform.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            DestinationPoint.y = transform.position.y;
            nav = GetComponent<NavMeshAgent>();
            nav.enabled = true;
            StartCoroutine(MoveStart());
        }
        else if (collision.collider.gameObject.name.Contains("Duck"))
        {
            nav.isStopped=true;
        }
    }

    IEnumerator MoveStart()
    {
        yield return new WaitForSeconds(2f);
        Move = true;
    }
}
