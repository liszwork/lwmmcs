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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // 確定
        private void submit(string text)
        {
            if ( !isCreatedRoot )
            {
                // root
                manager = new NodeManager(text);
                labelCurrentName.Text = manager.GetCurrentName();
                isCreatedRoot = true;
            }
            else
            {
                manager.Add(textInput.Text);     // 入力確定処理
            }
            textInput.Text = "";

            updateList();
        }

        /// <summary>
        /// 現在Node選択用コンボボックスのアップデート
        /// </summary>
        private void updateList()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(manager.GetCurrentChildNames().ToArray());
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
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            // rootから辿ったNode情報を表示する
            textOutput.Text = "";
            textOutput.Text = manager.ShowAll();
        }

        private void buttonSetCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                // コンボボックスで選択されているものを現在Nodeにセット
                string selectedItem = comboBox1.SelectedItem.ToString();
                manager.SetCurrentNode4Name(selectedItem);
                labelCurrentName.Text = manager.GetCurrentName();
                // 現在Nodeの子要素をコンボボックスにセット
                updateList();
            }
            catch ( Exception )
            {
                // NOP
            }
            comboBox1.Text = "";
        }

        private void buttonPrevCurrent_Click(object sender, EventArgs e)
        {
            string name = this.manager.PrevNode();
            if ( name != "" )
            {
                labelCurrentName.Text = name;
            }
            // 現在Nodeの子要素をコンボボックスにセット
            updateList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FileManager.Save(this.manager.Root);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            this.manager = FileManager.Load();
        }
    }
}
