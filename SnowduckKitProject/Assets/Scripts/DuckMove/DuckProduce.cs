using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckProduce : MonoBehaviour
{
    public float ProduceTimer;
    public float MaxTimer;
    public GameObject DuckObject;
    public GameObject DuckObject2;
    public GameObject Penguin1;
    public GameObject Penguin2;
    public GameObject GoldDuck1;
    public GameObject GoldDuck2;
    public Vector3 MinPosition;
    public Vector3 MaxPosition;
    public GameObject FloorGameobject;
    public float ProduceHeight;
    public float GaugeClickAmount;
    public GameObject Apple1;
    public GameObject Apple2;
    public float VegetableTimer;
    public float VegetableMax;

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
            //Instantiate(DuckObject, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)),Quaternion.identity);
            int RandomInt = Random.Range(0, 6);
            if (RandomInt == 0)
            {
                ToyDatabase.This.AddToy(Instantiate(DuckObject, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Quaternion.identity));
            }
            else if (RandomInt == 1)
            {
                ToyDatabase.This.AddToy(Instantiate(DuckObject2, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Quaternion.identity));
            }
            else if (RandomInt == 2)
            {
                ToyDatabase.This.AddToy(Instantiate(Penguin1, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Quaternion.identity));
            }
            else if (RandomInt == 3)
            {
                ToyDatabase.This.AddToy(Instantiate(Penguin2, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Quaternion.identity));
            }
            else if (RandomInt == 4)
            {
                ToyDatabase.This.AddToy(Instantiate(GoldDuck1, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Quaternion.identity));
            }
            else if (RandomInt == 5)
            {
                ToyDatabase.This.AddToy(Instantiate(GoldDuck2, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Quaternion.identity));
            }

        }
        VegetableTimer += Time.deltaTime;
        if(VegetableTimer> VegetableMax)
        {
            VegetableTimer = 0f;
            int RandomInt = Random.Range(0, 2);
            if (RandomInt == 0)
            {
                ToyDatabase.This.AddToy(Instantiate(Apple1, new Vector3(Random.Range(MinPosition.x, MaxPosition.x), FloorGameobject.transform.position.y + ProduceHeight, Random.Range(MinPosition.z, MaxPosition.z)), Apple1.transform.rotation));
            }
        }
    }
    public void GaugeButtonClick()
    {
        ProduceTimer += GaugeClickAmount;
    }
}
