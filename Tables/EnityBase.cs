﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace CocktailsConsole.Tables
{
    class EnityBase : DbContext
    {
        public int id { get; set; }           
        
    }
}
