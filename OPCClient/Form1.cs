
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCClient
{
    public struct strOPCServer
    {
        public OPCServer MyServer;
        public OPCGroup MyGroup;
        public OPCItem MyItem;
        public Array ServerHandles;
        public Array Errors;
        public Array Values;
        public int MonCount;
    }
    public struct strcMonItem
    {
        public int _Server;
        public string _Name;
        public object _Value;
        public int _Index;
        public object _ServerHandles;
    }

    public partial class Form1 : Form
    {
        OPCServer MyOPCServers = new OPCServer();
        strOPCServer[] MyOPCServer = new strOPCServer[11];
        OPCGroup[] MyOPCGroup = new OPCGroup[11];



        string treePath;
        OPCBrowser MyOPCBrowser;

        strcMonItem[] MonItem;
        int MonItem_Count = 0;
        int iOPC;

        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void btnBrowserOPCServer_Click(object sender, EventArgs e)
        {
            object ListServers = MyOPCServers.GetOPCServers(txtNodeAddress.Text);
            lstOPCServer.Nodes.Clear();
            var servers = ((Array)(ListServers));
            foreach(string server in servers)
            {
                lstOPCServer.Nodes.Add(server);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                
               MyOPCServer[iOPC].MyServer.Connect(lstOPCServer.SelectedNode.Text, txtNodeAddress.Text);
               if (MyOPCServer[iOPC].MyServer.ServerState == 1)
               {
                   StatusConnection.Text = "Connected";
                   lstOPCServer.SelectedNode.ForeColor = Color.Green;
                   btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    MonItem_Count = dataOPC.RowCount - 1;

                    if (MyOPCGroup[iOPC] == null)
                    {
                        MyOPCGroup[iOPC] = MyOPCServer[iOPC].MyServer.OPCGroups.Add("MyOPC_" + iOPC);
                    }
                    MyOPCGroup[iOPC].IsActive = false;
                    MyOPCGroup[iOPC].IsSubscribed = true;
                    MyOPCGroup[iOPC].DataChange += new DIOPCGroupEvent_DataChangeEventHandler(MyOPCGroup_DataChange);
                    //MyOPCGroup[iOPC].AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(MyOPCGroup_AsyncWriteComplete);
                    MyOPCGroup[iOPC].AsyncReadComplete += new DIOPCGroupEvent_AsyncReadCompleteEventHandler(MyOPCGroup_AsyncReadComplete);
               }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please Browse Server Name", "Alert", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                ExceptionStatus.Text = ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 10; i++)
            {
                MyOPCServer[i].MyServer = new OPCServer();
                MyOPCServer[i].ServerHandles = new int[1000];
                MyOPCServer[i].Errors = new int[1000];
                MyOPCServer[i].Values = new object[1000];
            }
        }
        //private void lstOPCServer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    lstOPCServer.SelectedNode = lstOPCServer.GetNodeAt(e.X, e.Y);

        //}
        //private void lstOPCServer_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    for (int i = 0; i <= lstOPCServer.Nodes.Count - 1; i++)
        //    {
        //        lstOPCServer.Nodes[i].BackColor = Color.White;
        //    }
        //    lstOPCServer.SelectedNode.BackColor = Color.Cyan;
        //    iOPC = lstOPCServer.SelectedNode.Index;
        //}

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                bool okDiskonek = true;
                for (int i = 0; i <= 10; i++)
                {
                    if (MyOPCServer[i].MyServer.ServerState == 1)
                    {
                        MyOPCServer[i].MyServer.Disconnect();
                        if (MyOPCServer[i].MyServer.ServerState == 1)
                        {
                            okDiskonek = false;
                        }
                    }
                }
                if (okDiskonek)
                {
                    StatusConnection.Text = "Disconnected";
                    lstOPCServer.SelectedNode.ForeColor = Color.Black;
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    treeOPC.Nodes.Clear();
                    lstOPCItems.Items.Clear();
                }
                else
                {
                    StatusConnection.Text = "ERROR Disconnect!";
                }
            }
            catch(Exception ex)
            {
                StatusConnection.Text = "ERROR Disconnect!  ";
                ExceptionStatus.Text = ex.Message;
            }
            
        }

        private void btnBrowseOPCItems_Click(object sender, EventArgs e)
        {
            lstOPCItems.Items.Clear();
            treeOPC.Nodes.Clear();
            treePath = "";
            if (lstOPCServer.SelectedNode.ForeColor != Color.Green)
            {
                return;
            }

            MyOPCBrowser = MyOPCServer[iOPC].MyServer.CreateBrowser();
            MyOPCBrowser.MoveToRoot();
            Show_Leafs(MyOPCBrowser);

            MyOPCBrowser.MoveToRoot();
            Show_Branches(MyOPCBrowser, treeOPC.SelectedNode);
        }

        public void Show_Leafs(OPCBrowser MyOPCBrowser)
        {
            MyOPCBrowser.ShowLeafs();
            int a;
            dynamic iA = null;
            iA = MyOPCBrowser.Count;
            string name1 = "";
            lstOPCItems.Items.Clear();
            for (a = 1; a <= iA; a++)
            {
                name1 = MyOPCBrowser.Item(a).ToString();
                string name2 = name1.ToLower();
                lstOPCItems.Items.Add(name1);
            }
        }

        public void Show_Branches(OPCBrowser MyOPCBrowser, TreeNode aNode)
        {
            MyOPCBrowser.ShowBranches();
            if ((aNode != null))
            {
                aNode.Nodes.Clear();
            }
            dynamic iA = null;
            dynamic iB = null;
            iA = MyOPCBrowser.Count;
            for (int a = 1; a <= iA; a++)
            {
                try
                {
                    string sName = MyOPCBrowser.Item(a);
                    if (aNode == null)
                    {
                        treeOPC.Nodes.Add(sName);
                    }
                    else
                    {
                        aNode.Nodes.Add(sName);
                    }
                    MyOPCBrowser.MoveDown(sName);
                    MyOPCBrowser.ShowBranches();
                    iB = MyOPCBrowser.Count;
                    if (iB > 0)
                    {
                        if (aNode == null)
                        {
                            treeOPC.Nodes[a - 1].Nodes.Add("-");
                        }
                        else
                        {
                            aNode.Nodes[a - 1].Nodes.Add("-");
                        }
                    }
                    MyOPCBrowser.MoveUp();
                }
                catch (Exception ex)
                {
                    ExceptionStatus.Text = ex.Message;
                }
                MyOPCBrowser.ShowBranches();
            }
        }

        private void treeOPC_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            treeOPC.SelectedNode = treeOPC.GetNodeAt(e.X, e.Y);
            try
            {
                string nPath = null;
                nPath = e.Node.FullPath;

                if (nPath == treePath)
                {
                    return;
                }
                else
                {
                    treePath = nPath;
                }

                string[] sPath;
                string[] sBranch = new string[11];
                int branchCount = 0;

                sPath = nPath.Split('\\');
                branchCount = sPath.Count();
                for (int i = 0; i <= branchCount - 1; i++)
                {
                    sBranch[i] = sPath[i];
                }


                
                MyOPCBrowser = MyOPCServer[iOPC].MyServer.CreateBrowser();

                MyOPCBrowser.MoveToRoot();
                for (int i = 0; i <= branchCount - 1; i++)
                {
                    MyOPCBrowser.ShowBranches();
                    MyOPCBrowser.MoveDown(sBranch[i]);
                }
                Show_Leafs(MyOPCBrowser);
                Show_Branches(MyOPCBrowser, treeOPC.SelectedNode);

            }
            catch //(Exception ex)
            {
                //
            }
        }

        private void btnAddToMonitoring_Click(object sender, EventArgs e)
        {
            try
            {
                dataOPC.Enabled = true;
                dynamic indeks = lstOPCItems.SelectedIndices[0];
                dynamic icount = lstOPCItems.SelectedItems.Count;
                for (int i = indeks; i <= (indeks + icount - 1); i++)
                {
                    string itemName = null;
                    itemName = MyOPCBrowser.GetItemID(lstOPCItems.Items[i].Text);

                    dataOPC.Rows.Add();
                    dataOPC[0, MonItem_Count].Value = itemName;

                    MonItem_Count += 1;

                    Array.Resize(ref MonItem, MonItem_Count + 1);
                    MonItem[MonItem_Count]._Server = iOPC;
                    MonItem[MonItem_Count]._Name = itemName;
                    MonItem[MonItem_Count]._Index = dataOPC.RowCount - 1;

                    MyOPCServer[iOPC].MyItem = MyOPCGroup[iOPC].OPCItems.AddItem(itemName, MonItem_Count);
                    MyOPCServer[iOPC].ServerHandles.SetValue(MyOPCServer[iOPC].MyItem.ServerHandle, MonItem_Count);

                }
                lstOPCItems.SelectedIndices.Clear();
            }
            catch(Exception ex)
            {
                ExceptionStatus.Text = ex.Message;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (MonItem_Count == 0)
                {
                    SubscribeItems();
                }

                int numItems = MonItem_Count;
                int transID;
                MyOPCGroup[iOPC].AsyncRead(numItems, MyOPCServer[iOPC].ServerHandles, out MyOPCServer[iOPC].Errors, DateTime.Now.Second, out transID);

                ExceptionStatus.Text = "OK Read";
            }
            catch (Exception ex)
            {
                ExceptionStatus.Text = "ERROR Read - " + ex.Message;
            }
        }
        public void SubscribeItems()
        {
            for (int i = 1; i <= dataOPC.RowCount - 1; i++)
            {
                string itemName = MonItem[i]._Name;
                //int iServer = MonItem[i]._Server;
                MyOPCServer[iOPC].MyItem = MyOPCServer[iOPC].MyGroup.OPCItems.AddItem(itemName, i);
                MyOPCServer[iOPC].ServerHandles.SetValue(MyOPCServer[iOPC].MyItem.ServerHandle, i);
                MonItem_Count += 1;
            }
        }
        private void MyOPCGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                int iHandles = Convert.ToInt32(ClientHandles.GetValue(i));
                dataOPC[1, iHandles - 1].Value = ItemValues.GetValue(i);
                dataOPC[1, iHandles - 1].Style.BackColor = Color.White;
            }
        }
        private void MyOPCGroup_AsyncReadComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps, ref Array Errors)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                int iHandles = Convert.ToInt32(ClientHandles.GetValue(i));
                dataOPC[1, iHandles - 1].Value = ItemValues.GetValue(i);
                dataOPC[1, iHandles - 1].Style.BackColor = Color.White;
            }
            ExceptionStatus.Text = "OK AsyncRead";
        }
    }
    
}
