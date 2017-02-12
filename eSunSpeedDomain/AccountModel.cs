﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class AccountModel
    {
        public int AC_Id { get; set; }
        public long ParentId { get; set; }
        public string DC { get; set; }
        public string Account { get; set; }
        public long LedgerId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Amount { get; set; }
        public string Narration { get; set; }

    }
}
