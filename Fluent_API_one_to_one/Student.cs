﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fluent_API_one_to_one
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudentAddress Address { get; set; }
    }
}
