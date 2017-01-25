namespace IPCAUI.Administration.PopupScreens
{
    partial class CostcenterPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dvgCostCenter = new DevExpress.XtraGrid.GridControl();
            this.dvgCostCenterDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostcenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCCId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.colDC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNarration = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCostCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCostCenterDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.dvgCostCenter);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(699, 327, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(469, 339);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dvgCostCenter
            // 
            this.dvgCostCenter.Location = new System.Drawing.Point(12, 28);
            this.dvgCostCenter.MainView = this.dvgCostCenterDetails;
            this.dvgCostCenter.Name = "dvgCostCenter";
            this.dvgCostCenter.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemLookUpEdit1});
            this.dvgCostCenter.Size = new System.Drawing.Size(445, 243);
            this.dvgCostCenter.TabIndex = 11;
            this.dvgCostCenter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dvgCostCenterDetails});
            // 
            // dvgCostCenterDetails
            // 
            this.dvgCostCenterDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dvgCostCenterDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSNo,
            this.colCostcenter,
            this.colCCId,
            this.colParentId,
            this.colBalance,
            this.colDC,
            this.colNarration});
            this.dvgCostCenterDetails.GridControl = this.dvgCostCenter;
            this.dvgCostCenterDetails.Name = "dvgCostCenterDetails";
            this.dvgCostCenterDetails.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.dvgCostCenterDetails.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.dvgCostCenterDetails.OptionsEditForm.BindingMode = DevExpress.XtraGrid.Views.Grid.EditFormBindingMode.Direct;
            this.dvgCostCenterDetails.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True;
            this.dvgCostCenterDetails.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True;
            this.dvgCostCenterDetails.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.True;
            this.dvgCostCenterDetails.OptionsMenu.DialogFormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.dvgCostCenterDetails.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.dvgCostCenterDetails.OptionsNavigation.AutoFocusNewRow = true;
            this.dvgCostCenterDetails.OptionsNavigation.EnterMoveNextColumn = true;
            this.dvgCostCenterDetails.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.dvgCostCenterDetails.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.dvgCostCenterDetails.OptionsView.ShowFooter = true;
            this.dvgCostCenterDetails.OptionsView.ShowGroupPanel = false;
            this.dvgCostCenterDetails.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dvgCostCenterDetails_CustomColumnDisplayText);
            // 
            // colSNo
            // 
            this.colSNo.Caption = "SNo";
            this.colSNo.Name = "colSNo";
            this.colSNo.OptionsColumn.ReadOnly = true;
            this.colSNo.Visible = true;
            this.colSNo.VisibleIndex = 0;
            this.colSNo.Width = 43;
            // 
            // colCostcenter
            // 
            this.colCostcenter.Caption = "Cost Center ";
            this.colCostcenter.FieldName = "Costcenter";
            this.colCostcenter.Name = "colCostcenter";
            this.colCostcenter.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "SUM={0:0.##}")});
            this.colCostcenter.Visible = true;
            this.colCostcenter.VisibleIndex = 1;
            this.colCostcenter.Width = 62;
            // 
            // colCCId
            // 
            this.colCCId.Caption = "CCId";
            this.colCCId.FieldName = "CCId";
            this.colCCId.Name = "colCCId";
            // 
            // colParentId
            // 
            this.colParentId.Caption = "ParentId";
            this.colParentId.FieldName = "ParentId";
            this.colParentId.Name = "colParentId";
            // 
            // colBalance
            // 
            this.colBalance.Caption = "Balance";
            this.colBalance.FieldName = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 2;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(469, 339);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dvgCostCenter;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(449, 263);
            this.layoutControlItem1.Text = "Cost Center";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(58, 13);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(204, 275);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 22);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnOk;
            this.layoutControlItem2.Location = new System.Drawing.Point(192, 263);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 277);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(192, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(272, 277);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(177, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Location = new System.Drawing.Point(12, 301);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(445, 26);
            this.panelControl1.TabIndex = 13;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.panelControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 289);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(449, 30);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(249, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "F2=>Done";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(132, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Esc=>Quit";
            // 
            // colDC
            // 
            this.colDC.Caption = "DC";
            this.colDC.FieldName = "DC";
            this.colDC.Name = "colDC";
            this.colDC.Visible = true;
            this.colDC.VisibleIndex = 3;
            // 
            // colNarration
            // 
            this.colNarration.Caption = "Short Narration";
            this.colNarration.FieldName = "Shortnarration";
            this.colNarration.Name = "colNarration";
            this.colNarration.Visible = true;
            this.colNarration.VisibleIndex = 4;
            // 
            // CostcenterPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 339);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CostcenterPopup";
            this.Text = "CostcenterPopup";
            this.Load += new System.EventHandler(this.CostcenterPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCostCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCostCenterDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl dvgCostCenter;
        private DevExpress.XtraGrid.Views.Grid.GridView dvgCostCenterDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colSNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCostcenter;
        private DevExpress.XtraGrid.Columns.GridColumn colCCId;
        private DevExpress.XtraGrid.Columns.GridColumn colParentId;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colDC;
        private DevExpress.XtraGrid.Columns.GridColumn colNarration;
    }
}