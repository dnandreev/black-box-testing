using System;
using System.Windows;

namespace BlackBoxTesting{
	public partial class MainWindow : Window{
		public MainWindow() => InitializeComponent();

		void CalculateEquation(object sender, RoutedEventArgs e){
			x1.Clear();
			x2.Clear();
			try{
				double k2 = double.Parse(a.Text), k1 = double.Parse(b.Text), k0 = double.Parse(c.Text), d = k1 * k1 - 4 * k2 * k0;
				if(d >= 0)
					x1.Text = ((-k1 + Math.Sqrt(d)) / (2 * k2)).ToString();
				if(d > 0)
					x2.Text = ((-k1 - Math.Sqrt(d)) / (2 * k2)).ToString();
			}
			catch(Exception exception){
				MessageBox.Show($"Ошибка! {exception.Message}", Title, MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		void IdentifyTriangle(object sender, RoutedEventArgs e){
			Type.Clear();
			try{
				double[] l = {double.Parse(AB.Text), double.Parse(BC.Text), double.Parse(CA.Text)};
				int n = l.Length, same = 0;
				bool rectangular = false;
				for(int i = 0; i < n; i++){
					int s = 0;
					for(int j = 1; j < n; j++)
						if(l[i] == l[(i + j) % n])
							s++;
					same = Math.Max(same, s);
					rectangular = l[i] * l[i] == l[(i + 1) % n] * l[(i + 1) % n] + l[(i + 2) % n] * l[(i + 2) % n];
				}
				Type.Text = same == 2 ? "Равносторонний" : same == 1 ? "Равнобедренный" : rectangular ? "Прямоугольный" : "Разносторонний";
			}
			catch(Exception exception){
				MessageBox.Show($"Ошибка! {exception.Message}", Title, MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}