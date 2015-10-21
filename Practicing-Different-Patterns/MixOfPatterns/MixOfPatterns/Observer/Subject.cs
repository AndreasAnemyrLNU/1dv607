﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Observer
{
    interface Subject
    {

        void RegisterObserver(Observer observer);

        void RemoverObserver(Observer observer);

        void NotifyObservers();

    }
}
