﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace evieplus.Forms
{
    public partial class NayaxNotWorkForm : Form
    {
        public NayaxNotWorkForm()
        {
            InitializeComponent();
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
        }

        private void NayaxNotWorkForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            Thread.Sleep(5000);
            DialogResult = DialogResult.Cancel;
        }
    }
}