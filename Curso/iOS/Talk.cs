using System;
using Xamarin;
using Xamarin.Forms;
using AVFoundation;
using Curso.iOS;

[assembly: DependencyAttribute(typeof(Talk))]
namespace Curso.iOS
{
	public class Talk : ITalk
	{
		#region ITalk implementation

		public void Falar (string Fala)
		{
			var speechSynthesizer = new AVSpeechSynthesizer ();

			var speechUtterance = new AVSpeechUtterance (Fala) {
				Rate = AVSpeechUtterance.MaximumSpeechRate/4,
				Volume = 0.5f,
				PitchMultiplier = 1.0f
			};

			speechSynthesizer.SpeakUtterance (speechUtterance);
		}

		#endregion

		public Talk ()
		{
		}
	}
}

