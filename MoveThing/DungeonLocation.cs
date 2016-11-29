using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveThing
{
    public class DungeonLocation
    {
        private int row;
        private int column;

        public DungeonLocation(): this(0, 0) { }

        public DungeonLocation(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public int Column
        {
            get
            {
                return column;
            }

            set
            {
                column = value;
            }
        }

        public int Row
        {
            get
            {
                return row;
            }

            set
            {
                row = value;
            }
        }
    }
}
