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

        /// <summary>
        /// カレント表示を現在のカレントで更新
        /// </summary>
        private void UpdateCurrent()
        {
            this.labelCurrentName.Text = this.manager.GetCurrentName();
        }

        // 確定
        private void Submit(string text)
        {
            if ( !this.isCreatedRoot )
            {
                // root
                this.manager = new NodeManager(text);
                this.UpdateCurrent();
                this.isCreatedRoot = true;
            }
            else
            {
                manager.Add(this.textInput.Text);     // 入力確定処理
            }
            this.textInput.Text = "";

            this.UpdateList();
        }

        /// <summary>
        /// 現在Node選択用コンボボックスのアップデート
        /// </summary>
        private void UpdateList()
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(this.manager.GetCurrentChildNames().ToArray());
        }

        /*******************************************************/

        private void textInput_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter )
            {
                this.Submit(textInput.Text);
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            this.Submit(textInput.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            // rootから辿ったNode情報を表示する
            this.textOutput.Text = "";
            this.textOutput.Text = manager.ShowAll();
        }

        private void buttonSetCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                // コンボボックスで選択されているものを現在Nodeにセット
                string selectedItem = this.comboBox1.SelectedItem.ToString();
                this.manager.SetCurrentNode4Name(selectedItem);
                this.UpdateCurrent();
                // 現在Nodeの子要素をコンボボックスにセット
                this.UpdateList();
            }
            catch ( Exception )
            {
                // NOP
            }
            this.comboBox1.Text = "";
        }

        private void buttonPrevCurrent_Click(object sender, EventArgs e)
        {
            string name = this.manager.PrevNode();
            if ( name != "" )
            {
                this.labelCurrentName.Text = name;
            }
            // 現在Nodeの子要素をコンボボックスにセット
            this.UpdateList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FileManager.Save(this.manager.Root);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            this.manager = FileManager.Load();
        }

        private void textEditNodeName_Enter(object sender, EventArgs e)
        {
            if ( this.textEditNodeName.Text == "edit node name" )
            {
                this.textEditNodeName.Text = "";
            }
        }

        private void textEditNodeName_Leave(object sender, EventArgs e)
        {
            if ( this.textEditNodeName.Text == "" )
            {
                this.textEditNodeName.Text = "edit node name";
            }
        }

        private void textEditNodeName_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter )
            {
                // TODO
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if ( !this.manager.DeleteCurrent() )
            {
                return;
            }
            this.UpdateCurrent();
        }
    }
}
