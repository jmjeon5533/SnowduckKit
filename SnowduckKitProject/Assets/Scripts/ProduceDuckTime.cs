using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ӽ� �ð� Ÿ��
//UI �ð��� ���缭 ���� �Ŀ� �ٽ� ����
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
