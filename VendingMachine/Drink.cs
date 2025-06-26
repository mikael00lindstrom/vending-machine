namespace VendingMachine
{
	/// <summary>
	/// The Drink class represents a drink product in the vending machine.
	/// </summary>
	public class Drink : Product
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Drink"/> class with the specified name and description.
		/// </summary>
		/// <param name="name">The name of the drink. This value cannot be null or empty.</param>
		/// <param name="description">A brief description of the drink. This value cannot be null or empty.</param>
		public Drink(string name, string description) : base(name, description)
		{
			Price = 20;
		}

		/// <summary>
		/// Gets information about the drink.
		/// </summary>
		public override void GetInfo()
		{
			Console.WriteLine(Description);
		}

		/// <summary>
		/// Processes the purchase of the item and returns its price.
		/// </summary>
		/// <returns>The price of the purchased item as a <see cref="decimal"/>.</returns>
		public override decimal Purchase()
		{
			Console.WriteLine($"You have purchased {Name} for {Price}.");
			return Price;
		}

		/// <summary>
		/// Executes the action of using the drink.
		/// </summary>
		public override void Use()
		{
			Console.WriteLine($"Drink the {Name}.");
		}
	}
}
