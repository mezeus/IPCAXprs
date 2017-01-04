namespace IPCAUI.Reports.Accountbooks.Grids
{
    partial class BalanceSheetGrd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblasset = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtLiability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtxtAsset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupId1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblliability = new System.Windows.Forms.Label();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panel1);
            this.layoutControl1.Controls.Add(this.navBarControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(924, 635);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvReport);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(131, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 611);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.lblasset);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(391, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 32);
            this.panel2.TabIndex = 1227;
            // 
            // lblasset
            // 
            this.lblasset.AutoSize = true;
            this.lblasset.BackColor = System.Drawing.Color.Transparent;
            this.lblasset.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblasset.ForeColor = System.Drawing.Color.White;
            this.lblasset.Location = new System.Drawing.Point(132, 5);
            this.lblasset.Name = "lblasset";
            this.lblasset.Size = new System.Drawing.Size(62, 22);
            this.lblasset.TabIndex = 1184;
            this.lblasset.Text = "Asset";
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AllowUserToResizeColumns = false;
            this.dgvReport.AllowUserToResizeRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.ColumnHeadersVisible = false;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID2,
            this.GroupId2,
            this.dgvtxtLiability,
            this.Amount2,
            this.dgvtxtAsset,
            this.Amount1,
            this.ID1,
            this.GroupId1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReport.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.GridColor = System.Drawing.Color.LightGray;
            this.dgvReport.Location = new System.Drawing.Point(10, 47);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvReport.Size = new System.Drawing.Size(761, 497);
            this.dgvReport.TabIndex = 1224;
            // 
            // ID2
            // 
            this.ID2.HeaderText = "ID2";
            this.ID2.Name = "ID2";
            this.ID2.ReadOnly = true;
            this.ID2.Visible = false;
            // 
            // GroupId2
            // 
            this.GroupId2.HeaderText = "GroupId2";
            this.GroupId2.Name = "GroupId2";
            this.GroupId2.ReadOnly = true;
            this.GroupId2.Visible = false;
            // 
            // dgvtxtLiability
            // 
            this.dgvtxtLiability.HeaderText = "Liability";
            this.dgvtxtLiability.Name = "dgvtxtLiability";
            this.dgvtxtLiability.ReadOnly = true;
            // 
            // Amount2
            // 
            this.Amount2.HeaderText = "Amount2";
            this.Amount2.Name = "Amount2";
            this.Amount2.ReadOnly = true;
            this.Amount2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvtxtAsset
            // 
            this.dgvtxtAsset.HeaderText = "Asset";
            this.dgvtxtAsset.Name = "dgvtxtAsset";
            this.dgvtxtAsset.ReadOnly = true;
            // 
            // Amount1
            // 
            this.Amount1.HeaderText = "Amount1";
            this.Amount1.Name = "Amount1";
            this.Amount1.ReadOnly = true;
            this.Amount1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ID1
            // 
            this.ID1.HeaderText = "ID1";
            this.ID1.Name = "ID1";
            this.ID1.ReadOnly = true;
            this.ID1.Visible = false;
            // 
            // GroupId1
            // 
            this.GroupId1.HeaderText = "GroupId1";
            this.GroupId1.Name = "GroupId1";
            this.GroupId1.ReadOnly = true;
            this.GroupId1.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(9, 552);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 27);
            this.btnPrint.TabIndex = 1223;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.ForeColor = System.Drawing.Color.Honeydew;
            this.panel3.Location = new System.Drawing.Point(391, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 480);
            this.panel3.TabIndex = 1228;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.lblliability);
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(10, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(385, 32);
            this.panel4.TabIndex = 1226;
            // 
            // lblliability
            // 
            this.lblliability.AutoSize = true;
            this.lblliability.BackColor = System.Drawing.Color.Transparent;
            this.lblliability.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblliability.ForeColor = System.Drawing.Color.White;
            this.lblliability.Location = new System.Drawing.Point(124, 5);
            this.lblliability.Name = "lblliability";
            this.lblliability.Size = new System.Drawing.Size(82, 22);
            this.lblliability.TabIndex = 1183;
            this.lblliability.Text = "Liability";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Location = new System.Drawing.Point(12, 12);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 115;
            this.navBarControl1.Size = new System.Drawing.Size(115, 611);
            this.navBarControl1.TabIndex = 4;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "navBarGroup1";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(924, 635);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.navBarControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(119, 615);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.panel1;
            this.layoutControlItem2.Location = new System.Drawing.Point(119, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(785, 615);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 547);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(201, 25);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 20);
            // 
            // BalanceSheetGrd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 635);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BalanceSheetGrd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BalanceSheetGrd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BalanceSheetGrd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblasset;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtLiability;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtAsset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupId1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblliability;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}