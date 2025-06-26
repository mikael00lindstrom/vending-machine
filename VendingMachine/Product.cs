namespace VendingMachine
{
	/// <summary>
	/// This class represents a product in the vending machine.
	/// </summary>
	public abstract class Product(string name, string description)
	{
		// Some properties that are common to all products
		public string? Name { get; set; } = name;
		public decimal Price { get; set; }
		public string? Description { get; set; } = description;

		// Some abstract methods that must be implemented by derived classes
		public abstract decimal Purchase();
		public abstract void GetInfo();
		public abstract void Use();
	}
}
