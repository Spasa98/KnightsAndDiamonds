﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Game
    {
        public int ID { get; set; }
        [JsonIgnore]
        public List<Player>? Players { get; set; }
    }
}