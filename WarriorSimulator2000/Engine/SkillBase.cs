using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarriorSimulator2000.Engine
{
    public class SkillBase
    {
        public virtual int Cooldown {get; set;}

        public bool CanActivate() => Cooldown <= 0;
    }
}
