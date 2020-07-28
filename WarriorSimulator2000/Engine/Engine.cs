using System;
using System.Collections.Generic;
using WarriorSimulator2000.Calculators;

namespace WarriorSimulator2000.Engine
{
    public class Engine
    {
        private Actor actor;
        private Target target;
        private long ticks;

        private Dictionary<string, Swing> Log = new Dictionary<string, Swing>();

        public Engine(Actor actor, Target target)
        {
            this.actor = actor;
            this.target = target;
        }

        public void Start()
        {
            for(var i = 0; i < ticks; i++)
            {
                CalculateHitTables();
                CastGCDSkill();
                CastNoGCDSkill();
                SwingMainHand();
                SwingOffhand();
            }
        }

        private void SwingOffhand()
        {
            if(actor.Stats.OffHand == null)
            {
                return;
            }

            if (actor.Stats.OffHand.MaySwing)
            {
                SwingWeapon(actor.Stats.OffHand);
            }
        }

        private void SwingWeapon(Weapon weapon)
        {
            Outcome outcome = weapon.Swing();
            int damage = weapon.CalculateDamage(outcome, actor.Stats);

            if (actor.Class == WowClass.Warrior)
            {
                var rage = Damage.CalculateRage(outcome, actor.Stats, damage, weapon);
                actor.Stats.Resource += WowMath.ToInt(rage);
            }
        }

        private void SwingMainHand()
        {
            if (actor.Stats.MainHand.MaySwing)
            {
                SwingWeapon(actor.Stats.MainHand);
            }
        }

        private void CastNoGCDSkill()
        {
            Skill? skill = actor.Rotation.NoGCDNext(actor.Stats, target);
            if (skill != null)
            {
                var swing = skill.Activate(actor.Stats, target);
                Log.Add(skill.Name, swing);
            }
        }

        private void CastGCDSkill()
        {
            if (actor.Rotation.GCDAvailable)
            {
                var skill = actor.Rotation.GCDNext(actor.Stats, target);
                var swing = skill.Activate(actor.Stats, target);

                Log.Add(skill.Name, swing);

                //resolve swing
                actor.Rotation.StartGCD();
            }
        }

        private void CalculateHitTables()
        {
            if (/*TODO Something to notice that we need to recalculate attack table*/ true)
            {
                actor.Stats.MainHand.Table = HitTable.GenerateMainHandTable(actor.Stats, target);
                if (actor.Stats.OffHand != null)
                {
                    actor.Stats.OffHand.Table = HitTable.GenerateOffHandTable(actor.Stats, target);
                }
            }
        }
    }
}
