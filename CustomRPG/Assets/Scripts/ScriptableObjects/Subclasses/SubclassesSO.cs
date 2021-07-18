using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for creating Subclass scriptable objects
[CreateAssetMenu(fileName = "Subclass", menuName = "RPG/Subclass")]
public class SubclassesSO : ScriptableObject
{
    //Name of the Subclass
    public string name;
    //Colour of the Subclass
    //Used for backgrounds & character details
    public Color subclassColour;
}
