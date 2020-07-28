using System;
using WarriorSimulator2000.Calculators;

namespace WarriorSimulator2000.Engine
{
    public class Engine
    {
        private Actor actor;
        private Target target;
        private long ticks;

        public Engine(Actor actor, Target target)
        {
            this.actor = actor;
            this.target = target;
        }

        public void Start()
        {
            for(var i = 0; i < ticks; i++)
            {
                if(/*TODO Something to notice that we need to recalculate attack table*/ true)
                {
                    actor.Stats.MainHand.Table = HitTable.GenerateMainHandTable(actor.Stats, target);
                    if(actor.Stats.OffHand != null)
                    {
                        actor.Stats.OffHand.Table = HitTable.GenerateOffHandTable(actor.Stats, target);
                    }
                }


                if(actor.Rotation.GCDAvailable)
                {
                    var skill = actor.Rotation.GCDNext(actor.Stats);
                    var swing = skill.Activate(actor.Stats);
                    //resolve swing
                    actor.Rotation.StartGCD();
                }

                Skill? otherSkill = actor.Rotation.NoGCDNext(actor.Stats);
                if(otherSkill != null)
                {
                    otherSkill.Activate(actor.Stats);
                }

                if(actor.Rotation.MayMainHand(actor.Stats))
                {
                    //swing MH weapon
                    //Resolve Rage Gain.
                }

                if(actor.Rotation.MayOffHand(actor.Stats))
                {
                    //swing OH Weapon
                    //Resolve rage gain
                }

            }
        }

       

        
    }
}
