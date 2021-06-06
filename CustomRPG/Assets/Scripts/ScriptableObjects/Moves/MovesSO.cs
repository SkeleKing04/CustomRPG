using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "RPG/Move")]
public class MovesSO : ScriptableObject
{
    PlayerInfomation playerInfo;
    public string name;
    public enum MoveType
    {
        melee,
        ranged,
        boost
    }
    public MoveType moveType;
    public float damage;
    public Collider hitBox;
    public Rigidbody projectile;
    public float projectileSpeed;
    public enum stats
    {
        NA,
        HP,
        baseDamage,
        defence,
        speed
    };
    public stats boostStat;
    public float boostAmmount;
    public float boostDuration;
    public float Cooldown;
    //public effectSO[] effect;
    //private GameObject cores;
    void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfomation>();
    }
    public void CastAttack()
    {
        switch (moveType)
        {
            case MoveType.melee:
                Debug.Log("Casted " + name + " " + moveType + " attack");
                break;
            case MoveType.ranged:
                Debug.Log("Casted " + name + " " + moveType + " attack");
                break;
            case MoveType.boost:

                Debug.Log("Casted " + name + " " + moveType);
                break;
        }
    }
}
