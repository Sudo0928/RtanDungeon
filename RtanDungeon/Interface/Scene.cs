﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanDungeon.Interface
{
    public interface IScene
    {
        void Start();
        void Update();
        string GetTitleName();
    }
}
