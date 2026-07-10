using UnityEngine;
using System.Collections.Generic;
using System;
 
public class EntityHealth : MonoBehaviour
{
    public float health,maxHealth;
    public bool isDeath;\
    public EntityStat stat;

    public struct Context
    {
        public float damage;
        public EntityHealth attacker;
        public bool canceled;
    }
    List<Action<Context>> onDamageEv = new();
    List<Action<Context>> onGiveDamageEv = new();
    List<Action<Context>> onDeathEv = new();
    void Start()
    {
        stat = GetCompnent<EntityStat>();
        ResetHealth();
    }
    public void ResetHealth() 
    {
        health = maxHealth;
    }
    public void OnDeath(Action<Context> action)
   {
        onDeathEv.Add(action);
    
    
    }
    public void OnDamage(Action<Context> action)
    {

        onDamageEv.Add(action);
    }
    public void OnGiveDamage(Action<Context> action) { 
        onGiveDamageEv.Add(action);
    
    
    }


    public void GetDamage(float damage,EntityHealth attacker = null)
    {
        Context ctx = new Context();
        ctx.damage = damage;
        ctx.attacker = attacker;

        

        foreach(var c in onDamageEv)
        {
            c.Invoke(ctx);
        }
        if(attacker != null)
        {
            foreach (var c in attacker.onGiveDamageEv)
            {
                c.Invoke(ctx);
            }
        }
        
        if(ctx.canceled)
        {
            return;
        }
        float dmg = ctx.damage * (1 + stat.GetResultValue("hurtDamage") / 100 * (1 + inc/100);
        if()
        health -= dmg;
        health -= damage;
        if(health <=0)
        {
            isDeath = true;
            foreach(var c in onDeathEv)
            {
                c.Invoke(ctx);
            }
        }
        
    }


    
}
