using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Controller.CollisionControl
{
    public class Collision : MonoBehaviour
    {

        const string tagTank = "Tank";
        const string tagProjectile = "Projectile";

        Action<DamageType, int> actionDamage;
       private int partDamage;

      

        public void Init(int damage, Action<DamageType, int> actionDamage)
        {
            this.actionDamage = actionDamage;
            partDamage = damage;
            
        }
        private void OnCollisionEnter(UnityEngine.Collision collision)
        {

            if (collision.transform.tag == tagTank)
            {
                actionDamage.Invoke(DamageType.Projectile, partDamage);
            }
            else if (collision.transform.tag == tagProjectile)
            {
                actionDamage.Invoke(DamageType.Ram, partDamage);
            }

        }

    }
}