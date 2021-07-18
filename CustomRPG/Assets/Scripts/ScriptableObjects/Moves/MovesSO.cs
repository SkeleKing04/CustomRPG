using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script for creating move scriptable objects
[CreateAssetMenu(fileName = "Move", menuName = "RPG/Move")]
public class MovesSO : ScriptableObject
{
    //Name of the move
    public string name;
    //What type of move
    public enum MoveType
    {
        phyical,
        magical,
        status
    }
    public MoveType moveType;
    //The damage & speed of the move
    public float damage;
    public float speed; //UNUSED
    //Stats of the move
    public enum stats
    {
        NA,
        HP,
        baseDamage,
        defence,
        speed
    };

    //~~~ USED WHEN "status" TYPE MOVE
    //What stat is boosted
    public stats boostStat;
    //If the move targets the player or enemy
    public bool effectTarget;
    //The amount of boost
    public float boostAmmount;
    //How long the boost lasts for
    public float boostDuration; //UNUSED
    //~~~

    //Number of times the move can be used
    public int powerPoint; //UNUSED
    //The number of cores the move holds
    public int coreSlots;
}
