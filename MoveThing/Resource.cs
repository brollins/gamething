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

        private string mapId;
        private string name;
        private string description;
        private bool canUse;
        private bool canPickup;
        private string toggleMapId;
        private bool isVisible;

        public Resource()
        {
            movementRestrictions = new Collection<string>();
            MovementEnablers = new Collection<string>();
            mapId = string.Empty;
            name = string.Empty;
            description = string.Empty;
            toggleMapId = string.Empty;
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
    }
}
