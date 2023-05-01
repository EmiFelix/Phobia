using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int HP;
    [SerializeField] protected int maxHP;

    [SerializeField] protected bool isDead;

    private void Start()
    {
        InitVariables();
    }

    public virtual void CheckHP()
    {
       if(HP <= 0)
        {
            HP = 0;
            Die();
        }

       if(HP >= maxHP)
        {
            HP = maxHP;
        }
    }

    public void Die()
    {
        isDead = true;

    }

    public void SetHPto(int hpToSetTo)
    {
        HP = hpToSetTo;
        CheckHP();

    }

    public void takeDMG(int damage)
    {
        int hpAfterDmg = HP - damage;
        SetHPto(hpAfterDmg);
    }

    public void Heal(int heal)
    {
        int hpAfterHeal = HP + heal;
        SetHPto(hpAfterHeal);
    }

    public void InitVariables()
    {
        maxHP = 100;
        SetHPto(maxHP);
        isDead = false;
    }
}
