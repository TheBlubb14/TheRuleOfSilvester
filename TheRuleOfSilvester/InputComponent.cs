﻿using System;
using System.Collections.Generic;
using System.Text;
using TheRuleOfSilvester.Core;

namespace TheRuleOfSilvester
{
    public class InputComponent : IInputCompoment
    {
        public bool Up => LastKey == (int)ConsoleKey.W || LastKey == (int)ConsoleKey.UpArrow;
        public bool Down => LastKey == (int)ConsoleKey.S || LastKey == (int)ConsoleKey.DownArrow;
        public bool Left => LastKey == (int)ConsoleKey.A || LastKey == (int)ConsoleKey.LeftArrow;
        public bool Right => LastKey == (int)ConsoleKey.D || LastKey == (int)ConsoleKey.RightArrow;
        public bool StartAction => LastKey == (int)ConsoleKey.Q || LastKey == (int)ConsoleKey.NumPad0;
        public bool RoundButton => LastKey == (int)ConsoleKey.R;
        public bool RoundActionButton => LastKey == (int)ConsoleKey.D1;

        public bool Active { get; set; }

        public int LastKey { get; set; }

        public InputComponent()
        {
            LastKey = -1;
            Active = true;
        }

        internal void Listen()
        {
            var running = true;

            while (running)
            {
                LastKey = Active ? (int)Console.ReadKey(true).Key : -1;
                running = LastKey != (int)ConsoleKey.Escape;
            }
        }

    }
}
