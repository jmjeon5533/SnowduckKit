using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckObject : MonoBehaviour
{
    NavMeshAgent nav;
    public float DeleteTime;
    public GameObject DestinationObject;
    public Vector3 DestinationPoint;
    public bool Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = false;
        DestinationPoint.x = transform.position.x;
        DestinationPoint.z = transform.position.z;
        DestinationObject = GameObject.FindGameObjectWithTag("Destination");
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
                Debug.Log(hit.transform.name);
                Debug.Log(hit.point);
                DestinationPoint = hit.point;
                if (nav != null)
                {
                    nav.isStopped = false;
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
            Destroy(transform.gameObject);
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
        else if (collision.collider.gameObject.name.Contains("DuckObject"))
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
