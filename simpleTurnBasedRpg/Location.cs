using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTurnBasedRpg
{
    internal class Location
    {
        public List<Monster> monsterList;
        public string name;
        public bool has_visited;

        public Location(List<Monster> _monsterlist, string _name) 
        {
        name = _name;
        monsterList = _monsterlist;
        has_visited = false;
        }
    }
}
