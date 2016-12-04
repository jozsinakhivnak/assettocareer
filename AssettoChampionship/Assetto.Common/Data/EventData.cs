﻿using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Data
{
    public class EventData
    {
        public string FriendlyName { get; set; }

        public TrackData Track { get; set; }

        public LayoutData Layout { get; set; }

        public PlayerData Player { get; set; }

        public List<OpponentData> Opponents { get; set; }

        public List<SessionData> Sessions { get; set; }

        public JumpStartPenaltyType JumpStartPenalty { get; set; }


    }
}
