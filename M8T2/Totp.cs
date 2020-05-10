using System;
using System.Security.Cryptography;

namespace GoogleAuthenticator
{
	class Totp
    {
		RNGCryptoServiceProvider rnd;
		protected string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

		private int tamañoIntervalo;
		private int tamañoPinCode;
		private int pinModulo;


		public Totp(byte[] rngBytes)
		{
			rnd = new RNGCryptoServiceProvider();

			tamañoPinCode = 6;
			tamañoIntervalo = 30;
			pinModulo = (int)Math.Pow(10, tamañoPinCode);

			rnd.GetBytes(rngBytes);
		}

		private String generarResponseCode(long challenge, byte[] randomBytes)
		{
			HMACSHA1 myHmac = new HMACSHA1(randomBytes);
			myHmac.Initialize();

			byte[] value = BitConverter.GetBytes(challenge);
			Array.Reverse(value); 
			myHmac.ComputeHash(value);
			byte[] hash = myHmac.Hash;
			int offset = hash[hash.Length - 1] & 0xF;
			byte[] SelectedFourBytes = new byte[4];			
			SelectedFourBytes[0] = hash[offset];
			SelectedFourBytes[1] = hash[offset + 1];
			SelectedFourBytes[2] = hash[offset + 2];
			SelectedFourBytes[3] = hash[offset + 3];
			Array.Reverse(SelectedFourBytes);
			int finalInt = BitConverter.ToInt32(SelectedFourBytes, 0);
			int truncatedHash = finalInt & 0x7FFFFFFF;
			int pinValue = truncatedHash % pinModulo; 
			return padOutput(pinValue);
		}


		/// <summary>
		/// Si el tamaño es menor completamos con ceros
		/// </summary>
		private String padOutput(int value)
		{
			String result = value.ToString();
			for (int i = result.Length; i < tamañoPinCode; i++)
			{
				result = "0" + result;
			}
			return result;
		}

		/// <summary>
		/// Gets current interval number since Unix Epoch based on given interval length
		/// </summary>
		/// <returns>Current interval number</returns>
		public long ObtenerIntervaloActual()
		{
			TimeSpan TS = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			long totalSegundos = (long)Math.Floor(TS.TotalSeconds);
			long intervaloActual = totalSegundos / tamañoIntervalo; // 30 Seconds
			return intervaloActual;
		}

		public string GenerarPin(byte[] rngBytes)
		{
			return generarResponseCode(ObtenerIntervaloActual(), rngBytes);
		}

	}
}
