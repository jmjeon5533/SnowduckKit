using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckButton : MonoBehaviour
{
    public GameObject DuckProduce;
    public Image FillImage;
    // Start is called before the first frame update
    void Start()
    {
        FillImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        FillImage.fillAmount = DuckProduce.GetComponent<DuckProduce>().ProduceTimer / DuckProduce.GetComponent<DuckProduce>().MaxTimer;
    }
}
