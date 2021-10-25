using Assets.Script.AI.Controller;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controller.CollisionControl
{
    enum Element
    {
        LeftCaterpillar,
        RightCaterpillar,
        Frame,
        Tower
    }
    public class CollisionAction : MonoBehaviour
    {

        [SerializeField]
        private Dictionary<Element, Collision> Collision;
        public void Init(DamageForElement damageForElement, Action<DamageType, int> actionDamage)
        {
            Collision[Element.LeftCaterpillar].Init(damageForElement.LeftCaterpillar, actionDamage);
            Collision[Element.RightCaterpillar].Init(damageForElement.RightCaterpillar, actionDamage);
            Collision[Element.Frame].Init(damageForElement.Frame, actionDamage);
            Collision[Element.Tower].Init(damageForElement.Tower, actionDamage);          
        }
    }
}