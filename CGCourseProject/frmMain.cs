using CGCourseProject.Abstracts;
using CGCourseProject.Extentions;
using CGCourseProject.Logic;
using CGCourseProject.Scenes;
using CGCourseProject.Structs;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGCourseProject
{
    public partial class frmMain : Form
    {
        private const float ANGEL = 0.1f;
        private const int DZ = 50;
        private const int DX = 50;
        private IScene builder;

        private Scene scene;
        private ICamera camera;
        private Canvas canvas;
        private Render render;
        private Bitmap img;


        private int TexWidth;
        private int TexHeight;

        private bool CameraStateChange;

        public frmMain()
        {
            InitializeComponent();
        }

        private void InitSceneAndCamera()
        {
            render = new Render();
            scene = builder.CreateScene();

            float focus = 1000;
            float xAngle = (float)-Math.PI / 2f;
            float yAngle = 0;
            float zAngle = (float)Math.PI;

            camera = new Camera(new Point3d(0, 500, 0), xAngle, yAngle, zAngle, focus);

            img = new Bitmap(TexWidth, TexHeight);
            canvas = new Canvas(TexWidth, TexHeight);
        }        

        private async void frmMain_Load(object sender, EventArgs e)
        {
            TexHeight = 600;
            TexWidth = 800;

            builder = new Scene1();

            InitSceneAndCamera();
            CameraStateChange = true;
            await RenderScene();
        }

        private async Task RenderScene()
        {
            if (CameraStateChange)
            {
                await render.MakeRendering(scene, camera, canvas);

                for (int i = 0; i < TexWidth; i++)
                    for (int j = 0; j < TexHeight; j++)
                        img.SetPixel(i, j, canvas.GetPixel(i, j).ToRGB());

                CameraStateChange = false;
            }

            pictureBox1.Image = img;
            pictureBox1.Refresh();
            pictureBox1.Invalidate();
        }

        private async Task PrepareAndRender()
        {
            CameraStateChange = true;
            await RenderScene();
        }

        private async void btnCamUp_Click(object sender, EventArgs e)
        {
            if (!CameraStateChange)
            {
                if (chkIsMove.Checked)
                    camera.MoveCamera(new Vector3d(0, 0, DZ));
                else
                    camera.RatateCamera(ANGEL, 0, 0);

                await PrepareAndRender();
            }
        }

        private async void btnDown_Click(object sender, EventArgs e)
        {
            if (!CameraStateChange)
            {
                if (chkIsMove.Checked)
                    camera.MoveCamera(new Vector3d(0, 0, -DZ));
                else
                    camera.RatateCamera(-ANGEL, 0, 0);

                await PrepareAndRender();
            }
        }

        private async void btnLeft_Click(object sender, EventArgs e)
        {
            if (!CameraStateChange)
            {
                if (chkIsMove.Checked)
                    camera.MoveCamera(new Vector3d(-DX, 0, 0));
                else
                    camera.RatateCamera(0, 0, ANGEL);

                await PrepareAndRender();
            }
        }

        private async void btnRight_Click(object sender, EventArgs e)
        {
            if (!CameraStateChange)
            {
                if (chkIsMove.Checked)
                    camera.MoveCamera(new Vector3d(DX, 0, 0));
                else
                    camera.RatateCamera(0, 0, -ANGEL);

                await PrepareAndRender();
            }
        }
    }
}
