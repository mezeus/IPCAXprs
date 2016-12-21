namespace IPCAUI.Transactions
{
    partial class Accountgroup
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
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbxGroupname = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbxAlias = new DevExpress.XtraEditors.TextEdit();
            this.cbxPrimary = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbxPrimarygroup = new DevExpress.XtraLayout.LayoutControlItem();
            this.cbxUndergroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxGroupname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPrimary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPrimarygroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxUndergroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cbxPrimary);
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Controls.Add(this.tbxAlias);
            this.layoutControl1.Controls.Add(this.tbxGroupname);
            this.layoutControl1.Controls.Add(this.cbxUndergroup);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(277, 0, 537, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1006, 593);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(109, 533);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(882, 20);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.gridControl2;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 521);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(983, 24);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.cbxPrimarygroup,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1006, 593);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tbxGroupname;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(986, 24);
            this.layoutControlItem2.Text = "Group";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
            // 
            // tbxGroupname
            // 
            this.tbxGroupname.Location = new System.Drawing.Point(83, 12);
            this.tbxGroupname.Name = "tbxGroupname";
            this.tbxGroupname.Size = new System.Drawing.Size(911, 20);
            this.tbxGroupname.StyleController = this.layoutControl1;
            this.tbxGroupname.TabIndex = 0;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.tbxAlias;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(986, 24);
            this.layoutControlItem3.Text = "Alias";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 13);
            // 
            // tbxAlias
            // 
            this.tbxAlias.Location = new System.Drawing.Point(83, 36);
            this.tbxAlias.Name = "tbxAlias";
            this.tbxAlias.Size = new System.Drawing.Size(911, 20);
            this.tbxAlias.StyleController = this.layoutControl1;
            this.tbxAlias.TabIndex = 5;
            // 
            // cbxPrimary
            // 
            this.cbxPrimary.Location = new System.Drawing.Point(83, 60);
            this.cbxPrimary.Name = "cbxPrimary";
            this.cbxPrimary.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxPrimary.Size = new System.Drawing.Size(911, 20);
            this.cbxPrimary.StyleController = this.layoutControl1;
            this.cbxPrimary.TabIndex = 9;
            // 
            // cbxPrimarygroup
            // 
            this.cbxPrimarygroup.Control = this.cbxPrimary;
            this.cbxPrimarygroup.Location = new System.Drawing.Point(0, 48);
            this.cbxPrimarygroup.Name = "cbxPrimarygroup";
            this.cbxPrimarygroup.Size = new System.Drawing.Size(986, 24);
            this.cbxPrimarygroup.Text = "Primary Group";
            this.cbxPrimarygroup.TextSize = new System.Drawing.Size(68, 13);
            // 
            // cbxUndergroup
            // 
            this.cbxUndergroup.Location = new System.Drawing.Point(83, 84);
            this.cbxUndergroup.Name = "cbxUndergroup";
            this.cbxUndergroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxUndergroup.Size = new System.Drawing.Size(911, 20);
            this.cbxUndergroup.StyleController = this.layoutControl1;
            this.cbxUndergroup.TabIndex = 9;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cbxUndergroup;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(986, 501);
            this.layoutControlItem4.Text = "Under Group";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
            // 
            // Accountgroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 593);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Accountgroup";
            this.Text = "SalesVoucher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxGroupname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPrimary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPrimarygroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxUndergroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.TextEdit tbxAlias;
        private DevExpress.XtraEditors.TextEdit tbxGroupname;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ComboBoxEdit cbxPrimary;
        private DevExpress.XtraLayout.LayoutControlItem cbxPrimarygroup;
        private DevExpress.XtraEditors.ComboBoxEdit cbxUndergroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}