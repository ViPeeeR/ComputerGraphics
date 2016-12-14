using CGCourseProject.Extentions;
using CGCourseProject.Logic;
using CGCourseProject.Settings;
using CGCourseProject.Structs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGCourseProject
{
    public partial class frmSettingsSphere : Form
    {
        public SettingsSphere Settings { get; private set; }

        public frmSettingsSphere()
        {
            InitializeComponent();
        }

        public frmSettingsSphere(SettingsSphere settings)
        {
            InitializeComponent();
            Settings = settings;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int x, y, z;

            int.TryParse(txbCx.Text, out x);
            int.TryParse(txbCy.Text, out y);
            int.TryParse(txbCz.Text, out z);

            Settings.Center = new Point3d(x, y, z);

            float ka, kd, ks, kr;

            float.TryParse(txbKa.Text, out ka);
            float.TryParse(txbKd.Text, out kd);
            float.TryParse(txbKs.Text, out ks);
            float.TryParse(txbKr.Text, out kr);

            Settings.Material = new Material(ka, kd, ks, kr, 0, 10);

            float radius;
            float.TryParse(txbRadius.Text, out radius);

            Settings.Radius = radius;

            Settings.Color = pColor.BackColor.ToRGB();

        }

        private void frmSettingsSphere_Load(object sender, EventArgs e)
        {
            txbCx.Text = Settings.Center.X.ToString();
            txbCy.Text = Settings.Center.Y.ToString();
            txbCz.Text = Settings.Center.Z.ToString();

            txbKa.Text = Settings.Ka.ToString();
            txbKd.Text = Settings.Kd.ToString();
            txbKs.Text = Settings.Ks.ToString();
            txbKr.Text = Settings.Kr.ToString();

            pColor.BackColor = Settings.Color.ToRGB();
            txbRadius.Text = Settings.Radius.ToString();
        }

        private void pColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pColor.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pColor.BackColor = colorDialog1.Color;
            }
        }
    }
}
