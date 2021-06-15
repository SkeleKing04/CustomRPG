using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCheck : MonoBehaviour
{
    public test[] pog = new test[4];

    [System.Serializable]
    public class test
    {
        public int[] testInt = new int[4];
        public int[] testInt2 = new int[4];
        public int[] testInt3 = new int[4];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
