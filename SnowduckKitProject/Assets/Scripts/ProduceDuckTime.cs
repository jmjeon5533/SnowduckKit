using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//임시 시간 타임
//UI 시간에 맞춰서 조금 후에 다시 설정
public class ProduceDuckTime : MonoBehaviour
{
    public float ProduceTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProduceTime += Time.deltaTime;
        if (ProduceTime > 60)
        {

        }
    }
}
