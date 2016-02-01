﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartan.Domain
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClassType ClassType { get; set; }
        public Workout Workout { get; set; }
    }
}
