using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallName
{
    public partial class Form1 : Form
    {
        string firstOrder = "-1";
        ToolsEnum curTools = ToolsEnum.NONE;
        int curSel = -1;
        int curOrder = -1;
        Random rd = new Random();
        List<string> m_names2 = new List<string>();
        string[] m_names = new string[] { "段瑛杰", "侯军", "冯更新", "宋成安", "马耀", "汪根源", "刘赛", "周浩", "王奥华", "陈毅", "邓恒","黄佳国" ,"李明雨", "高雅婧" };
        List<string> m_order = new List<string>();

        public Form1()
        {
            InitializeComponent();
            m_names2.AddRange(m_names);
            for (int i=1;i<73;i++)
            {
                m_order.Add(i.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = rd.Next() % m_names2.Count;
            curSel = i;
            textBox1.Text = m_names2[i];
            //产生题目的随机数
            curOrder = rd.Next() % m_order.Count;
            textBox2.Text = m_order[curOrder];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            curTools = ToolsEnum.NAMEANDORDER;//代表既点名又抽题
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            timer1.Start();
            pictureBox1.Image = Image.FromFile("C:\\Data\\pukeImage\\0_1.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (curTools== ToolsEnum.NAMEANDORDER)//既抽名字又抽题
            { 
                timer1.Stop();
                m_names2.RemoveAt(curSel);
                firstOrder = m_order[curOrder];
                m_order.RemoveAt(curOrder);
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
                //显示到列表
                string allName = "";
                for (int i = 0; i < m_names2.Count; i++)
                {
                    allName += m_names2[i] + ",";
                }
                textBox3.Text = allName;
                textBox4.Text += textBox1.Text + ",";
            }
            else if (curTools == ToolsEnum.ORDER)//再抽一题
            {
                timer2.Stop();
                m_order.RemoveAt(curOrder);
                m_order.Add(firstOrder);
                button2.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //产生题目的随机数
            curOrder = rd.Next() % m_order.Count;
            textBox2.Text = m_order[curOrder];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            curTools = ToolsEnum.ORDER;//代表重抽一题
            timer2.Start();
            button2.Enabled = true;
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            string allName = "";
            for (int i=0;i< m_names2.Count;i++)
            {
                allName += m_names2[i]+",";
            }
            textBox3.Text = allName;
        }
    }
}
