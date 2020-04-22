using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIEBox
{
    public partial class Form1 : Form
    {

        string tName;
        string treeConditionSql;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 设置列头、节点指示器面板、表格线样式
            workSpaceTree.OptionsView.ShowColumns = false;//隐藏列标头
            workSpaceTree.OptionsView.ShowIndicator = false;           //隐藏节点指示器面板
            workSpaceTree.OptionsView.ShowHorzLines = false;           //隐藏水平表格线
            workSpaceTree.OptionsView.ShowVertLines = false;           //隐藏垂直表格线
            workSpaceTree.OptionsView.ShowIndentAsRowStyle = false;
            #endregion
            #region 初始禁用单元格选中，禁用整行选中
            workSpaceTree.OptionsView.ShowFocusedFrame = true;                               //设置显示焦点框
            workSpaceTree.OptionsSelection.EnableAppearanceFocusedCell = false;              //禁用单元格选中
            workSpaceTree.OptionsSelection.EnableAppearanceFocusedRow = false;               //禁用正行选中

            #endregion 
             #region 设置TreeList的展开折叠按钮样式和树线样式

            workSpaceTree.OptionsView.ShowButtons = true;                  //显示展开折叠按钮
            workSpaceTree.LookAndFeel.UseDefaultLookAndFeel = false;       //禁用默认外观与感觉
            workSpaceTree.LookAndFeel.UseWindowsXPTheme = true;            //使用WindowsXP主题
            workSpaceTree.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Percent50;     //设置树线的样式

            #endregion

            #region 添加单列

            DevExpress.XtraTreeList.Columns.TreeListColumn colNode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colNode.Name = String.Format("col{0}", "NodeText");
            colNode.Caption = "NodeText";
            colNode.FieldName = "NodeText";
            colNode.VisibleIndex = 0;
            colNode.Visible = true;

            colNode.OptionsColumn.AllowEdit = false;                        //是否允许编辑
            colNode.OptionsColumn.AllowMove = false;                        //是否允许移动
            colNode.OptionsColumn.AllowMoveToCustomizationForm = false;     //是否允许移动至自定义窗体
            colNode.OptionsColumn.AllowSort = false;                        //是否允许排序
            colNode.OptionsColumn.FixedWidth = false;                       //是否固定列宽
            colNode.OptionsColumn.ReadOnly = true;                          //是否只读
            colNode.OptionsColumn.ShowInCustomizationForm = true;           //移除列后是否允许在自定义窗体中显示

            workSpaceTree.Columns.Clear();
            workSpaceTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colNode });

            #endregion

            workSpaceTree.KeyFieldName = "Id";
            workSpaceTree.ParentFieldName = "ParentId";

            DataTreeNode node1 = new DataTreeNode();
            node1.Id = "1";
            node1.ParentId = null;
            node1.NodeText = "空间查询";

            DataTreeNode node11 = new DataTreeNode();
            node11.Id = "2";
            node11.ParentId = "1";
            node11.NodeText = "属性查询";

            DataTreeNode node2 = new DataTreeNode();
            node2.Id = "3";
            node2.ParentId = null;
            node2.NodeText = "矢量数据分析";

            DataTreeNode node21 = new DataTreeNode();
            node21.Id = "4";
            node21.ParentId = "3";
            node21.NodeText = "叠加分析";


            List<DataTreeNode> data = new List<DataTreeNode>();

            data.Add(node1);
            data.Add(node11);
            data.Add(node2);
            data.Add(node21);
            
            workSpaceTree.DataSource = data;
            workSpaceTree.RefreshDataSource();  


        
        }

        /// <summary>
        /// 实现树节点的过滤查询
        /// </summary>
        private void InitSearchControl()
        {
            searchControl1.Client = workSpaceTree;
            workSpaceTree.FilterNode += (object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e) =>
            {
                if (workSpaceTree.DataSource == null)
                    return;
                string nodeText = e.Node.GetDisplayText("Name");//参数填写FieldName 
                if (string.IsNullOrWhiteSpace(nodeText))
                    return;
                bool isExist = nodeText.IndexOf(searchControl1.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                if (isExist)
                {
                    var node = e.Node.ParentNode;
                    while (node != null)
                    {
                        if (!node.Visible)
                        {
                            node.Visible = true;
                            node = node.ParentNode;
                        }
                        else
                            break;
                    }
                }
                e.Node.Visible = isExist;
                e.Handled = true;
            };
        }


        /// <summary>
        /// 实现树节点选中的事件处理，则需要实现FocusedNodeChanged事件
        /// </summary>
        private void FocusedNodeChanged()
        {
            if (workSpaceTree.FocusedNode != null)
            {
                var PID = string.Concat(workSpaceTree.FocusedNode.GetValue("ID"));
                treeConditionSql = string.Format("DictType_ID = '{0}'", PID);
            }
            else
            {
                treeConditionSql = "";
            }
           // BindData();
        }

        private void workSpaceTree_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e)
        {
            //FocusedNodeChanged();
        }

        private void workSpaceTree_MouseClick(object sender, MouseEventArgs e)
        {
            if(workSpaceTree.Nodes[0].Nodes[0].Selected){
                MessageBox.Show("这是一个");
                
            }
        }

    }
}
