﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class DSAccountPosting
    {
        //This Model Is Used to DiscountStructurMaster & MarkupStructureMaster
        public int DS_Id { get; set; }
        public int MS_Id { get; set; }
        public int AccPost_Id { get; set; }
        public bool AccountPost { get; set; }
        public string AccountHeadPost { get; set; }
        public bool AffectsGoods { get; set; }
        public string CreatedBy { get; set; }
    }
}
