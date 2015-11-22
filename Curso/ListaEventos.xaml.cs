using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Curso
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class ListaEventos : ContentPage
	{
		public ListaEventos ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			Device.BeginInvokeOnMainThread (() => {
				lstEventos.ItemsSource = null;
				lstEventos.ItemsSource = App.Eventos;

			});

//			ListView
		}

		void cadastrar_Clicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new Inicial ());
		}

		async void lst_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) {

				var res = await DisplayAlert ("O que deseja fazer?", "", "Alterar", "Excluir");

				if (res) {
					Navigation.PushAsync (new Inicial (e.SelectedItem as Evento, (lstEventos.ItemsSource as List<Evento>).IndexOf(e.SelectedItem as Evento)));
				} else {

					App.Eventos.Remove (e.SelectedItem as Evento);


					lstEventos.ItemsSource = null;
					lstEventos.ItemsSource = App.Eventos;

					lstEventos.SelectedItem = null;
				}
			}

		}
	}
}

