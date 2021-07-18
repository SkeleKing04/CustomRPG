using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for creating core scriptable objects
[CreateAssetMenu(fileName = "Core", menuName = "RPG/Core")]
public class CoreSO : ScriptableObject
{
    //Name of the core
    public string name;
    //This was going to used to limit what subclasses could use what cores but it isn't used yet
    public SubclassesSO ForSubclass;
}
