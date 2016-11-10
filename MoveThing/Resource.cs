using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveThing
{
    public class Resource
    {
        private Collection<string> movementRestrictions;
        private Collection<string> movementEnablers;
        private Collection<string> damageRestrictions;
        private Collection<string> damageEnablers;

        private string mapId;
        private string name;
        private string description;
        private bool canUse;
        private bool canPickup;
        private string toggleMapId;
        private bool isVisible;
        private bool canMove;
        private bool isFog;
        private bool canBeDestroyed;
        private int speed;
        private string speedDice;
        private int readiness;
        private int health;
        private string healthDice;

        public Resource()
        {
            movementRestrictions = new Collection<string>();
            MovementEnablers = new Collection<string>();
            DamageRestrictions = new Collection<string>();
            DamageEnablers = new Collection<string>();
            mapId = string.Empty;
            name = string.Empty;
            description = string.Empty;
            toggleMapId = string.Empty;
            healthDice = "0";
            speedDice = "0";
            isVisible = true;
        }
        
        public Collection<string> MovementRestrictions
        {
            get
            {
                return movementRestrictions;
            }

            set
            {
                movementRestrictions = value;
            }
        }

        public Collection<string> MovementEnablers
        {
            get
            {
                return movementEnablers;
            }

            set
            {
                movementEnablers = value;
            }
        }

        public string MapId
        {
            get
            {
                return mapId;
            }

            set
            {
                mapId = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public bool CanUse
        {
            get
            {
                return canUse;
            }

            set
            {
                canUse = value;
            }
        }

        public bool CanPickup
        {
            get
            {
                return canPickup;
            }

            set
            {
                canPickup = value;
            }
        }

        public string ToggleMapId
        {
            get
            {
                return toggleMapId;
            }

            set
            {
                toggleMapId = value;
            }
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }

            set
            {
                isVisible = value;
            }
        }

        public bool IsFog
        {
            get
            {
                return isFog;
            }

            set
            {
                isFog = value;
            }
        }

        public bool CanMove
        {
            get
            {
                return canMove;
            }

            set
            {
                canMove = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public int Readiness
        {
            get
            {
                return readiness;
            }

            set
            {
                readiness = value;
            }
        }

        public string SpeedDice
        {
            get
            {
                return speedDice;
            }

            set
            {
                speedDice = value;
            }
        }

        public string HealthDice
        {
            get
            {
                return healthDice;
            }

            set
            {
                healthDice = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public bool CanBeDestroyed
        {
            get
            {
                return canBeDestroyed;
            }

            set
            {
                canBeDestroyed = value;
            }
        }

        public Collection<string> DamageEnablers
        {
            get
            {
                return damageEnablers;
            }

            set
            {
                damageEnablers = value;
            }
        }

        public Collection<string> DamageRestrictions
        {
            get
            {
                return damageRestrictions;
            }

            set
            {
                damageRestrictions = value;
            }
        }
    }
}
