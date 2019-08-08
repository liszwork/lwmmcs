using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mmCreaterCs
{
    public partial class Form1 : Form
    {
        private NodeManager manager;
        private bool isCreatedRoot = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 確定
        private void submit(string text)
        {
            if ( !isCreatedRoot )
            {
                manager = new NodeManager(text);
                isCreatedRoot = true;
            }
            else
            {
                manager.Add(textInput.Text);     // 入力確定処理
            }
            textInput.Text = "";

            updateList();
        }

        private void updateList()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(manager.GetChildNames().ToArray());
        }

        /*******************************************************/

        private void textInput_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter )
            {
                submit(textInput.Text);
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            submit(textInput.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // コンボボックスの選択
            string selectedItem = comboBox1.SelectedItem.ToString();

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            textOutput.Text = "";
            textOutput.Text = manager.ShowAll();
        }
    }
}
