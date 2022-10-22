using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckProduce : MonoBehaviour
{
    public float ProduceTimer;
    public float MaxTimer;
    public GameObject DuckObject;
    public GameObject DuckObject2;
    public Vector3 MinPosition;
    public Vector3 MaxPosition;
    public GameObject FloorGameobject;
    public float ProduceHeight;
    public float GaugeClickAmount;

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
            int RandomInt = Random.Range(0, 2);
            if (RandomInt == 0)//¿À¸®1
            {
                Instantiate(DuckObject, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Quaternion.identity);
            }
            else if (RandomInt == 1)
            {
                Instantiate(DuckObject2, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Quaternion.identity);
            }
        }
    }
    public void GaugeButtonClick()
    {
        ProduceTimer += GaugeClickAmount;
    }
}
