using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 뎁라디오
{
	public partial class NowPlayingSetting : Form
	{
		public Boolean NowPlaying = false;
		public String NowPlayingPath = "";
		public Boolean NowPlayingMulti = false;
		public NowPlayingSetting()
		{
			InitializeComponent();

			textBox1.ReadOnly = true;

			if (checkBox1.Checked == true)
			{
				NowPlaying = true;
			}
			else {
				NowPlaying = false;
			}
		}

		private void textBox1_Click(object sender, EventArgs e)
		{
			NowPlayingPath = saveDialog();
			textBox1.Text = NowPlayingPath;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				NowPlaying = true;
			}
			else {
				NowPlaying = false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NowPlayingPath = saveDialog();
			textBox1.Text = NowPlayingPath;
		}

		private String saveDialog() {
			SaveFileDialog save = new SaveFileDialog();
			save.Title = "Now Playing을 저장할 위치를 선택해 주세요!";
			save.Filter = "텍스트 파일|*.txt";
			save.ShowDialog();
			return save.FileName;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked == true)
			{
				NowPlayingMulti = true;
			}
			else {
				NowPlayingMulti = false;
			}
		}
	}
}
