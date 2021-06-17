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
    public void CastAttack(float senderHP, float senderBaseDamage, float senderDefence, float senderSpeed, float moveDamage, float targetHP, float targetBaseDamage, float targetDefence, float targetSpeed)
    {
        int damage = 0;
        switch (moveType)
        {
            case MoveType.phyical:
                int rnd = Mathf.FloorToInt((Random.Range(10, 21)) / 10);
                damage = (Mathf.FloorToInt(Mathf.RoundToInt(senderBaseDamage * moveDamage / 2)/ targetDefence)) * rnd;
                Debug.Log("Casted " + name + " " + moveType + " attack!\nIt dealt " + damage.ToString() + " damage." + rnd);
                break;
            case MoveType.magical:
                damage = (Mathf.FloorToInt(Mathf.RoundToInt((moveDamage * 10) / targetDefence)));
                Debug.Log("Casted " + name + " " + moveType + " attack!\nIt dealt " + damage.ToString() + " damage.");
                break;
            case MoveType.status:
                switch (effectTarget)
                {
                    case false:
                        switch (boostStat)
                        {
                            case stats.HP:
                                senderHP += boostAmmount;
                                break;
                            case stats.baseDamage:
                                senderBaseDamage += boostAmmount;
                                break;
                            case stats.defence:
                                senderDefence += boostAmmount;
                                break;
                            case stats.speed:
                                senderSpeed += boostAmmount;
                                break;
                        }
                        break;
                    case true:
                        switch (boostStat)
                        {
                            case stats.HP:
                                targetHP += boostAmmount;
                                break;
                            case stats.baseDamage:
                                targetBaseDamage += boostAmmount;
                                break;
                            case stats.defence:
                                targetDefence += boostAmmount;
                                break;
                            case stats.speed:
                                targetSpeed += boostAmmount;
                                break;
                        }
                        break;
                }
                Debug.Log("Casted " + name + " " + moveType + " attack");
                break;
        }
    }
}
