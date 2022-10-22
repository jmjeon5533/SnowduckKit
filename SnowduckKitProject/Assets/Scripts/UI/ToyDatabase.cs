using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyDatabase : MonoBehaviour
{
    public static ToyDatabase ToyData;
    private void Awake()
    {
        ToyData = this;
    }
    public List<Toy> ToyDB = new List<Toy>();

    public GameObject FieldItemPrefab;
    public Vector3[] pos;
    private void OnValidate()
    {
        pos = new Vector3[ToyDB.Count]; pos = new Vector3[ToyDB.Count];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
