using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Knight : Player
    {
        public Knight() : base(150, 8) { }
        public Knight(int hp, int damage) : base(hp, damage) { }
        public override void Attack(Creature target)
        {
            base.AttacksNum(target, 2);
        }
    }

    class Mage : Player
    {
        public Mage() : base(100, 30) { }
        public Mage(int hp, int damage) : base(hp, damage) { }
        public override void Attack(Creature target)
        {
            base.AttacksNum(target, 1);
        }
    }

    class Archer : Player
    {
        public Archer() : base(125, 7) { }
        public Archer(int hp, int damage) : base(hp, damage) { }
        public override void Attack(Creature target)
        {
            base.AttacksNum(target, 3);
        }
    }
}
