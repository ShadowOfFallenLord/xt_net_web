﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_6.Interfaces
{
    public interface IUser
    {
        int ID { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        int Age { get; }
        IAwardsPool Awards { get; }
        IImageKeeper Image { get;  }
    }
}
