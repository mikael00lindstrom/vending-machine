namespace VendingMachine
{
	/// <summary>
	/// The entry class for the Vending Machine application.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// The name of the Vending Machine application.
		/// </summary>
		public const string ApplicationName = "The Vending Machine 2000";

		/// <summary>
		/// The entry point of the Vending Machine application.
		/// </summary>
		/// <param name="args">Anything</param>
		static void Main(string[] args)
		{
			// Welcome the user to the Vending Machine application.
			Console.WriteLine($"Welcome to {ApplicationName}!");

			// Make a pause to allow the user to read the welcome message.
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}
