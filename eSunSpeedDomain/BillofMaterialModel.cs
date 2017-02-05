using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class BillofMaterialModel:BillsofMaterialDetailsModel
    {
        public int Bom_Id { get; set; }
        public string BOMName { get; set; }
        //This is ComboBox
        public string Itemtoproduce { get; set; }
        public decimal Quantity { get; set; }
        public decimal ICTotalQty { get; set; }
        public decimal IGTotalQty { get; set; }
        //This is ComboboxofUnitMasterList
        public string ItemUnit { get; set; }
        //This Expenses Used PerUnit
        public decimal Expenses { get; set; }
        public bool SpecifyMCGenerated { get; set; }//if this Enable RightSideMcComboBoxWillShow
        public string SourceMC { get; set; }
        public bool SpecifyDefaultMCforItemConsumed { get; set; }// if this Enable RightSideMcComboBoxWillShow
        public string AppMc { get; set; }
        
        public List<BillsofMaterialDetailsModel> MaterialConsumed { get; set; }
        public List<BillsofMaterialDetailsModel> MaterialGenerated { get; set; }
        //// Raw Material Consumed Grid
        //public int SNo { get; set; }
        //public string ItemName { get; set; }
        //public decimal Qty { get; set; }
        //public decimal Unit { get; set; }
        //public decimal TotalofConsumedqtyUnit { get; set; }
        // Raw Product Generated Grid= Raw Material Consumed Grid Same
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
