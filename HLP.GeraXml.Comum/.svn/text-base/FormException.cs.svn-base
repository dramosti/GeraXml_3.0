using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace HLP.GeraXml.Comum
{
    public partial class FormException : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private int _heightUpDown;
        public FormException(string xMessage, string xInner, string xDetalhes)
        {
            InitializeComponent();
            txtDescricao.Text = string.Format("{0}{1}{2}", xMessage, Environment.NewLine, xInner);
            txtDetalhes.Text = "Local do erro:" + xDetalhes;
            btnOk.Focus();
        }
        private void buttonSpecUpDown_Click(object sender, EventArgs e)
        {
            // Suspend layout changes until all splitter properties have been updated
            kryptonSplitContainerVertical.SuspendLayout();


            // Is the bottom right header group currently expanded?
            if (kryptonSplitContainerVertical.FixedPanel == FixedPanel.None)
            {
                // Make the bottom panel of the splitter fixed in size
                kryptonSplitContainerVertical.FixedPanel = FixedPanel.Panel2;
                kryptonSplitContainerVertical.IsSplitterFixed = true;

                // Remember the current height of the header group (to restore later)
                _heightUpDown = kryptonHeaderGroupRightBottom.Height;

                // Find the new height to use for the header group
                int newHeight = kryptonHeaderGroupRightBottom.PreferredSize.Height;

                // Make the header group fixed to the new height
                kryptonSplitContainerVertical.Panel2MinSize = newHeight;
                kryptonSplitContainerVertical.SplitterDistance = kryptonSplitContainerVertical.Height;
            }
            else
            {
                // Make the bottom panel not-fixed in size anymore
                kryptonSplitContainerVertical.FixedPanel = FixedPanel.None;
                kryptonSplitContainerVertical.IsSplitterFixed = false;

                // Put back the minimise size to the original
                kryptonSplitContainerVertical.Panel2MinSize = 100;

                // Calculate the correct splitter we want to put back
                kryptonSplitContainerVertical.SplitterDistance = kryptonSplitContainerVertical.Height - _heightUpDown - kryptonSplitContainerVertical.SplitterWidth;
            }

            kryptonSplitContainerVertical.ResumeLayout();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormException_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FormException_Load(object sender, EventArgs e)
        {
            btnOk.Focus();
        }

        private void kryptonPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonHeaderGroupRightBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {

        }



    }
}