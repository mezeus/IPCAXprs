using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class VatJournalModel
    {
        public string Month { get; set; }
        public List<VatJournalInputTaxModel> VatJournalInputTaxModel { get; set; }
        public List<VatJournalOutputTaxModel> VatJournalOutputTaxModel { get; set; }
    }
}
