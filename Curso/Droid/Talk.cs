using System;
using Xamarin.Forms;
using Android.Speech.Tts;
using System.Collections.Generic;
using Curso.Droid;

[assembly: DependencyAttribute (typeof(Talk))]
namespace Curso.Droid
{
	public class Talk : ITalk
	{
		#region ITalk implementation

		TextToSpeech speaker;

		public void Falar (string Fala)
		{
			var ctx = Forms.Context; // useful for many Android SDK features
			if (speaker == null) {
				speaker = new TextToSpeech (ctx, this);
			} else {
				var p = new Dictionary<string,string> ();
				speaker.Speak (Fala, QueueMode.Flush, p);
			}
		}

		#endregion

		public Talk ()
		{
		}


	}
}

