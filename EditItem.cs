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
	public partial class EditItem : Form
	{
		public EditItem(string[] str)
		{
			InitializeComponent();
			textBox1.Text = str[0].Remove(str[0].Length-1);
			textBox2.Text = str[1].Remove(0,1);
		}

		private void OK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
