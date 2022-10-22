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
    public GameObject[] AllPrefebs;

    public static bool SetAchievement(string _Achievement)// ���� ����. ������ ȹ���� ������ �������ּ���.
    {
        if (!_Save.Achievement.Contains(_Achievement))
        {
            _Save.Achievement.Add(_Achievement);
            return true;
        }
        return false;
    }

    public static List<string> GetAchievement()// ���� ���� �о��.
    {
        return _Save.Achievement;
    }

    public static bool AddObject(GameObject _NewObject)// ������Ʈ ���� �� ���۽��� �ּ���.
    {
        if (!_Save.SaveObjects.Contains(_NewObject))
        {
            _Save.SaveObjects.Add(_NewObject);
            return true;
        }
        return false;
    }

    public static void RemoveObject(GameObject _NewObject)// ������Ʈ ���� �� ���۽��� �ּ���.
    {
        _Save.SaveObjects.Remove(_NewObject);
    }


    public static void AddPoint(int _Point)// ����Ʈ ȹ�� �� ����.
    {
        _Save.Point += _Point;
    }

    public static void SetPoint(int _Point)// ����Ʈ ������ ���� �� ����.
    {
        _Save.Point = _Point;
    }

    public static int GetPoint()// ���� ����Ʈ ������ �˱� ���ؼ� ����.
    {
        return _Save.Point;
    }


    private void Start()
    {
        AllPrefebs = Resources.LoadAll<GameObject>("Prefabs");
        Load();
        InvokeRepeating("Save", 60f, 60f);
    }

    private void Load()
    {
        string _SaveData = PlayerPrefs.GetString("Save");
        Debug.Log(_SaveData);
        SaveDataFormat nSDF = new SaveDataFormat();
        if (_SaveData != null)
        {
            nSDF = JsonUtility.FromJson<SaveDataFormat>(_SaveData);
            _Save.Point = nSDF.Point;
            _Save.Achievement = nSDF.Achievement;

            for (int i = 0; i < nSDF.Name.Count; i++)
            {
                foreach (GameObject nOb in AllPrefebs)
                {
                    if (nOb.name == nSDF.Name[i])
                    {
                        GameObject nGO = Instantiate(nOb, nSDF.Pos[i], Quaternion.Euler(nSDF.Rot[i]));
                        ToyDatabase.This.AddToy(nGO);
                        //_Save.SaveObjects.Add(nGO);
                        break;
                    }
                }
            }
        }
        else
        {
            _Save = new SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        SaveDataFormat nSDF = new SaveDataFormat();
        nSDF.Point = GetPoint();
        foreach (GameObject nGO in _Save.SaveObjects)
        {
            nSDF.Name.Add(nGO.name.Substring(0, nGO.name.Length - 7));
            nSDF.Pos.Add(nGO.transform.position);
            nSDF.Rot.Add(nGO.transform.rotation.eulerAngles);
        }
        nSDF.Achievement = _Save.Achievement;

        string _SaveData = JsonUtility.ToJson(nSDF);
        PlayerPrefs.SetString("Save", _SaveData);
        Debug.Log(_SaveData);
    }

}

[SerializeField]
public class SaveDataFormat
{
    public int Point;
    public List<string> Name = new List<string>();
    public List<Vector3> Pos = new List<Vector3>();
    public List<Vector3> Rot = new List<Vector3>();
    public List<string> Achievement = new List<string>();
}