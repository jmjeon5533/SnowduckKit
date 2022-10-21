using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    RectTransform ToyPanel; //���� �г�
    int RectPosition;
    [SerializeField]
    bool isToyPanel; //���� �г��� ����/����

    [SerializeField]
    Image[] ToyImage = new Image[7];
    public List<Toy> Toys;
    
    void Start()
    {
        ToyPanel.anchoredPosition = new Vector2(-1100, 30);
        isToyPanel = false;
        //���� �г� : ����
        for (int i = 0; i < 7; i++)
        {
            ToyImage[i].enabled = false;
        }
    }

    
    void Update()
    {
        ToyPanelM();
    }
    public void ToypanelB() //�����г� ��ư
    {
        isToyPanel = !isToyPanel;
    }
    void ToyPanelM() //�����г� ������
    {
        if (isToyPanel)
            RectPosition = 0;
        else
            RectPosition = -1100;   
        
        ToyPanel.anchoredPosition 
            = new Vector2(Mathf.Lerp(ToyPanel.anchoredPosition.x, RectPosition, 0.05f), 30);
    }

}
