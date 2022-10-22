using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckProduce : MonoBehaviour
{
    public float ProduceTimer;
    public float MaxTimer;
    public GameObject DuckObject;
    public Vector3 MinPosition;
    public Vector3 MaxPosition;
    public GameObject FloorGameobject;
    public float ProduceHeight;

    // Start is called before the first frame update
    void Start()
    {
        FloorGameobject = GameObject.FindGameObjectWithTag("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        ProduceTimer += Time.deltaTime;
        if (ProduceTimer > MaxTimer)
        {
            ProduceTimer = 0f;
            ToyDatabase.This.AddToy(Instantiate(DuckObject, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Quaternion.identity));
            //Instantiate(DuckObject, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)),Quaternion.identity);
        }
    }
}
