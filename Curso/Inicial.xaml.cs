using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Curso
{
	public partial class Inicial : ContentPage
	{
		public Evento Atual {
			get;
			set;
		}

		public int EventoS {
			get;
			set;
		}

		public Inicial (Evento e = null, int eventoS = 0)
		{
			InitializeComponent ();



			pckrTipos.Items.Add ("--Selecione--");
			pckrTipos.Items.Add ("Festa");
			pckrTipos.Items.Add ("Happy Hour");
			pckrTipos.Items.Add ("Show");
			pckrTipos.Items.Add ("Feira");
			pckrTipos.Items.Add ("Curso");
			pckrTipos.Items.Add ("MeetUp");

			if (e != null) {
				entNome.Text = e.Nome;
				tpEvento.Time = e.HoraEvento;
				dpEvento.Date = e.DataEvento;
				tpOrg.Text = e.Tipo;
				;
				pckrTipos.SelectedIndex = pckrTipos.Items.IndexOf (e.Tipo);
				Atual = e;
				EventoS = eventoS;
			}
		}

		void clear_Clicked (object sender, EventArgs e)
		{
			entNome.Text = "";
			tpEvento.Time = new TimeSpan (0, 0, 0);
			dpEvento.Date = DateTime.Now;
			tpOrg.Text = "";
			pckrTipos.SelectedIndex = 0;
		}

		async void  cadastrar_Clicked (object sender, EventArgs e)
		{
			aiLoad.IsRunning = true;
			aiLoad.IsVisible = true;
			await prgBar.ProgressTo (0.1, 1, Easing.SinIn);
			await System.Threading.Tasks.Task.Delay (1000);
			await prgBar.ProgressTo (0.2, 1, Easing.SinIn);
			await System.Threading.Tasks.Task.Delay (1000);
			await prgBar.ProgressTo (0.3, 1, Easing.SinIn);
			await System.Threading.Tasks.Task.Delay (1000);
			await prgBar.ProgressTo (0.7, 1, Easing.SinIn);
			await System.Threading.Tasks.Task.Delay (1000);
			await prgBar.ProgressTo (1, 1, Easing.SinIn);
			aiLoad.IsRunning = false;
			aiLoad.IsVisible = false;
			if (Atual != null) {

				App.Eventos [EventoS] = new Evento () {
					Nome = entNome.Text,
					DataEvento = dpEvento.Date,
					Organizador = tpOrg.Text,
					Tipo = pckrTipos.Items [pckrTipos.SelectedIndex],
					HoraEvento = tpEvento.Time
				};

			} else {
				App.Eventos.Add (new Evento () {
					Nome = entNome.Text,
					DataEvento = dpEvento.Date,
					Organizador = tpOrg.Text,
					Tipo = pckrTipos.Items [pckrTipos.SelectedIndex],
					HoraEvento = tpEvento.Time
				});
			}
			DependencyService.Get<ITalk> ().Falar (string.Format ("The evento {0} register!", entNome.Text));
			await DisplayAlert ("Item Cadastrado", string.Format ("O evento {0} foi agendado para {1} as {2} e será organizado por {3}. Tipo: {4}", entNome.Text, dpEvento.Date.ToString (), tpEvento.Time.ToString (), tpOrg.Text, pckrTipos.Items [pckrTipos.SelectedIndex]), "OK");

			Navigation.PopAsync ();
		}
	}
}

