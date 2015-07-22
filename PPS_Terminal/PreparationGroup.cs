using System;
using System.Windows.Media.Imaging;

namespace PPS_Terminal
{
	public class PreparationGroup
	{
		public int Number;

		public int ID;

		public string Name;

		public BitmapImage BitImage;

		public PreparationGroup()
		{
			this.Name = "";
			this.ID = -1;
			this.Number = -1;
		}

		public PreparationGroup(int id, int number, string name, BitmapImage bitImage)
		{
			this.Name = name;
			this.ID = id;
			this.Number = number;
		}
	}
}
