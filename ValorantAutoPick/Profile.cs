using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValorantAutoPick
{
    public class Profile
    {
        private string name;

        public string Name { get { return name; } set { name = value; } }

        private Point characterLocation;

        public Point CharacterLocation { get { return characterLocation; } set { characterLocation = value; } }

        private Point selectLocation;

        public Point SelectLocation { get { return selectLocation; } set { selectLocation = value; } }

        public Profile (string name, Point characterLocation, Point selectLocation)
        {
            this.name = name;
            this.characterLocation = characterLocation;
            this.selectLocation = selectLocation;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
