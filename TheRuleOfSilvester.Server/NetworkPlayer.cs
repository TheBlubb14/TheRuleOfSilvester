﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheRuleOfSilvester.Core;
using TheRuleOfSilvester.Network;

namespace TheRuleOfSilvester.Server
{
    public class NetworkPlayer
    {
        public Player Player { get; set; }
        public ConnectedClient Client { get; internal set; }
        public RoundMode RoundMode
        {
            get => roundMode;
            internal set
            {
                roundMode = (RoundMode)((int)value % maxRoundMode);
                OnRoundModeChange?.Invoke(this, roundMode);
            }
        }
        public ServerStatus CurrentServerStatus
        {
            get
            {
                var tmp = currentServerStatus;
                if (tmp == ServerStatus.Started)
                    currentServerStatus = ServerStatus.Ok;
                return tmp;
            }
            set => currentServerStatus = value;
        }
        private ServerStatus currentServerStatus;

        public List<PlayerAction> UpdateSets { get; internal set; }

        public event EventHandler<RoundMode> OnRoundModeChange;

        private RoundMode roundMode;

        private readonly int maxRoundMode;

        public NetworkPlayer(Player player)
        {
            Player = player;
            maxRoundMode = Enum.GetValues(typeof(RoundMode)).Cast<int>().Max() + 1;
            UpdateSets = new List<PlayerAction>();
            CurrentServerStatus = ServerStatus.Waiting;
        }

    }
}
