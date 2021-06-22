using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "RPG/Move")]
public class MovesSO : ScriptableObject
{
    PlayerInfomation playerInfo;
    BattleScene battleScene;
    public WaitForSeconds waitTime;
    public string name;
    public enum MoveType
    {
        phyical,
        magical,
        status
    }
    public MoveType moveType;
    public float damage;
    public float speed;
    public enum stats
    {
        NA,
        HP,
        baseDamage,
        defence,
        speed
    };
    public stats boostStat;
    public bool effectTarget;
    public float boostAmmount;
    public float boostDuration;
    public int powerPoint;
    //public effectSO[] effect;
    //private GameObject cores;
}
