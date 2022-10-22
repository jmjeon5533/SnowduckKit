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
    RectTransform ToyP; //���� �г�
    int RectPosition;
    [SerializeField]
    bool isToyPanel; //���� �г��� ����/����

    [SerializeField]
    Image[] ToyImage = new Image[7];

    List<Toy> ToyPanel = new List<Toy>();


    [SerializeField]
    Text timeText, pointText;
    public int[] time = new int[4]; // �ð� ���� ����{��, ��, ��, ��}
    void Start()
    {
        StartCoroutine(Timeset()); // �ð� ī��Ʈ
        ToyP.anchoredPosition = new Vector2(-1100, 30);
        isToyPanel = false;
        //���� �г� : ����
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
        timeText.text = $"{time[3]}�� {time[2]}�� {time[1]}�� {time[0]}��";
        pointText.text = $"{DataStore.GetPoint()}pt";
    }
    
    void Update()
    {
        ToyPanelM(); //�����г� ������
        upperText(); //���� �ǽð� UI ����
    }
    public void ToypanelB() //�����г� ��ư
    {
        isToyPanel = !isToyPanel;
    }
    void ToyPanelM() //�����г� �����Ӹ� ������ ����
    {
        if (isToyPanel)
            RectPosition = 0;
        else
            RectPosition = -1100;   
        
        ToyP.anchoredPosition
            = new Vector2(Mathf.Lerp(ToyP.anchoredPosition.x, RectPosition, 0.05f), 30);
    }
    
}
