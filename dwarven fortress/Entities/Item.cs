using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarven_fortress.Entities
{
    internal class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(int _Id, string _Name, string _Description)
        {
            Id = _Id;
            Name = _Name;
            Description = _Description;
        }

    }
    internal class Weapon : Item
    {
        public int Damage { get; set; }
        public Weapon(int _Id, string _Name, string _Description, int _Damage) : base(_Id, _Name, _Description)
        {
            Damage = _Damage;
        }
    }
}
