namespace IPCAUI
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.windowsUIView1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(this.components);
            this.tileContainer1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer(this.components);
            this.pageGroup1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup(this.components);
            this.page1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page(this.components);
            this.page2 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.document1Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.document2Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            this.document3 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.document3Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            this.document4 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.document4Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            this.document5 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.document5Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.page1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.page2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5Tile)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.windowsUIView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.windowsUIView1});
            // 
            // windowsUIView1
            // 
            this.windowsUIView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.tileContainer1,
            this.pageGroup1,
            this.page1,
            this.page2});
            this.windowsUIView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1,
            this.document2,
            this.document3,
            this.document4,
            this.document5});
            this.windowsUIView1.Tiles.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] {
            this.document1Tile,
            this.document2Tile,
            this.document3Tile,
            this.document4Tile,
            this.document5Tile});
            // 
            // tileContainer1
            // 
            this.tileContainer1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] {
            this.document1Tile,
            this.document2Tile,
            this.document3Tile,
            this.document4Tile,
            this.document5Tile});
            this.tileContainer1.Name = "tileContainer1";
            // 
            // pageGroup1
            // 
            this.pageGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document[] {
            this.document1,
            this.document2,
            this.document3,
            this.document4,
            this.document5});
            this.pageGroup1.Name = "pageGroup1";
            // 
            // page1
            // 
            this.page1.Document = this.document4;
            this.page1.Name = "page1";
            // 
            // page2
            // 
            this.page2.Document = this.document5;
            this.page2.Name = "page2";
            // 
            // document1
            // 
            this.document1.Caption = "document1";
            this.document1.ControlName = "document1";
            // 
            // document1Tile
            // 
            this.document1Tile.Document = this.document1;
            this.document1Tile.Name = "document1Tile";
            // 
            // document2
            // 
            this.document2.Caption = "document2";
            this.document2.ControlName = "document2";
            // 
            // document2Tile
            // 
            this.document2Tile.Document = this.document2;
            this.tileContainer1.SetID(this.document2Tile, 1);
            this.document2Tile.Name = "document2Tile";
            // 
            // document3
            // 
            this.document3.Caption = "document3";
            this.document3.ControlName = "document3";
            // 
            // document3Tile
            // 
            this.document3Tile.Document = this.document3;
            this.tileContainer1.SetID(this.document3Tile, 2);
            this.document3Tile.Name = "document3Tile";
            // 
            // document4
            // 
            this.document4.Caption = "document4";
            this.document4.ControlName = "document4";
            // 
            // document4Tile
            // 
            this.document4Tile.Document = this.document4;
            this.tileContainer1.SetID(this.document4Tile, 3);
            this.document4Tile.Name = "document4Tile";
            // 
            // document5
            // 
            this.document5.Caption = "document5";
            this.document5.ControlName = "document5";
            // 
            // document5Tile
            // 
            this.document5Tile.Document = this.document5;
            this.tileContainer1.SetID(this.document5Tile, 4);
            this.document5Tile.Name = "document5Tile";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 429);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.page1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.page2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5Tile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer tileContainer1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile document1Tile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile document2Tile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document2;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile document3Tile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document3;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile document4Tile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document4;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile document5Tile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document5;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup pageGroup1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page page1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page page2;
    }
}