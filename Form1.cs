using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 뎁라디오
{
	public partial class Form1 : Form
	{
		NowPlayingSetting npsetting = new NowPlayingSetting();

		public Form1()
		{
			InitializeComponent();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			AddItem AddItemForm = new AddItem();
			if (AddItemForm.ShowDialog(this) == DialogResult.OK)
			{
				listBox1.Items.Add(AddItemForm.textBox1.Text+" | "+AddItemForm.textBox2.Text);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int selIndex = listBox1.SelectedIndex;
			if (selIndex != -1)
			{
				string[] parsedStr = listBox1.SelectedItem.ToString().Split('|');
				EditItem EditItemForm = new EditItem(parsedStr);
				if (EditItemForm.ShowDialog(this) == DialogResult.OK)
				{
					listBox1.Items.RemoveAt(selIndex);
					listBox1.Items.Insert(selIndex, EditItemForm.textBox1.Text + " | " + EditItemForm.textBox2.Text);
				}
				
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex != -1)
			{
				listBox1.Items.RemoveAt(listBox1.SelectedIndex);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex != -1)
			{
				string[] parsedStr = listBox1.SelectedItem.ToString().Split('|');
				label1.Text = parsedStr[0];
				if(npsetting.NowPlaying == true) {
					if(npsetting.NowPlayingMulti) {
						File.WriteAllText(npsetting.NowPlayingPath, "");
						StreamWriter writer = new StreamWriter(npsetting.NowPlayingPath, false);
						for (int i = 0; i < listBox1.Items.Count; i++)
						{
							writer.WriteLine(listBox1.Items[i]);
						}
						writer.Close();
					}
					else {
						File.WriteAllText(npsetting.NowPlayingPath, "");
						StreamWriter writer = new StreamWriter(npsetting.NowPlayingPath, false);
						writer.WriteLine(listBox1.Items[listBox1.SelectedIndex]);
						writer.Close();
					}
				}
				webBrowser1.Navigate("http://devradio.esy.es/#" + listBox1.Items[listBox1.SelectedIndex]);
			}
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void button5_Click(object sender, EventArgs e)
		{
			int selectedIndex = listBox1.SelectedIndex;
			if (selectedIndex > 0)
			{
				listBox1.Items.Insert(selectedIndex - 1, listBox1.Items[selectedIndex]);
				listBox1.Items.RemoveAt(selectedIndex + 1);
				listBox1.SelectedIndex = selectedIndex - 1;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			int selectedIndex = listBox1.SelectedIndex;
			if (selectedIndex < listBox1.Items.Count - 1 & selectedIndex != -1)
			{
				listBox1.Items.Insert(selectedIndex + 2, listBox1.Items[selectedIndex]);
				listBox1.Items.RemoveAt(selectedIndex);
				listBox1.SelectedIndex = selectedIndex + 1;
			}
		}

		private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "뎁라디오 파일|*.devrd|텍스트 파일|*.txt";
			save.Title = "파일을 저장할 곳을 정하세요";
			save.ShowDialog();
			StreamWriter writer = new StreamWriter(save.FileName);
			for(int i=0; i<listBox1.Items.Count; i++) {
				writer.WriteLine(listBox1.Items[i]);
			}
			writer.Close();
		}

		private void 불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string readline;

			listBox1.Items.Clear();
			
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "뎁라디오 파일|*.devrd|텍스트 파일|*.txt";
			open.Title = "파일을 불러올 곳을 정하세요";
			open.ShowDialog();

			StreamReader reader = new StreamReader(open.FileName);
			while((readline = reader.ReadLine()) != null) {
				listBox1.Items.Add(readline);
			}
			reader.Close();
		}

		private void 설정ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			npsetting.ShowDialog();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			webBrowser1.Refresh();
		}
	}
}