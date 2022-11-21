using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValorantAutoPick
{
    public class Config
    {
        private int favoriteIndex;

        public int FavoriteIndex { get { return favoriteIndex; } set { favoriteIndex = value; } }

        private int[] speed;

        public int[] Speed { get { return speed; } }

        public Config(int favoriteIndex, int[] speed)
        {
            this.favoriteIndex = favoriteIndex;
            if (speed == null)
                this.speed = new int[2] { 15, 15 };
            else
                this.speed = speed;
        }   
    }
}
