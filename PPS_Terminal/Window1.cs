using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace PPS_Terminal
{
	public class Window1 : Window, IComponentConnector
	{
		private System.Windows.Controls.ListBox GroupListBox = new System.Windows.Controls.ListBox();

		private StackPanel RecipeGrid = new StackPanel();

		private StackPanel GroupGrid = new StackPanel();

		private System.Windows.Controls.ListBox SmallImageListBox = new System.Windows.Controls.ListBox();

		private Storyboard pathAnimationStoryboard = new Storyboard();

		private Grid RightInputGrid = new Grid();

		private Grid RightInputGridLeft = new Grid();

		private TextBlock Text = new TextBlock();

        private TextBlock AdvertismentTxt;

		private Grid MoveGrid = new Grid();

		private Image Img = new Image();

		private int SelectGroup;

		private int SelectPrep;

		private int selectPreparation;

		private int SelectIndex;

		private int MoveGridWidth;

		private int MoveGridHidth;

		private StackPanel BattonPanel = new StackPanel();

		private Grid Advertismen = new Grid();

		private List<PreparationGroup> list;

		private List<Preparation> prep = new List<Preparation>();

		internal Grid MainGrid;

		private bool _contentLoaded;

        private int menuLevel;

		public Window1()
		{
			this.InitializeComponent();
		}

		private void TerminalLoad(object sender, RoutedEventArgs e)
		{
            //System.Windows.Forms.Cursor.Hide();
            //Debug.WriteLine("staaart!");
			int Width = SystemInformation.PrimaryMonitorSize.Width;
			int Height = SystemInformation.PrimaryMonitorSize.Height;
			DockPanel MainDockPanel = new DockPanel();
			this.MainGrid.Children.Add(MainDockPanel);
			MainDockPanel.VerticalAlignment = VerticalAlignment.Top;
			LinearGradientBrush GreenGradientBrush = new LinearGradientBrush();
			GreenGradientBrush.GradientStops.Add(new GradientStop(Colors.Green, 0.0));
			GreenGradientBrush.GradientStops.Add(new GradientStop(Colors.White, 0.5));
			GreenGradientBrush.GradientStops.Add(new GradientStop(Colors.Green, 1.0));
			this.Advertismen.Background = GreenGradientBrush;
			DockPanel.SetDock(this.Advertismen, Dock.Top);
			MainDockPanel.LastChildFill = true;
			MainDockPanel.Children.Add(this.Advertismen);
			this.Advertismen.Width = (double)Width;
			this.Advertismen.Height = (double)(Height / 10);
			DockPanel LeftGrid = new DockPanel();
			Grid RightGrid = new Grid();
			DockPanel.SetDock(LeftGrid, Dock.Left);
			DockPanel.SetDock(RightGrid, Dock.Right);
			LeftGrid.Background = GreenGradientBrush;
			RightGrid.Background = new ImageBrush
			{
				ImageSource = new BitmapImage(new Uri("sampleImages\\главная фоновое.jpg", UriKind.Relative))
			};
			this.MoveGridWidth = Width / 10 * 7;
			this.MoveGridHidth = Height / 10 * 9;
			this.RightInputGrid.Width = (double)(Width / 10 * 7 / 2);
			this.RightInputGrid.Height = (double)(Height / 10 * 9);
			this.RightInputGrid.Children.Add(this.Text);
			this.Text.TextWrapping = TextWrapping.Wrap;
			this.Text.FontSize = 20.0;
			this.RightInputGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
			this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
			this.RightInputGridLeft.Width = (double)(Width / 10 * 7 / 2);
			this.RightInputGridLeft.Height = (double)(Height / 10 * 9);
			this.RightInputGridLeft.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
			this.MoveGrid.Children.Add(this.RightInputGridLeft);
			MainDockPanel.Children.Add(LeftGrid);
			MainDockPanel.Children.Add(RightGrid);
			LeftGrid.Height = (double)(Height / 10 * 9);
			RightGrid.Height = (double)(Height / 10 * 9);
			LeftGrid.Width = (double)(Width / 10 * 3);
			RightGrid.Width = (double)(Width / 10 * 7);
			System.Windows.Controls.ListBox GroupList = new System.Windows.Controls.ListBox();
			LeftGrid.Children.Add(this.GroupGrid);
			LeftGrid.Children.Add(this.RecipeGrid);
			DockPanel.SetDock(this.GroupGrid, Dock.Top);
			DockPanel.SetDock(this.RecipeGrid, Dock.Bottom);
			this.GroupGrid.Height = LeftGrid.Height / 2.0;
			this.RecipeGrid.Height = LeftGrid.Height / 2.0;
			this.GroupGrid.Width = LeftGrid.Width;
			this.RecipeGrid.Width = LeftGrid.Width;
			AdvertismentTxt = new TextBlock();
            setAdvertismentText("Березинский биосферный заповедник");
            menuLevel = 0;
            //AdvertismentTxt.Text = "Березинский биосферный заповедник";
            //AdvertismentTxt.VerticalAlignment = VerticalAlignment.Center;
            //AdvertismentTxt.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            //AdvertismentTxt.TextAlignment = TextAlignment.Center;
            //AdvertismentTxt.FontFamily = new FontFamily("Arial Black");
            //AdvertismentTxt.TextWrapping = TextWrapping.Wrap;

            //AdvertismentTxt.BitmapEffect = new BevelBitmapEffect();
			AdvertismentTxt.FontSize = 32.0;
			this.Advertismen.Children.Add(AdvertismentTxt);
			this.GroupGrid.Children.Add(this.GroupListBox);
			this.GroupListBox.Items.Add("О заповеднике");
			this.GroupListBox.Items.Add("Природные условия");
			this.GroupListBox.Items.Add("Деятельность заповедника");
			this.GroupListBox.Items.Add("Экологические маршруты");
			this.GroupListBox.Items.Add("Экологическое просвещение");
			this.GroupListBox.Items.Add("Туристические услуги");
			this.GroupListBox.Items.Add("Контактная информация");
			this.SmallImageListBox.Height = LeftGrid.Height / 2.0;
			this.SmallImageListBox.Width = LeftGrid.Width - 5.0;
			RightGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
			this.SmallImageListBox.VerticalAlignment = VerticalAlignment.Top;
			this.SmallImageListBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
			this.GroupListBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
			this.GroupListBox.VerticalAlignment = VerticalAlignment.Top;
			this.GroupListBox.SelectionChanged += new SelectionChangedEventHandler(this.GroupListBox_SelectionChanged);
			this.SmallImageListBox.SelectionChanged += new SelectionChangedEventHandler(this.SmallImageListBox_SelectionChanged);
			RightGrid.Children.Add(this.MoveGrid);
			this.MoveGrid.Height = RightGrid.Height;
			this.MoveGrid.Width = RightGrid.Width;
			DoubleAnimation MoveAnimation = new DoubleAnimation();
			MoveAnimation.Duration = TimeSpan.FromSeconds(5.0);
			MoveAnimation.From = new double?((double)Width);
			MoveAnimation.To = new double?(base.Width + 100.0);
			MoveAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500.0));
			TranslateTransform TransformMove = new TranslateTransform();
			MoveAnimation.By = new double?(0.2);
			this.MoveGrid.Children.Add(this.RightInputGrid);
			this.Img.Height = this.MoveGrid.Height;
			this.Img.Width = this.MoveGrid.Width;
			RotateTransform animatedRotateTransform = new RotateTransform();
			TranslateTransform animatedTranslateTransform = new TranslateTransform();
			base.RegisterName("AnimatedRotateTransform", animatedRotateTransform);
			base.RegisterName("AnimatedTranslateTransform", animatedTranslateTransform);
			TransformGroup tGroup = new TransformGroup();
			tGroup.Children.Add(animatedRotateTransform);
			tGroup.Children.Add(animatedTranslateTransform);
			this.MoveGrid.RenderTransform = tGroup;
			PathGeometry animationPath = new PathGeometry();
			PathFigure pFigure = new PathFigure();
			pFigure.StartPoint = new Point(0.0, 0.0);
			PolyBezierSegment pBezierSegment = new PolyBezierSegment();
			pBezierSegment.Points.Add(new Point(RightGrid.Width, 0.0));
			pBezierSegment.Points.Add(new Point(300.0, 0.0));
			pBezierSegment.Points.Add(new Point(RightGrid.Width, 0.0));
			pFigure.Segments.Add(pBezierSegment);
			animationPath.Figures.Add(pFigure);
			animationPath.Freeze();
			DoubleAnimationUsingPath angleAnimation = new DoubleAnimationUsingPath();
			angleAnimation.PathGeometry = animationPath;
			angleAnimation.Duration = TimeSpan.FromMilliseconds(500.0);
			angleAnimation.Source = PathAnimationSource.Angle;
			Storyboard.SetTargetName(angleAnimation, "AnimatedRotateTransform");
			Storyboard.SetTargetProperty(angleAnimation, new PropertyPath(RotateTransform.AngleProperty));
			DoubleAnimationUsingPath translateXAnimation = new DoubleAnimationUsingPath();
			translateXAnimation.PathGeometry = animationPath;
			translateXAnimation.Duration = TimeSpan.FromMilliseconds(500.0);
			translateXAnimation.Source = PathAnimationSource.X;
			Storyboard.SetTargetName(translateXAnimation, "AnimatedTranslateTransform");
			Storyboard.SetTargetProperty(translateXAnimation, new PropertyPath(TranslateTransform.XProperty));
			DoubleAnimationUsingPath translateYAnimation = new DoubleAnimationUsingPath();
			translateYAnimation.PathGeometry = animationPath;
			translateYAnimation.Duration = TimeSpan.FromMilliseconds(500.0);
			translateYAnimation.Source = PathAnimationSource.Y;
			Storyboard.SetTargetName(translateYAnimation, "AnimatedTranslateTransform");
			Storyboard.SetTargetProperty(translateYAnimation, new PropertyPath(TranslateTransform.YProperty));
			this.pathAnimationStoryboard.AutoReverse = true;
			this.pathAnimationStoryboard.Children.Add(angleAnimation);
			this.pathAnimationStoryboard.Children.Add(translateXAnimation);
			this.pathAnimationStoryboard.Children.Add(translateYAnimation);
			this.BattonPanel.Height = 150.0;
			this.BattonPanel.Width = 300.0;
			ImageBrush myBackBrush = new ImageBrush();
			myBackBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\back.png", UriKind.Relative));
			this.BattonPanel.Background = myBackBrush;
			TextBlock InfoButtonText = new TextBlock();
			InfoButtonText.Text = "    НАЗАД";
			InfoButtonText.FontFamily = new FontFamily("Arial Black");
			InfoButtonText.TextWrapping = TextWrapping.Wrap;
            //InfoButtonText.BitmapEffect = new BevelBitmapEffect();
			InfoButtonText.FontSize = 32.0;
			this.BattonPanel.MouseDown += new MouseButtonEventHandler(this.InfoCloseButton_Click);
		}

		private void InfoCloseButton_Click(object sender, RoutedEventArgs e)
		{
			this.RecipeGrid.Children.Clear();
			this.GroupGrid.Children.Clear();
			this.GroupGrid.Children.Add(this.GroupListBox);
			Timer TimerWait = new Timer();
			TimerWait.Tick += new EventHandler(this.TimerWaitProcessor);
			TimerWait.Interval = 500;
			TimerWait.Start();
			this.pathAnimationStoryboard.Begin(this);
			this.SelectIndex = 0;
            menuLevel = 0;
            setAdvertismentText("Березинский биосферный заповедник");
            this.SelectGroup = 0;

		}

		private void GroupListBox_SelectionChanged(object sender, RoutedEventArgs e)
		{
			this.RecipeGrid.Children.Add(this.BattonPanel);
			this.GroupGrid.Children.Clear();
			this.GroupGrid.Children.Add(this.SmallImageListBox);
			int i = (sender as System.Windows.Controls.ListBox).SelectedIndex;
			this.SelectGroup = i;
			this.SmallImageListBox.Items.Clear();
			if (this.SelectGroup == 0)
			{
				this.SmallImageListBox.Items.Add("История");
				this.SmallImageListBox.Items.Add("Географическое положение");
				this.SmallImageListBox.Items.Add("Цели и задачи");
				this.SmallImageListBox.Items.Add("Структура ГПУ «Березинский  биосферный заповедник»");
			}
			if (this.SelectGroup == 1)
			{
				this.SmallImageListBox.Items.Add("Леса");
				this.SmallImageListBox.Items.Add("Болота");
				this.SmallImageListBox.Items.Add("Водоемы, луга");
				this.SmallImageListBox.Items.Add("Флора и фауна");
			}
			if (this.SelectGroup == 2)
			{
				this.SmallImageListBox.Items.Add("Охрана природных комплексов");
				this.SmallImageListBox.Items.Add("Научно-исследовательская работа");
				this.SmallImageListBox.Items.Add("Международное сотрудничество");
				this.SmallImageListBox.Items.Add("Экологическое просвещение и туризм");
				this.SmallImageListBox.Items.Add("Деревообработка");

			}
			if (this.SelectGroup == 3)
			{
				this.SmallImageListBox.Items.Add("Пешеходные маршруты");
				this.SmallImageListBox.Items.Add("Водные маршруты");
				this.SmallImageListBox.Items.Add("Велосипедные маршруты");
                this.SmallImageListBox.Items.Add("Комбинированный маршрут");
				this.SmallImageListBox.Items.Add("Автомобильные маршруты");
			}
			if (this.SelectGroup == 4)
			{
				this.SmallImageListBox.Items.Add("Музей природы");
				this.SmallImageListBox.Items.Add("Экологическая тропа");
				this.SmallImageListBox.Items.Add("Дом экологического просвещения");
                this.SmallImageListBox.Items.Add("Зелёные школы");
				this.SmallImageListBox.Items.Add("Вольеры");
				this.SmallImageListBox.Items.Add("Быт и традиции");
				this.SmallImageListBox.Items.Add("Экскурсионная программа с элементами анимации");
				this.SmallImageListBox.Items.Add("Историческое наследие");
				this.SmallImageListBox.Items.Add("Березинская водная система");
			}
			if (this.SelectGroup == 5)
			{
				this.SmallImageListBox.Items.Add("ГК «Сергуч»");
				this.SmallImageListBox.Items.Add("ГК «Плавно»");
				this.SmallImageListBox.Items.Add("ГД «Нивки»");
				this.SmallImageListBox.Items.Add("Гостевые домики");
                this.SmallImageListBox.Items.Add("Верёвочный городок");
				this.SmallImageListBox.Items.Add("Дополнительные услуги");
				this.SmallImageListBox.Items.Add("Выездные экскурсии");
			}
			if (this.SelectGroup == 6)
			{
			}
			Timer TimerWait = new Timer();
			TimerWait.Tick += new EventHandler(this.TimerWaitProcessor);
			TimerWait.Interval = 500;
			TimerWait.Start();
			this.pathAnimationStoryboard.Begin(this);
			this.SelectIndex = 0;
			this.RightInputGrid.Width = (double)this.MoveGridWidth;
			this.RightInputGrid.Height = (double)(this.MoveGridHidth / 2);
			this.RightInputGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
			this.RightInputGrid.VerticalAlignment = VerticalAlignment.Top;
			this.RightInputGridLeft.Width = (double)this.MoveGridWidth;
			this.RightInputGridLeft.Height = (double)(this.MoveGridHidth / 2);
			this.RightInputGridLeft.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
			this.RightInputGridLeft.VerticalAlignment = VerticalAlignment.Bottom;
		}

		private void SmallImageListBox_SelectionChanged(object sender, RoutedEventArgs e)
		{
			int i = (sender as System.Windows.Controls.ListBox).SelectedIndex;
			this.SelectPrep = i;
			Timer TimerWait = new Timer();
			TimerWait.Tick += new EventHandler(this.TimerWaitProcessor);
			TimerWait.Interval = 500;
			TimerWait.Start();
			this.pathAnimationStoryboard.Begin(this);
			this.SelectIndex = 1;
		}
        private void setAdvertismentText(string text)
        {
           // TextBlock AdvertismentTxt = new TextBlock();
            AdvertismentTxt.Text = text;
            AdvertismentTxt.VerticalAlignment = VerticalAlignment.Center;
            AdvertismentTxt.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            AdvertismentTxt.TextAlignment = TextAlignment.Center;
            AdvertismentTxt.FontFamily = new FontFamily("Arial Black");
            AdvertismentTxt.TextWrapping = TextWrapping.Wrap;
        }
        private void setTextFromFile (string origin)
        {
            char[] charsToTrim = { '#', '%', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string filename = origin;
            StreamReader r = new StreamReader(filename, System.Text.Encoding.GetEncoding(1251));
            string textInfo = r.ReadLine();
            string fontName = textInfo.Trim(charsToTrim);// (textInfo.IndexOf("%"),textInfo.IndexOf("#"));
            string fontSize = textInfo.Remove(0, textInfo.IndexOf("%") + 1);
            fontSize = fontSize.Remove(fontSize.IndexOf("#"));
            this.Text.FontSize = Convert.ToInt32(fontSize);
            this.Text.FontFamily = new FontFamily(fontName);
            this.Text.Text = r.ReadToEnd();
        }
		private void TimerWaitProcessor(object myObject, EventArgs myEventArgs)
		{
			(myObject as Timer).Stop();
			int x = this.SelectGroup;
            this.Text.Text = "";

            Debug.WriteLine("current menu level is");
			if (this.SelectIndex == 0)
			{
				ImageBrush myBrush = new ImageBrush();
				if (x == 0)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\фоновое.jpg", UriKind.Relative));
                    this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    menuLevel = 1;
                    setAdvertismentText("Березинский биосферный заповедник");

                }
				if (x == 1)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    setAdvertismentText("Природные условия");
                    menuLevel = 1;
				}
				if (x == 2)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    setAdvertismentText("Деятельность заповедника");
                    menuLevel = 1;
				}
				if (x == 3)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    setAdvertismentText("Экологические маршруты");
                    menuLevel = 1;
				}
				if (x == 4)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    setAdvertismentText("Экологическое просвещение");
                    menuLevel = 1;
				}
				if (x == 5)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\фоновое.jpg", UriKind.Relative));
					
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    setAdvertismentText("Туристические услуги");
                    menuLevel = 1;
				}
				if (x == 6)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\07 Контактная информация\\фоновое.jpg", UriKind.Relative));
                    this.Text.Text = "";
                    setTextFromFile("sampleImages\\07 Контактная информация\\контакты.txt");
                    //this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
                    //this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
                    setAdvertismentText("Контактная информация");
                    menuLevel = 1;
                    this.RightInputGrid.Width = (double)(this.MoveGridWidth / 2);
                    this.RightInputGrid.Height = (double)this.MoveGridHidth;
                    this.RightInputGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    this.RightInputGrid.VerticalAlignment = VerticalAlignment.Top;
                    this.RightInputGridLeft.Width = (double)(this.MoveGridWidth / 2);
                    this.RightInputGridLeft.Height = (double)this.MoveGridHidth;
                    this.RightInputGridLeft.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    this.RightInputGridLeft.VerticalAlignment = VerticalAlignment.Bottom;
				}
				this.MoveGrid.Background = myBrush;
			}
			else
			{
				int y = this.SelectPrep;
				ImageBrush myBrush = new ImageBrush();
                menuLevel = 1;
				if (x == 0)
				{
                    setAdvertismentText("Березинский биосферный заповедник");   
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\история.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\01 Березинский биосферный заповедник\\История.txt");
             			this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
                        
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\географ_положение.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\01 Березинский биосферный заповедник\\Географическое положение.txt");
                        this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\цели и задачи.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\01 Березинский биосферный заповедник\\Цели и задачи.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\структура.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\01 Березинский биосферный заповедник\\Структура ГПУ Березенский.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 1)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\Леса.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\02 Природные условия\\Леса.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\болота.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\02 Природные условия\\Болота.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\водоемы.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\02 Природные условия\\Водоёмы.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\флора и фауна.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\02 Природные условия\\Флора и фауна.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 2)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\охрана.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\03 Деятельность заповедника\\Охрана природных комплексов.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\научная работа.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\03 Деятельность заповедника\\Научно-исследовательская работа.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\международное.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\03 Деятельность заповедника\\Международное сотрудничество.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\экопросвещение и туризм.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\03 Деятельность заповедника\\Экологическое просвещение и туризм.txt");
                        this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 4)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\деревообработка.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\03 Деятельность заповедника\\Деревообработка.txt");
                        this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 3)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\пешеходные.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\04 Экологические маршруты\\Пешеходные.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\водные.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\04 Экологические маршруты\\Водные.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\веломаршрут.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\04 Экологические маршруты\\Велосипедные.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
                    if (y == 3)
                    {
                        myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\Комбинированный.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\04 Экологические маршруты\\Комбинированный.txt");
                        this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
                    }
					if (y == 4)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\автомобильные.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\04 Экологические маршруты\\Автомобильные.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}

				}
				if (x == 4)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\музей.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\05 Экологическое просвещение\\Музей.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\экотропа.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\05 Экологическое просвещение\\Экотропа.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\ДЭП.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\05 Экологическое просвещение\\ДЭП.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
                    if (y == 3)
                    {
                        myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\зелёные школы.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\05 Экологическое просвещение\\Зелёные школы.txt");
                        this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
                    }
					if (y == 4)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\вольеры.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\05 Экологическое просвещение\\Вольеры.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 5)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\быт.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\05 Экологическое просвещение\\Быт и традиции.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 6)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\анимация.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\05 Экологическое просвещение\\Экскурсия с анимацией.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 7)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\историческое.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\05 Экологическое просвещение\\Историческое наследие.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 8)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\водная система.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\05 Экологическое просвещение\\Березинская водная система.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 5)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\сергуч.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\06 Туристические услуги\\Сергуч.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\плавно.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\06 Туристические услуги\\Плавно.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\нивки.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\06 Туристические услуги\\Нивки.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\домики.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\06 Туристические услуги\\Гостевые домики.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
                    if (y ==4)
                    {
                        myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\верёвочный городок.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\06 Туристические услуги\\Верёвочный городок.txt");
                        this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
                    }
					if (y == 5)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\допуслуги.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\06 Туристические услуги\\Дополнительные услуги.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 6)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\выездные экскурсии.jpg", UriKind.Relative));
                        setTextFromFile("sampleImages\\06 Туристические услуги\\Выездные экскурсии.txt");
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));

					}
				}
				if (x == 6)
				{
                    myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\07 Контактная информация\\фоновое.jpg", UriKind.Relative));
                    setTextFromFile("sampleImages\\07 Контактная информация\\контакты.txt");
                   // this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));

				}
				this.RightInputGridLeft.Background = myBrush;
                if ((x == 0 & y == 0) | (x == 0 & y == 1) | (x == 0 & y == 3) | (x == 1 & y == 2) | (x == 3 & y == 2))
				{
					this.RightInputGrid.Width = (double)this.MoveGridWidth;
					this.RightInputGrid.Height = (double)(this.MoveGridHidth / 3);
					this.RightInputGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
					this.RightInputGrid.VerticalAlignment = VerticalAlignment.Top;
					this.RightInputGridLeft.Width = (double)this.MoveGridWidth;
					this.RightInputGridLeft.Height = (double)(this.MoveGridHidth / 3 * 2);
					this.RightInputGridLeft.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
					this.RightInputGridLeft.VerticalAlignment = VerticalAlignment.Bottom;
				}
				else
				{
					this.RightInputGrid.Width = (double)(this.MoveGridWidth / 2);
					this.RightInputGrid.Height = (double)this.MoveGridHidth;
					this.RightInputGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
					this.RightInputGrid.VerticalAlignment = VerticalAlignment.Top;
					this.RightInputGridLeft.Width = (double)(this.MoveGridWidth / 2);
					this.RightInputGridLeft.Height = (double)this.MoveGridHidth;
					this.RightInputGridLeft.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
					this.RightInputGridLeft.VerticalAlignment = VerticalAlignment.Bottom;
				}
			}
		}

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Uri resourceLocater = new Uri("/PPS_Terminal;component/window1.xaml", UriKind.Relative);
                System.Windows.Application.LoadComponent(this, resourceLocater);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        void IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    ((Window1)target).Loaded += new RoutedEventHandler(this.TerminalLoad);
                    break;
                case 2:
                    this.MainGrid = (Grid)target;
                    break;
                default:
                    this._contentLoaded = true;
                    break;
            }
        }
	}
}
