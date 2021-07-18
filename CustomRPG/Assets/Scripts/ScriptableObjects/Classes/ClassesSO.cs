using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for creating class scriptable objects
[CreateAssetMenu(fileName = "Class", menuName = "RPG/Class")]
public class ClassesSO : ScriptableObject
{
    //Name of the class
    public string name;
    //Icon of the class
    public Sprite classIcon;
    //Stats giving to the player when using the class
    public float HP;
    public float baseDamage;
    public float defence;
    public float speed;
}
