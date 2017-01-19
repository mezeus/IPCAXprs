namespace QLicense.Windows.Controls
{
    partial class LicenseActivateControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseActivateControl));
            this.grpbxLicense = new System.Windows.Forms.GroupBox();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.grpbxUID = new System.Windows.Forms.GroupBox();
            this.lblUIDTip = new System.Windows.Forms.Label();
            this.lnkCopy = new System.Windows.Forms.LinkLabel();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnLicenseTypes = new DevExpress.XtraEditors.RadioGroup();
            this.grpbxLicense.SuspendLayout();
            this.grpbxUID.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnLicenseTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbxLicense
            // 
            resources.ApplyResources(this.grpbxLicense, "grpbxLicense");
            this.grpbxLicense.Controls.Add(this.txtLicense);
            this.grpbxLicense.Name = "grpbxLicense";
            this.grpbxLicense.TabStop = false;
            // 
            // txtLicense
            // 
            resources.ApplyResources(this.txtLicense, "txtLicense");
            this.txtLicense.Name = "txtLicense";
            // 
            // grpbxUID
            // 
            resources.ApplyResources(this.grpbxUID, "grpbxUID");
            this.grpbxUID.Controls.Add(this.lblUIDTip);
            this.grpbxUID.Controls.Add(this.lnkCopy);
            this.grpbxUID.Controls.Add(this.txtUID);
            this.grpbxUID.Name = "grpbxUID";
            this.grpbxUID.TabStop = false;
            // 
            // lblUIDTip
            // 
            resources.ApplyResources(this.lblUIDTip, "lblUIDTip");
            this.lblUIDTip.Name = "lblUIDTip";
            // 
            // lnkCopy
            // 
            resources.ApplyResources(this.lnkCopy, "lnkCopy");
            this.lnkCopy.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCopy.Name = "lnkCopy";
            this.lnkCopy.TabStop = true;
            this.lnkCopy.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCopy_LinkClicked);
            // 
            // txtUID
            // 
            resources.ApplyResources(this.txtUID, "txtUID");
            this.txtUID.Name = "txtUID";
            this.txtUID.ReadOnly = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.rbtnLicenseTypes);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rbtnLicenseTypes
            // 
            resources.ApplyResources(this.rbtnLicenseTypes, "rbtnLicenseTypes");
            this.rbtnLicenseTypes.Name = "rbtnLicenseTypes";
            this.rbtnLicenseTypes.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rbtnLicenseTypes.Properties.Items"), resources.GetString("rbtnLicenseTypes.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("rbtnLicenseTypes.Properties.Items2"))), resources.GetString("rbtnLicenseTypes.Properties.Items3")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("rbtnLicenseTypes.Properties.Items4"))), resources.GetString("rbtnLicenseTypes.Properties.Items5")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("rbtnLicenseTypes.Properties.Items6"))), resources.GetString("rbtnLicenseTypes.Properties.Items7"), ((bool)(resources.GetObject("rbtnLicenseTypes.Properties.Items8"))))});
            this.rbtnLicenseTypes.SelectedIndexChanged += new System.EventHandler(this.rbtnLicenseTypes_SelectedIndexChanged);
            // 
            // LicenseActivateControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbxLicense);
            this.Controls.Add(this.grpbxUID);
            this.Name = "LicenseActivateControl";
            this.grpbxLicense.ResumeLayout(false);
            this.grpbxLicense.PerformLayout();
            this.grpbxUID.ResumeLayout(false);
            this.grpbxUID.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbtnLicenseTypes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxLicense;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.GroupBox grpbxUID;
        private System.Windows.Forms.Label lblUIDTip;
        private System.Windows.Forms.LinkLabel lnkCopy;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.RadioGroup rbtnLicenseTypes;
    }
}
