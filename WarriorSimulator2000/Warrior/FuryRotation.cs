﻿using System;
using WarriorSimulator2000.Engine;

namespace WarriorSimulator2000.Warrior
{
    public class FuryRotation : RotationBase, Rotation
    {
        private Skill[] GCDPriorities = new Skill[]
        {
            new BattleShout(),
            new DeathWish(),
            new Recklessness(),
            new Execute(),
            new Overpower(),
            new Bloodthirst(),
            new Whirlwind()
        };


        public Skill GCDNext(CharacterStats stats)
        {
            throw new NotImplementedException();
        }

        public bool MayMainHand(CharacterStats stats)
        {
            throw new NotImplementedException();
        }

        public bool MayOffHand(CharacterStats stats)
        {
            throw new NotImplementedException();
        }

        public Skill? NoGCDNext(CharacterStats stats)
        {
            throw new NotImplementedException();
        }
    }
}