using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsRanged : MonoBehaviour
{
    CharacterReader CharacterReader;
    CharacterInfoManager CharacterInfo;
    PlayerAttack PlayerAttack;
    public Transform fireTransform;
    public int damage;
    public Rigidbody projectile;
    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Create an instance of the shell and store a reference to its rigidbody
        Rigidbody CastProjectile = Instantiate(projectile, fireTransform.position, fireTransform.rotation) as Rigidbody;
        // Set the shell's velocity to the launch force in the fire
        // position's forward direction
        CastProjectile.velocity = projectileSpeed * fireTransform.forward;
    }
}
