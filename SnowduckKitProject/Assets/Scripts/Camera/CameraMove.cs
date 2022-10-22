using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float TurnSpeed = 4.0f;  
    private float XRotate = 4.0f; 
    public float MoveSpeed = 4.0f;
    public float MoveToDuckSpeed = 10.0f;
    public int Mode = 0;//0: 전체창 1:오리
    public int MoveToFrame = 20;
    public Transform SelectedTransform;
    void Start()
    {

    }
    private void FixedUpdate()
    {


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            float yRotateSize = Input.GetAxis("Mouse X") * TurnSpeed;
            float yRotate = transform.eulerAngles.y + yRotateSize;
            float xRotateSize = -Input.GetAxis("Mouse Y") * TurnSpeed;
            XRotate = Mathf.Clamp(XRotate + xRotateSize, -45, 80);
            transform.eulerAngles = new Vector3(XRotate, yRotate, 0);

        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    ModeDuck();//오리로 카메라 이동
        //}
        if (Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f)
        {
            Mode = 0;
            if (transform.parent != null)
            {
                transform.parent.parent.GetComponent<DuckObject>().isSelected = false;
                transform.parent = null;
            }
            Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            transform.position += move * MoveSpeed * Time.deltaTime;
        }
        if (transform.parent != null)
        {
            if (transform.parent.parent.GetComponent<DuckObject>().isSelected == false)
            {
                Mode = 0;
                transform.parent = null;
            }
        }

    }
    public void ModeDuck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hit = Physics.RaycastAll(ray);
        for (int i = 0; i < hit.Length; i++)
        {
            Debug.Log(hit[i].transform.name);
            if (hit[i].collider.CompareTag("Duck"))
            {
                if (SelectedTransform != null)
                {
                    transform.parent = null;
                    SelectedTransform.GetComponent<DuckObject>().isSelected = false;
                }
                SelectedTransform = hit[i].transform;
                hit[i].transform.GetComponent<DuckObject>().isSelected = true;
                transform.position = hit[i].transform.GetChild(0).position;
                transform.rotation = hit[i].transform.GetChild(0).rotation;
                transform.parent = hit[i].transform.GetChild(0);
                Mode = 1;
            }
        }
        //if (Physics.RaycastAll(ray, out hit))
        //{
        //    Debug.Log(hit.transform.name);
        //    if (hit.collider.CompareTag("Duck"))
        //    {
        //        if (SelectedTransform != null)
        //        {
        //            transform.parent = null;
        //            SelectedTransform.GetComponent<DuckObject>().isSelected = false;
        //        }
        //        SelectedTransform = hit.transform;
        //        hit.transform.GetComponent<DuckObject>().isSelected = true;
        //        transform.position = hit.transform.GetChild(0).position;
        //        transform.rotation = hit.transform.GetChild(0).rotation;
        //        transform.parent = hit.transform.GetChild(0);
        //        Mode = 1;
        //    }
        //}

    }

}
