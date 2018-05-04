namespace OPCClient
{
    partial class Form1
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
            this.btnBrowserOPCServer = new System.Windows.Forms.Button();
            this.lstOPCServer = new System.Windows.Forms.TreeView();
            this.txtNodeAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExceptionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnBrowseOPCItems = new System.Windows.Forms.Button();
            this.treeOPC = new System.Windows.Forms.TreeView();
            this.lstOPCItems = new System.Windows.Forms.ListView();
            this.dataOPC = new System.Windows.Forms.DataGridView();
            this.ColumnItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddToMonitoring = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOPC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowserOPCServer
            // 
            this.btnBrowserOPCServer.Location = new System.Drawing.Point(30, 41);
            this.btnBrowserOPCServer.Name = "btnBrowserOPCServer";
            this.btnBrowserOPCServer.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserOPCServer.TabIndex = 0;
            this.btnBrowserOPCServer.Text = "BrowserOPCServer";
            this.btnBrowserOPCServer.UseVisualStyleBackColor = true;
            this.btnBrowserOPCServer.Click += new System.EventHandler(this.btnBrowserOPCServer_Click);
            // 
            // lstOPCServer
            // 
            this.lstOPCServer.Location = new System.Drawing.Point(30, 80);
            this.lstOPCServer.Name = "lstOPCServer";
            this.lstOPCServer.Size = new System.Drawing.Size(284, 141);
            this.lstOPCServer.TabIndex = 1;
            // 
            // txtNodeAddress
            // 
            this.txtNodeAddress.Location = new System.Drawing.Point(128, 43);
            this.txtNodeAddress.Name = "txtNodeAddress";
            this.txtNodeAddress.Size = new System.Drawing.Size(186, 20);
            this.txtNodeAddress.TabIndex = 2;
            this.txtNodeAddress.Text = "localhost";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(30, 227);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StatusConnection,
            this.toolStripStatusLabel2,
            this.ExceptionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 605);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(943, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Gray;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel1.Text = "Connection : ";
            // 
            // StatusConnection
            // 
            this.StatusConnection.ForeColor = System.Drawing.Color.Blue;
            this.StatusConnection.Name = "StatusConnection";
            this.StatusConnection.Size = new System.Drawing.Size(84, 17);
            this.StatusConnection.Text = "not connected";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Gray;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel2.Text = "Exception : ";
            // 
            // ExceptionStatus
            // 
            this.ExceptionStatus.Name = "ExceptionStatus";
            this.ExceptionStatus.Size = new System.Drawing.Size(15, 17);
            this.ExceptionStatus.Text = " -";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(128, 227);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnBrowseOPCItems
            // 
            this.btnBrowseOPCItems.Location = new System.Drawing.Point(226, 227);
            this.btnBrowseOPCItems.Name = "btnBrowseOPCItems";
            this.btnBrowseOPCItems.Size = new System.Drawing.Size(88, 23);
            this.btnBrowseOPCItems.TabIndex = 6;
            this.btnBrowseOPCItems.Text = "Browse Items";
            this.btnBrowseOPCItems.UseVisualStyleBackColor = true;
            this.btnBrowseOPCItems.Click += new System.EventHandler(this.btnBrowseOPCItems_Click);
            // 
            // treeOPC
            // 
            this.treeOPC.Location = new System.Drawing.Point(30, 265);
            this.treeOPC.Name = "treeOPC";
            this.treeOPC.Size = new System.Drawing.Size(137, 304);
            this.treeOPC.TabIndex = 7;
            this.treeOPC.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeOPC_NodeMouseClick);
            // 
            // lstOPCItems
            // 
            this.lstOPCItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstOPCItems.Location = new System.Drawing.Point(190, 265);
            this.lstOPCItems.Name = "lstOPCItems";
            this.lstOPCItems.ShowItemToolTips = true;
            this.lstOPCItems.Size = new System.Drawing.Size(124, 304);
            this.lstOPCItems.TabIndex = 16;
            this.lstOPCItems.UseCompatibleStateImageBehavior = false;
            // 
            // dataOPC
            // 
            this.dataOPC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOPC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItem,
            this.ColumnValue});
            this.dataOPC.Enabled = false;
            this.dataOPC.Location = new System.Drawing.Point(402, 80);
            this.dataOPC.Name = "dataOPC";
            this.dataOPC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataOPC.Size = new System.Drawing.Size(343, 344);
            this.dataOPC.TabIndex = 17;
            // 
            // ColumnItem
            // 
            this.ColumnItem.HeaderText = "Item";
            this.ColumnItem.Name = "ColumnItem";
            this.ColumnItem.Width = 200;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            // 
            // btnAddToMonitoring
            // 
            this.btnAddToMonitoring.Location = new System.Drawing.Point(190, 576);
            this.btnAddToMonitoring.Name = "btnAddToMonitoring";
            this.btnAddToMonitoring.Size = new System.Drawing.Size(124, 23);
            this.btnAddToMonitoring.TabIndex = 18;
            this.btnAddToMonitoring.Text = "Add to Monitoring";
            this.btnAddToMonitoring.UseVisualStyleBackColor = true;
            this.btnAddToMonitoring.Click += new System.EventHandler(this.btnAddToMonitoring_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(402, 443);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 19;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 627);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnAddToMonitoring);
            this.Controls.Add(this.dataOPC);
            this.Controls.Add(this.lstOPCItems);
            this.Controls.Add(this.treeOPC);
            this.Controls.Add(this.btnBrowseOPCItems);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtNodeAddress);
            this.Controls.Add(this.lstOPCServer);
            this.Controls.Add(this.btnBrowserOPCServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOPC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowserOPCServer;
        private System.Windows.Forms.TreeView lstOPCServer;
        private System.Windows.Forms.TextBox txtNodeAddress;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusConnection;
        internal System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel ExceptionStatus;
        private System.Windows.Forms.Button btnBrowseOPCItems;
        internal System.Windows.Forms.TreeView treeOPC;
        internal System.Windows.Forms.ListView lstOPCItems;
        internal System.Windows.Forms.DataGridView dataOPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        internal System.Windows.Forms.Button btnAddToMonitoring;
        private System.Windows.Forms.Button btnRead;
    }
}

