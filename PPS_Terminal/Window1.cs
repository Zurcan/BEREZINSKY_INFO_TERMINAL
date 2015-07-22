using System;
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

		public Window1()
		{
			this.InitializeComponent();
		}

		private void TerminalLoad(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.Cursor.Hide();
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
			TextBlock AdvertismentTxt = new TextBlock();
			AdvertismentTxt.Text = "Березинский биосферный заповедник";
			AdvertismentTxt.VerticalAlignment = VerticalAlignment.Center;
			AdvertismentTxt.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
			AdvertismentTxt.TextAlignment = TextAlignment.Center;
			AdvertismentTxt.FontFamily = new FontFamily("Arial Black");
			AdvertismentTxt.TextWrapping = TextWrapping.Wrap;
			AdvertismentTxt.BitmapEffect = new BevelBitmapEffect();
			AdvertismentTxt.FontSize = 32.0;
			this.Advertismen.Children.Add(AdvertismentTxt);
			this.GroupGrid.Children.Add(this.GroupListBox);
			this.GroupListBox.Items.Add("Березинский биосферный заповедник");
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
			InfoButtonText.BitmapEffect = new BevelBitmapEffect();
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
				this.SmallImageListBox.Items.Add("история");
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
				this.SmallImageListBox.Items.Add("Автомобильные маршруты");
			}
			if (this.SelectGroup == 4)
			{
				this.SmallImageListBox.Items.Add("Музей природы");
				this.SmallImageListBox.Items.Add("Экологическая тропа");
				this.SmallImageListBox.Items.Add("Дом экологического просвещения");
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

		private void TimerWaitProcessor(object myObject, EventArgs myEventArgs)
		{
			(myObject as Timer).Stop();
			int x = this.SelectGroup;
			if (this.SelectIndex == 0)
			{
				ImageBrush myBrush = new ImageBrush();
				if (x == 0)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
				}
				if (x == 1)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
				}
				if (x == 2)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
				}
				if (x == 3)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
				}
				if (x == 4)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
				}
				if (x == 5)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
				}
				if (x == 6)
				{
					myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\07 Контактная информация\\фоновое.jpg", UriKind.Relative));
					this.Text.Text = "Республика Беларусь, 211188, Витебская обл., Лепельский р-н, п/о Домжерицы, ул. Центральная, 3Internet:www.berezinsky.come-mail: tourism@berezinsky.com \n Директор ОНИКЕЕНКО Виктор Петрович\tт.(приёмная): +375 2132 26344  \n ф.(приёмная): +375 2132 26342   \n Зам. директора по общим вопросам МОСКАЛЁВ Виктор Алексеевич тел.: +375 2132 26302 \n Зам. директора по научно-исследовательской работе ИВКОВИЧ Валерий Семёнович\tтел., факс: +375 2132 26343 \n Зам. директора по туризму ЖИГИМОНТ Виталий Михайлович  тел.: +375 2132 26406 \n Начальник эколого-туристического отдела СИМОНОВИЧ Диана Михайловна \n тел.: +375 2132 26318 \n Начальник ГК СЕРГУЧ КВЕТИНСКАЯ Надежда Иосифовна\tтел.: +375 2132 26392 \n Администратор ГК СЕРГУЧ                                                  тел.: +375 2132 26300 \n Начальник ГК ПЛАВНО ХОДУН Клавдия Евгеньевна\tтел.: +375 2132 26382 \n Администратор ГК ПЛАВНО                                                тел.: +375 2132 44542 \n Администратор ГД НИВКИ                                                  тел.: +375 2132 26319 \n Главный бухгалтер КАЗУНКО Елена Денисовна\t             тел.: +375 2132 26355";
					this.RightInputGridLeft.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
				}
				this.MoveGrid.Background = myBrush;
			}
			else
			{
				int y = this.SelectPrep;
				ImageBrush myBrush = new ImageBrush();
				if (x == 0)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\история.jpg", UriKind.Relative));
						this.Text.Text = "    Образован 30 января 1925 года как Государственный охотничий заповедник в Борисовском округе.  С 1959 года функционировал как  Березинский государственный заповедник. В 1979 году заповеднику присвоен статус «биосферный». С 1995 года является обладателем Европейского Диплома для охраняемых территорий, является ключевой орнитологической и ключевой ботанической территорией. С 2001 года – государственное природоохранное учреждение «Березинский биосферный заповедник».";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\географ_положение.jpg", UriKind.Relative));
						this.Text.Text = "Заповедник расположен на севере республики в Белорусском Поозерье, на территории трех административных районов Лепельского, Докшицкого Витебской области и Борисовского района Минской области. Административно-хозяйственный центр находится в п. Домжерицы Лепельского района Витебской области.Площадь заповедника - 85,2 тыс. га. Помимо заповедной территории в состав ГПУ «Березинский биосферный заповедник» входят  экспериментальное лесоохотничье хозяйство «Барсуки» - 29,3 тыс. га и охотничье хозяйство «Березина» на арендуемых землях - 16,0 тыс. га. ";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\цели и задачи.jpg", UriKind.Relative));
						this.Text.Text = "1. Обеспечивает условия сохранения в естественном состоянии природных комплексов и объектов, находящихся на территории заповедника;                             2. Организует выполнение природоохранных мероприятий в заповеднике и обеспечивает соблюдение установленного режима его охраны и использования;3. Проводит научно-исследовательские работы;4. Обеспечивает мониторинг окружающей среды;5. Оказывает помощь в подготовке научных кадров и специалистов в области   охраны окружающей среды; 6. Проводит активную работу по экологическому просвещению и пропаганде дела охраны окружающей среды.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\01 Березинский биосферный заповедник\\структура.jpg", UriKind.Relative));
						this.Text.Text = "- центральный аппарат управления;- 7 лесничеств заповедника;- ЭЛОХ «Барсуки», в состав которого входит 2 лесничества и 2 деревообрабатывающих цеха (ДОЦ)  «Барсуки» и «Березино»;- ДОЦ «Домжерицы», - охотхозяйство «Березина»;- автотракторный парк;- гостиничные комплексы  «Плавно» и «Сергуч»;- дом экологического просвещения;- база отдыха «Нивки»Списочная численность работников 417 человека, в т.ч.  штат лесной охраны 176 человек. ";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 1)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\Леса.jpg", UriKind.Relative));
						this.Text.Text = "Леса  покрывают 89,1 % всей площади заповедника.Более половины всех лесов (56,2 %) занимают бореальные хвойные леса (сосновые и еловые).Широколиственные леса встречаются в южной части заповедника и представлены дубравами и ясенниками. Общая их площадь невелика (0,9 %).Особую ценность представляют лиственные болотные леса из черной ольхи и пушистой березы (33,4 %).";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\болота.jpg", UriKind.Relative));
						this.Text.Text = "Болота  занимают 60% территории заповедника. Преобладающим типом болот в заповеднике являются низинные болота (54,4% от всей площади болот).Несколько меньшую площадь (35,3%) занимают переходные болота, которые характеризуются средней обводненностью.Верховые болота   занимают 10,3% площади всех болот Березинского заповедника.Ценность болот обусловлена исключительным богатством и разнообразием гидрологических условий и болотных растительных сообществ.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\водоемы.jpg", UriKind.Relative));
						this.Text.Text = "Главная водная артерия – р. Березина разделяет заповедник на две части: обширную левобережную и узкую правобережную. Гидрографическую сеть заповедника дополняют семь озер с общей площадью 1748 га. Крупнейшие из них – Палик, Плавно, Ольшица, Манец, Домжерицкое. Луга в Березинском заповеднике занимают десятую часть территории. По особенностям природных условий и соотношению растительных сообществ на территории заповедника можно выделить три луговых района: поймы рек Березина, Сергуч и внепойменные травяные болота.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\02 Природные условия\\флора и фауна.jpg", UriKind.Relative));
						this.Text.Text = "В заповеднике зарегистрировано более двух тысяч видов растений, из них сосудистых – 814, мохообразных – 216, грибов – 463, водорослей – 317, лишайников – 254.  45 видов сосудистых, 10 – мохообразных, 14 – лишайников внесены в Красную книгу Республики Беларусь.- Видовой состав фауны позвоночных насчитывает 337 видов, из них 56 – млекопитающие, 230 – птицы, 6 – пресмыкающиеся, 11 – земноводные, 34 – рыбы. 9 видов млекопитающих внесены в Красную книгу Беларуси (бурый медведь, рысь, барсук, зубр и др.).";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 2)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\охрана.jpg", UriKind.Relative));
						this.Text.Text = "Охрана природных комплексов является важнейшим видом деятельности заповедника и включает: -     охрану территории и ее  биоразнообразия; -\t уход за минеральными полосами;-\t ремонт дорог; -\t устройство аншлагов;-\t оборудование мест отдыха;-\t  уборку захламленности лесонасаждений; -\t выявление нарушений заповедного режима. В каждом лесничестве созданы мобильные инспекторские группы, занимающиеся контрольными функциями и усиливающие охрану на наиболее уязвимых участках заповедника.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\научная работа.jpg", UriKind.Relative));
						this.Text.Text = "Научно-исследовательская деятельность заповедника заключается в проведении стационарных круглогодичных исследований, изучении природных комплексов и динамики природных процессов для оценки и прогноза состояния экосистем, объектов животного и растительного мира, разработки научных основ охраны природы и сохранения биологического разнообразия.Научная работа ведется в двух направлениях:-\t мониторинг процессов и явлений в природных комплексах заповедника (Летопись природы);-\t исследования структуры и динамики естественных лесных, болотных, луговых, озерных и речных комплексов, а также исследования редких и исчезающих видов растений и животных.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\международное.jpg", UriKind.Relative));
						this.Text.Text = "Являясь частью международной сети биосферных резерватов ЮНЕСКО,  заповедник развивает активное международное сотрудничество с биосферными заповедниками других стран. Наиболее  тесные связи налажены с биосферным заповедником «Северные Вогезы» (Франция), «Кампиноским» (Польша), «Смоленское Поозерье» и «Угра» (Россия).";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\экопросвещение и туризм.jpg", UriKind.Relative));
						this.Text.Text = "Основными направлениями являются: - рекреационный, - экологический- охотничий туризм. Для отдыха туристов в заповеднике предлагается два гостиничных комплекса «Сергуч» и «Плавно», туристическая база «Нивки»,  рестораны, кафе-бары, уютные гостевые домики. Разработаны пешеходные, автомобильные и велосипедные маршруты для ознакомления туристов с различными достопримечательностями заповедника. Ключевыми объектами организации экологического просвещения являются: -\tДом экологического просвещения;-\t музей природы;-\t экологические тропы;-\t вольеры с дикими животными.Заповедник предлагает экскурсии для посетителей различных возрастных групп, организует молодежные эколагеря, практики студентов биологического профиля и тд.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 4)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\03 Деятельность заповедника\\деревообработка.jpg", UriKind.Relative));
						this.Text.Text = "Основой хозяйственной деятельности ГПУ «Березинский биосферный заповедник» является заготовка и переработка древесины, получаемой от различного рода рубок на территории ЭЛОХ «Барсуки», в составе которого 2 лесничества.Реализация производимой продукции составляет значительную часть внебюджетного финансирования, часть из которого используется на природоохранные мероприятия заповедника. ";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 3)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\пешеходные.jpg", UriKind.Relative));
                        this.Text.Text = "НаибольшейНаибольшейНаибольшей популярностью пользуются пешеходные экологические маршруты «Каменная плита» и «Звериными топами». Они проходят недалеко от центральной усадьбы заповедника – п. Домжерицы, и в то же время дают уникальную возможность прикоснуться к тайнам заповедной природы. В любую пору года здесь найдется много интересного для любознательного человека. Всего за пару часов перед вами, сменяя друг друга, раскроют свои тайны сумрачный еловый лес и сыроватый осинник,  обилием света порадуют сосновый лес  и светлый березняк на краю болота с зарослями орешника, где не редка  встреча с дикими животными.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\водные.jpg", UriKind.Relative));
                        this.Text.Text = "Водные маршруты дают возможность проплыть по части Березинской водной системы, включающей озера Плавно, Манец, реку Бузянку и часть Сергучского канала. Множество поселений бобра, пышная прибрежная растительность,  встречи с водоплавающими и околоводными птицами оставляют неизгладимое впечатление от посещения заповедных рек и озер.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\веломаршрут.jpg", UriKind.Relative));
						this.Text.Text = "Для любителей велосипедных прогулок  предлагается веломаршрут вдоль Сергучского канала, являющегося частью Березинской водной системы. На четырех тематических остановках вдоль маршрута можно познакомиться с историческим прошлым водной системы, узнать особенности ее нынешнего использования, посетить бывший центр заповедника – деревню Крайцы и урочище Куты с характерным для границы последнего оледенения чередованием холмов и понижений.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\04 Экологические маршруты\\автомобильные.jpg", UriKind.Relative));
						this.Text.Text = "На автомобильных маршрутах участники экскурсий могут увидеть наиболее уникальные нетронутые человеком лесные и болотные массивы, воочию убедиться в красоте и неповторимости девственных участков высоковозрастных смешанных лесов и загадочных черноольшаников. Для ученых и натуралистов интересным окажется знакомство с  научными стационарами, встреча с необычной воротничковой сосной, дубом­великаном на окраине самого большого в заповеднике Домжерицкого болота. Знакомясь с историческим прошлым во время автомобильных экскурсий можно посетить памятники погибшим партизанам, место переправы наполеоновских войск через р. Березину у деревни Студенка.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 4)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\музей.jpg", UriKind.Relative));
						this.Text.Text = "В экспозиции музея представлены различные виды животных и птиц, которые обитают в  Березинском заповеднике.На первом этаже  можно увидеть крупных млекопитающих и хищников: благородного оленя, лося, беловежского зубра, рысь, медведя, волка, дикого кабана,  барсука, енотовидную собаку, а также строителя плотин бобра.Особой гордостью музея являются пернатые, в зале их представлено более 100 видов. Это птицы наших лесов и болот: многочисленные отряды воробьиных, дятлообразных, курообразных и их семейства, а также хищные птицы: змееяд, беркут, большой и малый подорлик, различные виды водоплавающих: лебедь - шипун, чернозобая гагара, белая цапля и другие.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\экотропа.jpg", UriKind.Relative));
						this.Text.Text = "Экологическая тропа проходит через ельник кисличный, осинник и смешанный лес. Белки,  лесные сони, лоси, благородный олень и кабаны оставляют  здесь свои следы. Лесная опушка – излюбленное место гнездования многих птиц: овсянок, лесных коньков, зябликов. Тут можно встретить и наиболее опасного дневного хищника -   ястреба-перепелятника, а между камней на земле - прыткую ящерицу, ужа или гадюку. Пушистый ковер сфагновых мхов, цветущая пушица, насекомоядное растение росянка, клюква, голубика оживляют  болото в разное время года. Редкие птицы, растения и животные, занесенные в Красную книгу Беларуси, являются достоянием заповедника.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\ДЭП.jpg", UriKind.Relative));
						this.Text.Text = "Дом экологического просвещения является первым в Республике Беларусь эколого-просветительским объектом на особо охраняемой территории. Он предназначен для проведения образовательной и просветительской работы в области окружающей среды.Это образовательный пункт для всех детей Беларуси в рамках развития совместного проекта Европейского союза и Программы развития ООН «Повышение экологической информированности молодежи через учреждение и развитие «зеленых школ».Для проведения заседаний, семинаров, конференций и занятий с детьми в здании Дома экологического просвещения оборудованы следующие помещения: актовый зал на 200 мест, пресс-центр на 40 мест, видеосалон на 16 мест, библиотека, кафе-бар и  «зеленые классы».";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\вольеры.jpg", UriKind.Relative));
						this.Text.Text = "После реконструкции, проведённой в 2010-2011 гг.,  вольеры   пополнились  новыми представителями нашей природы и стали занимать территорию общей площадью 10 га.Старожилами лесного зоопарка являются медведица Машка, благородный олень Яшка и беловежский зубр Борька.Семейная пара волков чувствуют себя настоящими серыми разбойниками. Дикие кабаны то роются в лесной подстилке, то устраивают свои зрелищные забеги.На площади в 2 га разместились более мелкие звери: барсук, енотовидная собака,  лиса, куница,  а также другие птицы и  животные, знакомство с которыми доставит вам радость и наслаждение.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 4)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\быт.jpg", UriKind.Relative));
						this.Text.Text = "В заповеднике живет и работает немало талантливых людей. Это самобытный художник Анатолий Викторович Бухаркин,  создающий на полотне неповторимые пейзажи, картины которого известны не только на Лепельщине, но и за  рубежом. Красоту заповедного края прославляют в своём творчестве народный хор «Березиночка» и фольклорная группа. Пройдясь по улицам деревень, вы невольно соприкоснётесь с живущими здесь  людьми: резчиками по дереву, мастерами по ткачеству, а также сможете приобрести сувениры ручной работы. Из поколения в поколение бережно передаются и сохраняются местные традиции и обряды.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 5)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\анимация.jpg", UriKind.Relative));
						this.Text.Text = "Экскурсионный тур с элементами анимации «Тайны заповедного болота» познакомит вас с загадочным Болотником. Это сказочный персонаж, который проведет с вами веселые экологические игры, конкурсы, викторины, подарит на память приятные призы. ";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 6)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\историческое.jpg", UriKind.Relative));
						this.Text.Text = "На территории заповедника сохранились древние захоронения славян. Народная молва связывает курганы с французским наследием. У  д. Студенки Борисовского района произошла битва, ставшая кульминационным моментом в разгроме армии покорителя Европы.  В честь победы русских  на правом берегу Березины поставлен памятник павшим героям войны 1812 года. В годы Великой Отечественной войны против фашизма сражались десятки партизанских бригад и соединений. Поклониться и возложить цветы можно у памятников и трех братских могилах, в которых захоронено 332 человека. ";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 7)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\05 Экологическое просвещение\\водная система.jpg", UriKind.Relative));
						this.Text.Text = "Главной исторической достопримечательностью заповедника является Березинская водная система, построенная в 1797-1805 гг. на месте древнего пути «из варяг в греки». Она соединяет бассейны Балтийского и Черного морей. Частью этого водного пути, проходящего по территории заповедника, является Сергучский канал протяженностью 8,5 км. Березинская водная система существенно разрешила экономические проблемы края, расширила торговые связи с соседними государствами. Предметами торговли стали корабельный лес, древесный уголь, смола, пушнина, лен и многое другое. В настоящее время водная трасса утратила своё транспортное значение. Сегодня это владение бобров, уток и тысяч других представителей флоры и фауны заповедника.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 5)
				{
					if (y == 0)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\сергуч.jpg", UriKind.Relative));
						this.Text.Text = "Гостиничный комплекс «Сергуч» расположен на центральной усадьбе заповедника в п. Домжерицы, в 3 км от автомагистрали Минск-Витебск (121км. от г. Минска). Четырехэтажная  гостиница удачно вписывается в лесной ландшафт, содержит 35 комфортабельных номеров (60 мест), которые оборудованы  телевизорами и холодильниками. На первом этаже гостиницы расположены бильярдная комната, а также ресторан на 70 посадочных мест, банкетный зал и бар на 24 посадочных места. В меню ресторана большой ассортимент блюд национальной белорусской кухни. ";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 1)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\плавно.jpg", UriKind.Relative));
						this.Text.Text = "Гостиничный комплекс «Плавно» - исторически памятное место, связанное с именем Первого секретаря ЦК Компартии Беларуси П.М. Машерова. Комплекс расположен в 15 км от административного центра заповедника на берегу лесного озера Плавно – водоразделе Черного и Балтийского морей. Трехэтажная гостиница с 10-ю уютными номерами напоминает сказочный замок.  На первом этаже - ресторан на 40 посадочных мест с камином, русский бильярд, бар. На 2–м и 3-м этажах – номера. На территории комплекса находится вертолетная площадка. В сосновом бору на берегу озера Плавно расположен «Дом рыбака и охотника» - двухэтажный деревянный домик с 3-мя двухместными номерами на 6 человек.  В нем имеются каминный зал, кухня, площадка для пикников, лодочный причал, спортивная площадка, пляжная зона. Территория круглосуточно охраняется.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 2)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\нивки.jpg", UriKind.Relative));
						this.Text.Text = "Гостевые домики «Нивки» компактно расположились на лесной поляне вблизи озера Манец в 300 метрах от автомагистрали Минск - Витебск. К услугам отдыхающих шесть комфортабельных домиков (3 четырехместных, 2 пятиместных, 1 шестиместный), благоустроенная площадка со сказочными персонажами, качели, баня, оборудованные беседки и места для пикников. ";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 3)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\домики.jpg", UriKind.Relative));
						this.Text.Text = " ГД «Ольшица» находится в 17 км от центральной усадьбы заповедника на берегу  озера. Двухэтажный изолированный домик с двумя спальнями, в которых размещаются 4 и 2 человека. Имеется кухня с электроплитой, печка, место для пикника, лодочный причал. ГД на оз. Домжерицкое находится в сосновом лесу на берегу озера, в 10 км от центральной усадьбы заповедника, и рассчитан на приём  туристов до 6 человек. «Дом рыбака» расположен в Борисовском районе вблизи озера Палик. В домике 2 спальни на 4 человека каждая, холл, оборудованная кухня для самостоятельного приготовления пищи, туалет на улице.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 4)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\допуслуги.jpg", UriKind.Relative));
						this.Text.Text = "Баня           Бильярд       Прокат велосипедов, лодок, катамаранов, спортивного инвентаря";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
					if (y == 5)
					{
						myBrush.ImageSource = new BitmapImage(new Uri("sampleImages\\06 Туристические услуги\\выездные экскурсии.jpg", UriKind.Relative));
						this.Text.Text = "Туристическим отделом заповедника проводятся выездные экскурсии с посещением  белорусских городов, где вас познакомят с историко-культурным наследием страны. Во время автомобильной экскурсии в город-патриарх Полоцк  вы сможете узнать о его прошлом и настоящем, поклониться мощам Преподобной Евфросинии в Спасо-Евфросиниевской  церкви, услышать звуки органа в Свято-Софийском соборе (памятника 11в. ) и посетить другие исторические  места.";
						this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
					}
				}
				if (x == 6)
				{
					this.Text.Text = "Республика Беларусь, 211188, Витебская обл., Лепельский р-н, п/о Домжерицы, ул. Центральная, 3Internet:www.berezinsky.come-mail: tourism@berezinsky.com";
					this.RightInputGrid.Background = new SolidColorBrush(Color.FromArgb(170, 255, 255, 255));
				}
				this.RightInputGridLeft.Background = myBrush;
				if ((x == 0 & y == 0) | (x == 0 & y == 1) | (x == 0 & y == 3) | (x == 1 & y == 2) | (x == 3 & y == 2) | x == 6)
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
