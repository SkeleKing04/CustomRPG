using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "RPG/Move")]
public class MovesSO : ScriptableObject
{
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public string name;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    public ClassesSO ForClass;
    public enum MoveType
    {
        melee,
        physicsRanged,
        ranged,
        boost,
        summon
    }
    public MoveType moveType;
    public int damage;
    public Rigidbody projectile;
    public float projectileSpeed;
    //public effectSO[] effect;
    //private GameObject cores;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
