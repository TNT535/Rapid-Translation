using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(IntPtr hwnd, int id);

        int mHotKeyId = 0;
        //These variables control the mouse position
        int selectX;
        int selectY;
        int selectWidth;
        int selectHeight;
        public Pen selectPen;

        //This variable control when you start the right click
        bool start = false;

        public static Bitmap capture;

        private bool allowshowdisplay = false;

        public Form1()
        {
            InitializeComponent();

            int UniqueHotkeyId = 1;
            int HotKeyCode1 = (int)Keys.Alt;
            int HotKeyCode2 = (int)Keys.W;
            int HotKeyCode3 = (int)Keys.F9;

            Boolean F9Registered = RegisterHotKey(
                this.Handle, UniqueHotkeyId, 0x0000, HotKeyCode3);
            RegisterGlobalHotKey(Keys.W, 0x0001);
            
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //validate if there is an image
            if (pictureBox1.Image == null)
                return;
            //validate if right-click was trigger
            if (start)
            {
                //refresh picture box
                pictureBox1.Refresh();
                //set corner square to mouse coordinates
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;
                //draw dotted rectangle
                pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                          selectX, selectY, selectWidth, selectHeight);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //validate when user right-click
            if (!start)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //starts coordinates for rectangle
                    selectX = e.X;
                    selectY = e.Y;
                    selectPen = new Pen(Color.Red, 1);
                    selectPen.DashStyle = DashStyle.DashDotDot;
                }
                //refresh picture box
                pictureBox1.Refresh();
                //start control variable for draw rectangle
                start = true;
            }
            else
            {
                //validate if there is image
                if (pictureBox1.Image == null)
                    return;
                //same functionality when mouse is over
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pictureBox1.Refresh();
                    selectWidth = e.X - selectX;
                    selectHeight = e.Y - selectY;
                    pictureBox1.CreateGraphics().DrawRectangle(selectPen, selectX,
                             selectY, selectWidth, selectHeight);

                }
                start = false;
                //function save image to clipboard
                SaveToClipboard();
            }
        }

        private void SaveToClipboard()
        {
            //validate if something selected
            if (selectWidth > 0)
            {

                Rectangle rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);
                //create bitmap with original dimensions
                Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                //create bitmap with selected dimensions
                Bitmap _img = new Bitmap(selectWidth, selectHeight);
                //create graphic variable
                Graphics g = Graphics.FromImage(_img);
                //set graphic attributes
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
                //insert image stream into clipboard
                capture = _img;
                Clipboard.SetImage(_img);
            }
            //End application
            //Application.Exit();
            this.Close();
        }

        private void CaptureScreen()
        {
            //Hide the Form
            this.Hide();
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //Create the Bitmap
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                     Screen.PrimaryScreen.Bounds.Height);
            //Create the Graphic Variable with screen Dimensions
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            //Copy Image from the screen
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            //Create a temporal memory stream for the image
            using (MemoryStream s = new MemoryStream())
            {
                //save graphic variable into memory
                printscreen.Save(s, ImageFormat.Bmp);
                pictureBox1.Size = new System.Drawing.Size(this.Width, this.Height);
                //set the picture box with temporary stream
                pictureBox1.Image = Image.FromStream(s);
            }
            //Show Form
            this.allowshowdisplay = true;
            this.SetVisibleCore(allowshowdisplay);
            this.Show();
            this.Activate();
            //Cross Cursor
            Cursor = Cursors.Cross;
        }

        protected override void WndProc(ref Message m)
        {
            // 5. Catch when a HotKey is pressed !
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                //MessageBox.Show(string.Format("Hotkey #{0} pressed", id));

                if (id == 1)
                {
                    CaptureScreen();
                }
            }

            base.WndProc(ref m);
        }

        private void RegisterGlobalHotKey(Keys hotkey, int modifiers)
        {
            try
            {
                // increment the hot key value - we are just identifying
                // them with a sequential number since we have multiples
                mHotKeyId++;

                if (mHotKeyId > 0)
                {
                    // register the hot key combination
                    if (!RegisterHotKey(this.Handle, mHotKeyId, modifiers, Convert.ToInt16(hotkey)))
                    {
                        // tell the user which combination failed to register -
                        // this is useful to you, not an end user; the end user
                        // should never see this application run
                        MessageBox.Show("Error: " + mHotKeyId.ToString() + " - " +
                            Marshal.GetLastWin32Error().ToString(),
                            "Hot Key Registration");
                    }
                }
            }
            catch
            {
                // clean up if hotkey registration failed -
                // nothing works if it fails
                UnregisterGlobalHotKey();
            }
        }

        private void UnregisterGlobalHotKey()
        {
            // loop through each hotkey id and
            // disable it
            for (int i = 0; i < mHotKeyId; i++)
            {
                UnregisterHotKey(this.Handle, i);
            }
        }
    }
}