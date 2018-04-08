﻿using System;
using System.Collections.Generic;
using System.Text;
using TheRuleOfSilvester.Network;

namespace TheRuleOfSilvester.Core
{
    public interface IMultiplayerComponent
    {
        Client Client { get; }
        int Port { get; }
        string Host { get; }

        void Connect();

        void Disconnect();

        void Update(Game game);
        Map GetMap();
    }
}