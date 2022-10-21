using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckObject : MonoBehaviour
{
    NavMeshAgent nav;
    public float DeleteTime;
    public GameObject DestinationObject;
    public bool Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            nav.SetDestination(DestinationObject.transform.position);
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
            DestinationObject = GameObject.FindGameObjectWithTag("Destination");
            nav = GetComponent<NavMeshAgent>();
            nav.enabled = true;
            StartCoroutine(MoveStart());
        }
    }
    IEnumerator MoveStart()
    {
        yield return new WaitForSeconds(2f);
        Move = true;
    }
}
