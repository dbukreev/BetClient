namespace BetClient.Model
{
	public class LoginModel
	{
		public LoginModel()
		{
		}

		public string Login { get; set; }

		public string Password { get; set; }

		public static bool IsLogin;
	}
}