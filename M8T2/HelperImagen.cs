using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace GoogleAuthenticator
{
	public static class HelperImagen
    {
		private static string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
		internal static Image GenerarImagen(int width, int height, string email, byte[] randomBytes)
		{
			string stringRNG = CreativeCommons.Transcoder.Base32Encode(randomBytes);
			string otpAuth = UrlEncode(String.Format("otpauth://totp/{0}?secret={1}", email, stringRNG));
			string url = String.Format("http://chart.apis.google.com/chart?cht=qr&chs={0}x{1}&chl={2}", width, height, otpAuth);

			WebClient wc = new WebClient();
			var data = wc.DownloadData(url);

			using (var imageStream = new MemoryStream(data))
			{
				return new Bitmap(imageStream);
			}
		}

		private static string UrlEncode(string value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			foreach (char s in value)
			{
				if (chars.IndexOf(s) != -1)				
					stringBuilder.Append(s);			
				else				
					stringBuilder.Append('%' + String.Format("{0:X2}", (int)s));				
			}

			return stringBuilder.ToString();
		}
	}
}
