using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float TurnSpeed = 4.0f;  
    private float XRotate = 0.0f; 
    public float MoveSpeed = 4.0f;
    public float MoveToDuckSpeed = 10.0f;
    public int Mode = 0;//0: 전체창 1:오리
    public int MoveToFrame = 20;
    void Start()
    {

    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)){
            Cursor.visible = false;
            float yRotateSize = Input.GetAxis("Mouse X") * TurnSpeed;
            float yRotate = transform.eulerAngles.y + yRotateSize;
            float xRotateSize = -Input.GetAxis("Mouse Y") * TurnSpeed;
            XRotate = Mathf.Clamp(XRotate + xRotateSize, -45, 80);
            transform.eulerAngles = new Vector3(XRotate, yRotate, 0);

        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            ModeDuck();//오리로 카메라 이동
        }
        Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        transform.position += move * MoveSpeed * Time.deltaTime;
    }
    public void ModeDuck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Duck"))
            {
                transform.position = hit.transform.GetChild(0).position;
                transform.rotation = hit.transform.GetChild(0).rotation;
                transform.parent = hit.transform.GetChild(0);
            }
        }

    }

}
