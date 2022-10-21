using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public bool Night;
    public bool Plus;
    public bool ZeroPlus;
    // Start is called before the first frame update
    void Start()
    {
        Night = false;
        Plus = true;
        ZeroPlus = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!Night)
        {
            transform.Rotate(Vector3.right, Time.deltaTime * 1);
        }
        else
        {
            transform.Rotate(Vector3.right, Time.deltaTime * 3);
        }
        if (transform.rotation.x >= 0f&& transform.rotation.x <= 0.9f&&!ZeroPlus)
        {
            ZeroPlus = true;
            if (Night)
            {
                Night = false;
            }
            else
            {
                Night = true;
            }

        }
        else if (transform.rotation.x > 0.9f && Plus)
        {
            Plus = false;
            if (Night)
            {
                Night = false;
            }
            else
            {
                Night = true;
            }
        }
        else if (transform.rotation.x < 0f && transform.rotation.x > -0.9f && ZeroPlus)
        {
            ZeroPlus = false;
            if (Night)
            {
                Night = false;
            }
            else
            {
                Night = true;
            }
            Plus = false;
        }
        else if (transform.rotation.x < -0.9f && !Plus)
        {
            Plus = true;
            if (Night)
            {
                Night = false;
            }
            else
            {
                Night = true;
            }
        }

    }
}
