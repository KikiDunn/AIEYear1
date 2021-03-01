using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			PictureBox back = new PictureBox();
			back.Image = new Bitmap(@"../../assets/background.png");
			back.Parent = this;
			back.Location = new Point(0, 0);
			back.SizeMode = PictureBoxSizeMode.StretchImage;
			back.Width = this.Width;
			PictureBox tank = new PictureBox();
			tank.Image = new Bitmap(@"../../assets/tank.png");
			tank.Parent = this;
			tank.Location = new Point(0, 0);
			tank.SizeMode = PictureBoxSizeMode.StretchImage;
		}
	}
}
