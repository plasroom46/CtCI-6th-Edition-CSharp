﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_06_Animal_Shelter
{
    public class Dog : Animal
    {
        public Dog(string n) : base(n)
        {

        }

        public override string GetName()
        {
            return "Dog: " + name;
        }
    }
}