using System;
using System.Windows.Media.Imaging;

namespace PPS_Terminal
{
	public class Preparation
	{
		public int Number;

		public int ID;

		public string Name;

		public BitmapImage BitImage;

		public string Desription;

		public Preparation()
		{
			this.Name = "";
			this.ID = -1;
			this.Number = -1;
			this.Desription = "Нет описания";
		}

		public Preparation(int id, int number, string name, BitmapImage bitImage, string desription)
		{
			this.Name = name;
			this.ID = id;
			this.Number = number;
			this.Desription = desription;
		}
	}
}
