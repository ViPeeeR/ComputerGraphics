using CGCourseProject.Extentions;
using CGCourseProject.Logic;
using CGCourseProject.Utilits;
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
    public partial class frmSettingsObject : Form
    {
        private SceneFaceHandlerParams _settings;

        public frmSettingsObject()
        {
            InitializeComponent();
        }

        public frmSettingsObject(SceneFaceHandlerParams settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int x, y, z;

            int.TryParse(txbCx.Text, out x);
            int.TryParse(txbCy.Text, out y);
            int.TryParse(txbCz.Text, out z);

            _settings.dx = x;
            _settings.dy = y;
            _settings.dz = z;

            float ax, ay, az;

            float.TryParse(txbCx.Text, out ax);
            float.TryParse(txbCy.Text, out ay);
            float.TryParse(txbCz.Text, out az);

            _settings.X = ax;
            _settings.Y = ay;
            _settings.Z = az;

            float ka, kd, ks, kr;

            float.TryParse(txbKa.Text, out ka);
            float.TryParse(txbKd.Text, out kd);
            float.TryParse(txbKs.Text, out ks);
            float.TryParse(txbKr.Text, out kr);

            _settings.DefaultMaterial = new Material(ka, kd, ks, kr, 0, 10);

            float size;
            float.TryParse(txbSize.Text, out size);

            _settings.Scale = size;

            _settings.DefaultColor = pColor.BackColor.ToRGB();
        }

        private void pColor_Paint(object sender, PaintEventArgs e)
        {
            colorDialog1.Color = pColor.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pColor.BackColor = colorDialog1.Color;
            }
        }

        private void frmSettingsObject_Load(object sender, EventArgs e)
        {
            txbCx.Text = _settings.dx.ToString();
            txbCy.Text = _settings.dz.ToString();
            txbCz.Text = _settings.dy.ToString();
        }
    }
}
