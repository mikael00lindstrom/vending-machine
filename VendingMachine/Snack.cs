namespace VendingMachine
{
	/// <summary>
	/// The Snack class represents a snack product in the vending machine.
	/// </summary>
	public class Snack : Product
	{
		/// <summary>
		/// Initializes a new instance of the Snack class with a specified name and description.
		/// </summary>
		/// <param name="name">The name of the new snack product</param>
		/// <param name="description">The description of the new snack product</param>
		public Snack(string name, string description) : base(name, description)
		{
			Price = 15;
		}

		/// <summary>
		/// Gets information about the snack product.
		/// </summary>
		public override void GetInfo()
		{
			Console.WriteLine(Description);
		}

		/// <summary>
		/// Processes the purchase of the snack product and returns its price.
		/// </summary>
		/// <returns></returns>
		public override decimal Purchase()
		{
			Console.WriteLine($"The {Name} cost {Price}.");
			return Price;
		}

		/// <summary>
		/// Executes the action of using the snack product, which in this case is eating it.
		/// </summary>
		public override void Use()
		{
			Console.WriteLine($"Eat the {Name}.");
		}
	}
}
