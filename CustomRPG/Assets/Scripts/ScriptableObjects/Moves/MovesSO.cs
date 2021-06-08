using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "RPG/Move")]
public class MovesSO : ScriptableObject
{
    PlayerInfomation playerInfo;
    AttackManager atkManager;
    public WaitForSeconds waitTime;
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
        atkManager = FindObjectOfType<AttackManager>();
    }
    public void CastAttack()
    {
        switch (moveType)
        {
            case MoveType.melee:
                MeleeAtk();
                break;
            case MoveType.ranged:
                Debug.Log("Casted " + name + " " + moveType + " attack");
                break;
            case MoveType.boost:

                Debug.Log("Casted " + name + " " + moveType);
                break;
        }
    }
    IEnumerator MeleeAtk()
    {
        Debug.Log("Casting " + name + " " + moveType + " attack");
        if (atkManager.Attacking == false)
        {
            atkManager.Attacking = true;
            //enable rigidbody
            yield return new WaitForSeconds(2);
            //disable rigidbody
            atkManager.Attacking = false;
            Debug.Log("Casted " + name + " " + moveType + " attack");
        }
        else if (atkManager.Attacking == true)
        {
            Debug.Log(atkManager.Attacking);
        }
        atkManager.Attacking = false;
    }
}
