using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Curso
{
	public class Evento : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged ([CallerMemberName]string prop = null)
		{
		}

		#endregion

		private string _nome;

		public string Nome {
			get { 
				return _nome;
			}
			set { 
				_nome = value;
				OnPropertyChanged ();
			}
		}

		private DateTime _dataEvento;

		public DateTime DataEvento {
			get { 
				return _dataEvento;
			} 
			set { 
				_dataEvento = value;
				OnPropertyChanged ();	
			}
		}

		public TimeSpan HoraEvento {
			get;
			set;
		}

		public string Organizador {
			get;
			set;
		}

		public string Tipo {
			get;
			set;
		}
	}

	public class App : Application
	{
		public static List<Evento> Eventos {
			get;
			set;
		}

		public App ()
		{
//			// The root page of your application
//			MainPage = new ContentPage {
//				Content = new StackLayout {
//					VerticalOptions = LayoutOptions.Center,
//					Children = {
//						new Label {
//							XAlign = TextAlignment.Center,
//							Text = "Welcome to Xamarin Forms!"
//						}
//					}
//				}
////			};
//
//			var ContentHome = new ContentPage {
//
//			};
//
//			var LabelWelcome = new Label {
//				XAlign = TextAlignment.Center,
//				Text = "Welcome to Xamarin Forms!"
//			};
//
//			var ButtonHello = new Button (){ 
//				Text = "Hello"
//			};
//			var ButtonHello2 = new Button (){ 
//				Text = "Hello"
//			};
//			var ButtonHello3 = new Button (){ 
//				Text = "Hello"
//			};	var ButtonHello7 = new Button (){ 
//				Text = "Hello"
//			};
//			var ButtonHello4 = new Button (){ 
//				Text = "Hello"
//			};
//			var ButtonHello5 = new Button (){ 
//				Text = "Hello"
//			};
//			var ButtonHello6 = new Button (){ 
//				Text = "Hello"
//			};
//
//			var StackHome = new StackLayout {
//				VerticalOptions = LayoutOptions.Center,
//			};
//
//			var StackHorizontal = new StackLayout {
//				VerticalOptions = LayoutOptions.Center,
//				Orientation = StackOrientation.Horizontal
//			};
//
//			StackHome.Children.Add (LabelWelcome);
//			StackHome.Children.Add (ButtonHello);
//			StackHome.Children.Add (ButtonHello2);
//			StackHome.Children.Add (ButtonHello3);
//			StackHome.Children.Add (ButtonHello4);
//			StackHome.Children.Add (ButtonHello5);
//
//			StackHorizontal.Children.Add (ButtonHello6);
//			StackHorizontal.Children.Add (ButtonHello7);
//			StackHome.Children.Add (StackHorizontal);
//
//			ContentHome.Content = StackHome;
			Eventos = new List<Evento> ();

			Eventos.Add (new Evento () { 
				Nome = "teste 1",
				DataEvento = DateTime.Now

			});
			// The root page of your application
			MainPage = new NavigationPage (new ListaEventos ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

