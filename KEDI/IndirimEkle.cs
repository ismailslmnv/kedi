using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Transactions;

namespace KEDI
{
    public partial class IndirimEkle : Form
    {
        public static int IndirimIDPassed = 1;
        private bool indirimUygulandi = false;
        public IndirimEkle()
        {
            InitializeComponent();
          //  if (IndirimIDPassed != -1)
            //{
                firstCreator();
            //}
        }

        private void ok_Click(object sender, EventArgs e)
        {
           try
            {
                decimal Oran = decimal.Parse(oran.Text.Trim());
                using (var context = new KEDIDBEntities())
                {
                    DateTime eklenmeTarihi = DateTime.Now;                                  
                    if (indirimUygulandi)
                    {
                        int[] checkedNodes = getCheckedNodes();
                        for (int i = 0; i < checkedNodes.Length; i++)
                        {
                            int node = checkedNodes[i];
                            Urunler urunler = context.Urunlers.FirstOrDefault(u => u.UrunID == node);
                            if (urunler != null)
                            {
                                var indirimInserter = context.Set<Indirimler>();
                                indirimInserter.Add(new Indirimler { IndirimAdi = indirimAdi.Text.Trim(), Oran = Oran, Tarih = eklenmeTarihi, UrunID=urunler.UrunID});
                                context.SaveChanges();
                            }                            
                        }                                                                        
                    }                    
                }
                MessageBox.Show("İndirmler Başarıyla Uygulandı.");                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Close();
        }
        private void firstCreator()
        {
            try
            {
                using (var context = new KEDIDBEntities())
                {
                    var query = (from c in context.Urunlers // where c.IndirimID == IndirimIDPassed
                                 where c.UstUrunID.HasValue==false
                                 select c).ToList();
                    List<int> ustUrunIDler = new List<int>();
                    uygulanacaklar.BeginUpdate();
                    foreach (var item in query)
                    {                        
                        ustUrunIDler.Add(item.UrunID);
                        uygulanacaklar.Nodes.Add(item.UrunID + "-" + item.UrunAdi);                     
                    }
                    uygulanacaklar.EndUpdate();
                    var query1 = (from d in context.Urunlers
                                  where d.UstUrunID.HasValue == true
                                  where d.AltOzellik == false
                                  select d).ToList();
                    foreach (var item in query1)
                    {
                        if (item.UstUrunID.HasValue)
                        {
                            foreach (var ustID in ustUrunIDler)
                            {
                                if (item.UstUrunID == ustID)
                                {
                                    for(int i = 0; i<ustUrunIDler.Count; i++)
                                    {
                                        TreeNode parentNode = uygulanacaklar.Nodes[i];
                                        string ustIDS = uygulanacaklar.Nodes[i].Text.Substring(0, uygulanacaklar.Nodes[i].Text.IndexOf('-')).Trim();
                                        int ustIDI = Convert.ToInt32(ustIDS);
                                        if (ustID == ustIDI)
                                        {
                                            parentNode.Nodes.Add(item.UrunID + "-" + item.UrunAdi);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                uygulanacaklar.ExpandAll();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void uygulanacaklar_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
            if (e.Node.Checked)
            {
                indirimUygulandi = true;
            }
            else
            {
                indirimUygulandi = false;
            }
            
        }
        // Updates all child tree nodes recursively.
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
       // Return a list of the TreeNodes that are checked.
        private void FindCheckedNodes( List<TreeNode> checked_nodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.Checked) checked_nodes.Add(node);

                // Check the node's descendants.
                FindCheckedNodes(checked_nodes, node.Nodes);
            }
        }
        // Return a list of the checked TreeView nodes.
        private List<TreeNode> CheckedNodes()
        {
            List<TreeNode> checked_nodes = new List<TreeNode>();
            FindCheckedNodes(checked_nodes, uygulanacaklar.Nodes);
            return checked_nodes;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            
        }
        private int[] getCheckedNodes()
        {
            List<TreeNode> treeNodes = CheckedNodes();
            int[] nodes= new int[treeNodes.Count];
            int outed = -1;
            int counter = 0;
            foreach (var item in treeNodes)
            {
                string itemText = item.Text.Trim().Substring(0, item.Text.Trim().IndexOf('-'));
                if (Int32.TryParse(itemText,out outed))
                {
                    nodes[counter++] = Convert.ToInt32(itemText.Trim());
                }
                else 
                {
                    MessageBox.Show("Bir Hata Oluştu");
                }
            }
            return nodes;
        }
    }
}
