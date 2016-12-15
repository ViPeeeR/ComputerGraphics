using CGCourseProject.Constants;
using CGCourseProject.Logic;
using CGCourseProject.Settings;
using CGCourseProject.Structs;
using CGCourseProject.Utilits;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGCourseProject
{
    public partial class frmMain : Form
    {
        private Engine engine;


        private int TexWidth;
        private int TexHeight;

        public frmMain()
        {
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            TexHeight = 600;
            TexWidth = 800;
            progressBar1.Maximum = TexWidth;

            engine = new Engine(TexWidth, TexHeight);
            engine.Initialize();
            await RefreshImage();
        }

        private async Task RefreshImage()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var img = await engine.RenderScene(i =>
            {
                try
                {
                    progressBar1.BeginInvoke((MethodInvoker)(()
                        => progressBar1.Value = i));
                }
                catch { }
            });
            sw.Stop();
            pictureBox1.Image = img;
            pictureBox1.Refresh();
            progressBar1.Value = 0;

            label1.Text = $"Отрисовка выполнена за {sw.ElapsedMilliseconds} ms.";
        }

        private async void btnForward_Click(object sender, EventArgs e)
        {
            engine.MoveCamera(new Vector3d(0, 0, Consts.DZ));
            await RefreshImage();
        }

        private async void btnDown_Click(object sender, EventArgs e)
        {
            engine.MoveCamera(new Vector3d(0, 0, -Consts.DZ));
            await RefreshImage();
        }

        private async void btnLeft_Click(object sender, EventArgs e)
        {
            engine.MoveCamera(new Vector3d(-Consts.DX, 0, 0));
            await RefreshImage();
        }

        private async void btnRight_Click(object sender, EventArgs e)
        {
            engine.MoveCamera(new Vector3d(Consts.DX, 0, 0));
            await RefreshImage();
        }

        private async void ToolStripMenuItemSphere_Click(object sender, EventArgs e)
        {
            var settings = SettingsSphere.DefaultSettings();

            var frmSettings = new frmSettingsSphere(settings);
            var result = frmSettings.ShowDialog();
            if (result == DialogResult.OK)
            {
                engine.AddObject(settings);
                await RefreshImage();
            }
        }

        private async void btnTop_Click(object sender, EventArgs e)
        {
            engine.MoveCamera(new Vector3d(0, -Consts.DX, 0));
            await RefreshImage();
        }

        private async void btnLow_Click(object sender, EventArgs e)
        {
            engine.MoveCamera(new Vector3d(0, Consts.DX, 0));
            await RefreshImage();
        }

        private async void btnTopCamera_Click(object sender, EventArgs e)
        {
            engine.MoveCamera(CameraState.TopState);
            await RefreshImage();
        }

        private async void btnRForward_Click(object sender, EventArgs e)
        {
            engine.RotateCamera(new Coord(Consts.ANGEL, 0, 0));
            await RefreshImage();
        }

        private async void btnRLeft_Click(object sender, EventArgs e)
        {
            engine.RotateCamera(new Coord(0, 0, Consts.ANGEL));
            await RefreshImage();
        }

        private async void btnRRight_Click(object sender, EventArgs e)
        {
            engine.RotateCamera(new Coord(0, 0, -Consts.ANGEL));
            await RefreshImage();
        }

        private async void btnRDown_Click(object sender, EventArgs e)
        {
            engine.RotateCamera(new Coord(-Consts.ANGEL, 0, 0));
            await RefreshImage();
        }

        private async void btnCamDefault_Click(object sender, EventArgs e)
        {
            engine.MoveCamera(CameraState.DefaultState);
            await RefreshImage();
        }

        private void btntoolExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void ToolStripMenuItemPlane_Click(object sender, EventArgs e)
        {
            engine.Avion();
            await RefreshImage();
        }

        private async void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            engine.ClearScene();
            await RefreshImage();
        }

        private void toolStripMenuItemBox_Click(object sender, EventArgs e)
        {
            //var settings = SettingsSphere.DefaultSettings();

            //var frmSettings = new frmSettingsSphere(settings);
            //var result = frmSettings.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    engine.AddObject(settings);
            //    await RefreshImage();
            //}
        }

        private async void toolStripMenuItemLightSource_Click(object sender, EventArgs e)
        {
            engine.AddLight();
            await RefreshImage();
        }
    }
}
