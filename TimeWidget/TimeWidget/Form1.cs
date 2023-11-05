using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeWidget
{
    public partial class Form1 : Form
    {
        private bool mousePressed;
        private bool clocksSynchronized;
        private Point clickPoint;
        private Point formStartPoint;

        #region Other

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            this.ShowInTaskbar = false;
            HideFromAltTab.Hide(this);

            SetFormToBack.ToBack();

            Location = new Point(SaveFile.save.p[0], SaveFile.save.p[1]);

            this.BackColor = Color.FromArgb(SaveFile.save.c[0], SaveFile.save.c[1], SaveFile.save.c[2]);
            this.TransparencyKey = this.BackColor;

            Show();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            SetFormToBack.ToBack();

            Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ShowDesktop.RemoveHook();

            Show();
        }

        #endregion

        public Form1()
        {
            InitializeComponent();

            SetFormToBack.form = this;
            SaveFile.Init();

            this.FormBorderStyle = FormBorderStyle.None;

            this.AllowTransparency = true;

            TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            DayOfTheWeekLabel.Text = DateTime.Now.DayOfWeek.ToString();

            timer1.Interval = DateTime.Now.Second;
            timer1.Start();

            ShowDesktop.AddHook(this);
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            if (!clocksSynchronized)
            {
                timer1.Interval = 100;
                clocksSynchronized = true;
            }

            TimeLabel.Text = DateTime.Now.ToString("H:mm:ss");
            DayOfTheWeekLabel.Text = DateTime.Now.DayOfWeek.ToString();
        }

        #region Move
        private new void MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                var cursorOffsetPoint = new Point( //считаем смещение курсора от старта
                    Cursor.Position.X - clickPoint.X,
                    Cursor.Position.Y - clickPoint.Y);

                Location = new Point( //смещаем форму от начальной позиции в соответствии со смещением курсора
                    formStartPoint.X + cursorOffsetPoint.X,
                    formStartPoint.Y + cursorOffsetPoint.Y);
            }
        }

        private new void MouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
            clickPoint = Point.Empty;

            this.BackColor = GetScreenPixel.GetPixelColor(this.Location);
            this.TransparencyKey = this.BackColor;

            SaveFile.save.p[0] = this.Location.X;
            SaveFile.save.p[1] = this.Location.Y;

            if (e.Button == MouseButtons.Middle)
            {
                SaveFile.SaveConfig();

                Environment.Exit(0);
            }
        }

        private new void MouseDown(object sender, MouseEventArgs e)
        {
            mousePressed = true;
            clickPoint = Cursor.Position;
            formStartPoint = Location;
        }
        #endregion
    }
}
