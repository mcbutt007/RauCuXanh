﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RauCuXanh.Models
{
    public class Notification
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string Noti_type { get; set; }
        public int Raucu_id { get; set; }
        public string Timestamp { get; set; }
        public int User_id { get; set; }
    }
}
