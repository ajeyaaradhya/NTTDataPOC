﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Model
{
    public class Claim
    {
        public int MemberID { get; set; }
        public DateTime ClaimDate { get; set; }
        public float ClaimAmount { get; set; }
    }
}
