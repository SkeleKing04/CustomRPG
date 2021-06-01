using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonRotate : MonoBehaviour
{
    public float RotateSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * RotateSpeed, 0, 0));
    }
}
