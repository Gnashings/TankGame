using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyStats", menuName = "Stats/Enemy")]
public class EnemyStatsPerameters : ScriptableObject
{
    public new string enemyName;
    public float health;
    public bool canMove;
    public float fireRate;
    public int damage;
}
