namespace VendingMachine
{
	/// <summary>
	/// The Food class represents a food product in the vending machine.
	/// </summary>
	public class Food : Product
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Food"/> class with the specified name and description.
		/// </summary>
		/// <param name="name">The name of the food item. This value cannot be null or empty.</param>
		/// <param name="description">A brief description of the food item. This value cannot be null or empty.</param>
		public Food(string name, string description) : base(name, description)
		{
			Price = 25;
		}

		/// <summary>
		/// Gets information about the food.
		/// </summary>
		public override void GetInfo()
		{
			Console.WriteLine(Description);
		}

		/// <summary>
		/// Processes the purchase of the food item and returns its price.
		/// </summary>
		/// <returns>The price of the product</returns>
		public override decimal Purchase()
		{
			Console.WriteLine($"The {Name} cost {Price}.");

			return Price;
		}

		/// <summary>
		/// Executes the action of using the food item, such as eating it.
		/// </summary>
		public override void Use()
		{
			Console.WriteLine($"Eat the {Name}.");
		}
	}
}
