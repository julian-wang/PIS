using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicAnalyzer
{
    public partial class PicSelector : Form
    {
        public Bitmap bitOrig;

        public PicSelector()
        {
            InitializeComponent();
            pictureBoxOrig.Image = this.bitOrig;
        }
    }
}
