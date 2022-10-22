using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UIinstance;
    private void Awake()
    {
        UIinstance = this;
    }
    [SerializeField]
    RectTransform ToyP; //토이 패널
    int RectPosition;
    [SerializeField]
    bool isToyPanel; //토이 패널이 열림/닫힘

    [SerializeField]
    Image[] ToyImage = new Image[7];

    List<Toy> ToyPanel = new List<Toy>();


    [SerializeField]
    Text timeText, pointText;
    public int[] time = new int[4]; // 시간 대입 변수{초, 분, 시, 일}
    void Start()
    {
        StartCoroutine(Timeset()); // 시간 카운트
        ToyP.anchoredPosition = new Vector2(-1100, 30);
        isToyPanel = false;
        //토이 패널 : 닫힘
        for (int i = 0; i < 7; i++)
        {
            ToyImage[i].enabled = false;
        }
    }
    IEnumerator Timeset()
    {
        yield return new WaitForSeconds(1);
        time[0]++;
        if (time[0] >= 60)
        {
            time[0] = 0;
            time[1]++;
            if (time[1] >= 60)
            {
                time[1] = 0;
                time[2]++;
                if (time[2] >= 24)
                {
                    time[2] = 0;
                    time[3]++;
                }
            }
        }
        StartCoroutine(Timeset());
    }
    void upperText()
    {
        timeText.text = $"{time[3]}일 {time[2]}시 {time[1]}분 {time[0]}초";
        pointText.text = $"{DataStore.GetPoint()}pt";
    }
    
    void Update()
    {
        ToyPanelM(); //토이패널 움직임
        upperText(); //위쪽 실시간 UI 조작
    }
    public void ToypanelB() //토이패널 버튼
    {
        isToyPanel = !isToyPanel;
    }
    void ToyPanelM() //토이패널 움직임만 구현한 상태
    {
        if (isToyPanel)
            RectPosition = 0;
        else
            RectPosition = -1100;   
        
        ToyP.anchoredPosition
            = new Vector2(Mathf.Lerp(ToyP.anchoredPosition.x, RectPosition, 0.05f), 30);
    }
    
}
