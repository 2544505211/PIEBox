namespace PIEBox
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.workSpaceTree = new DevExpress.XtraTreeList.TreeList();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.workSpaceTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // workSpaceTree
            // 
            this.workSpaceTree.Cursor = System.Windows.Forms.Cursors.Default;
            this.workSpaceTree.Location = new System.Drawing.Point(311, 50);
            this.workSpaceTree.Name = "workSpaceTree";
            this.workSpaceTree.BeginUnboundLoad();
            this.workSpaceTree.AppendNode(new object[0], -1);
            this.workSpaceTree.AppendNode(new object[0], 0);
            this.workSpaceTree.AppendNode(new object[0], 0);
            this.workSpaceTree.AppendNode(new object[0], 0);
            this.workSpaceTree.AppendNode(new object[0], 0);
            this.workSpaceTree.AppendNode(new object[0], 0);
            this.workSpaceTree.AppendNode(new object[0], -1);
            this.workSpaceTree.AppendNode(new object[0], 6);
            this.workSpaceTree.AppendNode(new object[0], 6);
            this.workSpaceTree.AppendNode(new object[0], -1);
            this.workSpaceTree.AppendNode(new object[0], -1);
            this.workSpaceTree.AppendNode(new object[0], -1);
            this.workSpaceTree.EndUnboundLoad();
            this.workSpaceTree.Size = new System.Drawing.Size(308, 423);
            this.workSpaceTree.TabIndex = 1;
            this.workSpaceTree.NodeChanged += new DevExpress.XtraTreeList.NodeChangedEventHandler(this.workSpaceTree_NodeChanged);
            this.workSpaceTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.workSpaceTree_MouseClick);
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(311, 20);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(308, 24);
            this.searchControl1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 475);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.workSpaceTree);
            this.Name = "Form1";
            this.Text = "目录树";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.workSpaceTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList workSpaceTree;
        private DevExpress.XtraEditors.SearchControl searchControl1;

    }
}

