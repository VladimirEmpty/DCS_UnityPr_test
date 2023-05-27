using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.UnitHealth
{
    public sealed class EnemyHealth : IUnitHealth
    {
        public int Health { get; set; }

        public bool IsDead => Health <=0;

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
