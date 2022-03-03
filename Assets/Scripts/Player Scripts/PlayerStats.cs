using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public float totalHealth;
    public float totalArmor;
    public float health;
    public float armor;

    [Header("Body Mods")]
    public BodyStats noBodyMod;
    public BodyStats gustav;
    public BodyStats bigBomba;
    public float bombaCooldown;
    public float gustavArmorReduction;
    public BodyMods bodyMods;

    [Header("Editable Scripts")]
    public TankBodyController tankbody;
    public FireGun firegun;
    public Explosion bigBombaBomb;
    public AudioClip bombaExplosionSound;
    private bool canBomba;
    private void Start()
    {
        ResetAllStats();
        CheckBodyMod();
        SetHealthAndArmor();
    }





    #region BodyMods
    private void CheckBodyMod()
    {
        if (bodyMods.HasFlag(BodyMods.noMod))
        {
            gameObject.transform.GetComponentInChildren<TankBodyController>().topSpeed = noBodyMod.topSpeed;
            totalHealth = noBodyMod.health;
            totalArmor = noBodyMod.armor;
        }

        if (bodyMods.HasFlag(BodyMods.bigBomba))
        {
            gameObject.GetComponentInChildren<TankBodyController>().topSpeed = noBodyMod.topSpeed;
            totalHealth = noBodyMod.health;
            totalArmor = noBodyMod.armor;
            canBomba = true;
        }

        if (bodyMods.HasFlag(BodyMods.gustav))
        {
            gameObject.GetComponentInChildren<TankBodyController>().topSpeed = gustav.topSpeed;
            totalHealth = gustav.health;
            totalArmor = gustav.armor;
            gustavArmorReduction = 3;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            if(canBomba == true)
            {
                canBomba = false;
                bigBombaBomb.Explode();
                Debug.Log("bombabomb");
                StartCoroutine(BombaCooldown());
            }
        }    
    }
    IEnumerator BombaCooldown()
    {
        
        yield return new WaitForSeconds(bombaCooldown);

        canBomba = true;
    }

    public enum BodyMods
    {
        noMod,
        bigBomba,
        gustav,
    };
    #endregion

    public void TakeDamage(float damage)
    {
        if (armor > 0)
        {
            //check for damage reduciton
            damage -= gustavArmorReduction;
            if (damage <= 0)
            {
                return;
            }    

            //split the damage and calculate the results correctly.
            if (armor - damage <= 0)
            {
                float leftOverDamage;
                leftOverDamage = damage - armor;
                armor = 0;
                health -= leftOverDamage;
                return;
            }
            else
                armor -= damage;
        }
        else
            health -= damage;
    }

    public void SetHealthAndArmor()
    {
        health = totalHealth;
        armor = totalArmor;
    }

    public void ResetAllStats()
    {
        health = 0;
        armor = 0;
        totalHealth = 0;
        totalArmor = 0;
        gustavArmorReduction = 0;
    }


    public enum Turrets
    {
        noMod,
        riskyBusiness,
        newtonsApple,
    };
}
