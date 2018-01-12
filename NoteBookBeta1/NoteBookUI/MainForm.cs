using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoteBookUI
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(@"www.baidu.com");
            webBrowser1.Navigate("C:/Users/admit/Documents/Visual Studio 2010/Projects/NoteBookAppBeta1/NoteBookUI/Resources/Editor.html");
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = false; //禁用错误脚本提示
        }
        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                UiUtil.Output(this, "closed");
                this.webBrowser1.Dispose();
                System.Environment.Exit(0);
            }
            catch (Exception exc)
            {
                UiUtil.Output(this, exc.Message);
            }

        }
    }
}
