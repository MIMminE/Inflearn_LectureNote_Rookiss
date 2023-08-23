using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Orc : Monster
    {
        public Orc() : base(50, 5) { }
        public Orc(int hp, int damage) : base(hp, damage) { }
        public override void Attack(Creature target)
        {
            base.AttacksNum(target,1);
        }
    }

    class Skeleton : Monster
    {
        public Skeleton() : base(40, 2) { }
        public Skeleton(int hp, int damage) : base(hp, damage) { }
        public override void Attack(Creature target)
        {
            base.AttacksNum(target, 2);
        }
    }

    class Harpy : Monster
    {
        public Harpy() : base(35, 1) { }
        public Harpy(int hp, int damage) : base(hp, damage) { }
        public override void Attack(Creature target)
        {
            base.AttacksNum(target, 7);
        }
    }
}
