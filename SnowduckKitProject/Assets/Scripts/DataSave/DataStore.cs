using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public List<GameObject> SaveObjects = new List<GameObject>();
    public int Point;
    public List<string> Achievement = new List<string>();

}

public class DataStore : MonoBehaviour
{
    private static SaveData _Save = new SaveData();

    
    public static bool SetAchievement(string _Achievement)// ���� ����. ������ ȹ���� ������ �������ּ���.
    {
        if (!_Save.Achievement.Contains(_Achievement))
        {
            _Save.Achievement.Add(_Achievement);
            return true;
        }
        return false;
    }

    public static List<string> SetAchievement()
    {
        return _Save.Achievement;
    }

    
    public static void AddObject (GameObject _NewObject)// ������Ʈ ���� �� ���۽��� �ּ���.
    {
        _Save.SaveObjects.Add(_NewObject);
    }

    
    public static void RemoveObject(GameObject _NewObject)// ������Ʈ ���� �� ���۽��� �ּ���.
    {
        _Save.SaveObjects.Remove(_NewObject);
    }

    
    public static void AddPoint(int _Point)// ����Ʈ ȹ�� �� ����.
    {
        _Save.Point += _Point;
    }
    
    public static void SetPoint (int _Point)// ����Ʈ ������ ���� �� ����.
    {
        _Save.Point = _Point;
    }
    
    public static int GetPoint ()// ���� ����Ʈ ������ �˱� ���ؼ� ����.
    {
        return _Save.Point;
    }


    private void Start()
    {
        Load();
    }

    private void Load()
    {
        string _SaveData = PlayerPrefs.GetString("Save");
        if (_SaveData != null)
        {
            _Save = JsonUtility.FromJson<SaveData>(_SaveData);
        }
        else
        {
            _Save = new SaveData();
        }
    }


    private void OnDestroy()
    {
        Save();
    }

    private void Save()
    {
        string _SaveData = JsonUtility.ToJson(_Save);
        PlayerPrefs.SetString("Save", _SaveData);
    }

}
