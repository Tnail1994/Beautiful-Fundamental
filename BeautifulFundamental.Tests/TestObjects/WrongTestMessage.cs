namespace BeautifulFundamental.Tests.TestObjects
{
	public class WrongTestMessage : INetworkMessage
	{
		private static WrongTestMessage Create()
		{
			return new WrongTestMessage();
		}

		public static string CreateString()
		{
			return JsonConvert.SerializeObject(Create(), JsonConfig.Settings);
		}

		public string TypeDiscriminator => string.Empty;
	}
}