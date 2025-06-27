namespace VendingMachine
{
	/// <summary>
	/// The Machine class represents a vending machine that can hold and dispense products.
	/// </summary>
	public class Machine
	{
		// A property for statment of the machine
		public bool IsRun { get; set; }

		// Some private fields for the machine
		private int[] _moneyPool = new int[1];
		private readonly int[] _denominations = [1, 2, 5, 10, 20, 50, 100, 200, 500, 1000];
		private int _countOfBanknotes = 0, _temp;
		private decimal _balance = 0;
		private List<Product> _products = new List<Product>();
		private string _input = string.Empty;

		/// <summary>
		/// The constructor initializes a new instance of the Machine class.
		/// </summary>
		public Machine()
		{
			AddProducts();

			// Interact with the user to insert banknotes and buy products
			InsertBanknotes();
			Buying();

			ChangeBack();
		}

		/// <summary>
		/// The user can select some product from the vending machine.
		/// </summary>
		public void Buying()
		{
			// Set the machine to run state
			IsRun = true;

			// Loop until the user decides to stop buying products
			do
			{
				// Make a empty screen for better readability and show the name of the application
				Console.Clear();
				Console.WriteLine(Program.ApplicationName);

				// Check if the user has some money in the machine
				if (_balance <= 0)
				{
					// Ask the user if they will insert more moeny or exit the program
					Console.WriteLine("You don't have any money in the machine, will you insert money into the machine? (yes/no)");
					_input = Console.ReadLine()!;

					if (_input.ToLower() == "yes")
					{
						InsertBanknotes();
						continue;
					}
					else
					{
						Console.WriteLine("Exiting the program...");

						// Make a pause for the user to read the message
						Console.WriteLine("Press any key to exit...");
						Console.ReadKey();

						IsRun = false;
						return;
					}
				}

				// Show the current balance of the user
				Console.WriteLine($"Your current balance is: {_balance}");
				// Show the list of products available in the vending machine
				ShowProductList();

				// Ask the user to select a product
				Console.Write("Select a product by number: ");
				int.TryParse(Console.ReadLine()!, out int choice);

				if (choice == _products.Count + 1)
				{
					Console.WriteLine("Exiting the program...");
					IsRun = false;
					return;
				}
				else if (choice < 1 || choice > _products.Count)
				{
					Console.WriteLine("Invalid choice. Please try again.");
					continue;
				}

				// Get the selected product
				Product selectedProduct = _products[choice - 1];

				// Check if the user has enough money to buy the selected product
				if (_balance < selectedProduct.Price)
				{
					Console.WriteLine($"You don't have enough money to buy {selectedProduct.Name}. Please insert more money.");
					continue;
				}
				_balance -= selectedProduct.Purchase();
				selectedProduct.Use();

				// Make a pause for the user to read the message
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();

			} while (IsRun == true);
		}

		#region Money Management
		/// <summary>
		/// Inserts banknotes into the vending machine.
		/// </summary>
		public void InsertBanknotes()
		{
			// Set the machine to run state
			IsRun = true;
			_countOfBanknotes = 0;


			// Loop until the user decides to stop inserting banknotes
			do
			{
				// Ask the user to insert banknotes into the machine
				Console.WriteLine("Insert banknotes into the machine? (The allowed are ");
				foreach (var item in _denominations)
				{
					Console.Write($"{item} ");
				}
				Console.Write("): ");
				int.TryParse(Console.ReadLine(), out _temp);

				// Check if the user has entered invalid input 
				if (_denominations.Contains(_temp) == false)
				{
					Console.WriteLine("This banknote is not allowed. Please try again.");
					continue;
				}

				// Add the banknote to the money pool and update the sum
				_moneyPool[_countOfBanknotes] = _temp;
				_balance += _temp;
				_countOfBanknotes++;

				// Ask the user if they want to insert more banknotes
				Console.WriteLine("Do you want to insert more banknotes? (yes/no): ");
				_input = Console.ReadLine()!;

				// Check if the user wants to stop inserting banknotes
				if (_input.ToLower() == "no")
				{
					// If the user does not want to insert more banknotes, exit the loop
					IsRun = false;
					Console.WriteLine($"You have inserted {_balance} in total.");
				}
				else
					Array.Resize(ref _moneyPool, _countOfBanknotes + 1);

			} while (IsRun == true);

			// Reverse the money pool to have the banknotes in descending order
			Array.Reverse(_moneyPool);
		}

		/// <summary>
		/// Gives back the change to the user.
		/// </summary>
		public void ChangeBack()
		{
			// Variable hold 
			int[] backMoney = new int[_denominations.Length];

			// Make a empty screen for a better user experience
			Console.Clear();
			Console.WriteLine(Program.ApplicationName);

			// Set variable to zero for specified how machine give back to the user
			for (int i = 0; i < backMoney.Length; i++)
			{
				backMoney[i] = 0;
			}

			Console.WriteLine($"The machine give you {_balance} back.");

			// Loop while the sum doesn't are zero
			while (_balance != 0)
			{
				for (int i = _denominations.Length - 1; i >= 0; i--)
				{
					while (_balance > 0 && _balance >= _denominations[i])
					{
						_balance -= _denominations[i];
						backMoney[i]++;
					}
				}
			}

			// Show the change back to the user
			for (int i = _denominations.Length - 1; i >= 0; i--)
			{
				if (backMoney[i] > 0)
				{
					Console.WriteLine($"You get {backMoney[i]} banknotes of {_denominations[i]} denomination.");
				}
			}

			// Make a pause for the user to read the change
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
		#endregion

		#region Product Management
		/// <summary>
		/// Adds some products to the vending machine.
		/// </summary>
		public void AddProducts()
		{
			_products.Add(new Drink("Coca Cola", "Coca Cola are a drink from Coca Cola Corp"));
			_products.Add(new Drink("Fanta", "Fanta are a drink from Coca Cola Corp"));
			_products.Add(new Snack("Chips", "Chips are make from potato"));
			_products.Add(new Food("Sandswich", "Sandswich"));
		}

		/// <summary>
		/// Shows the list of available products in the vending machine.
		/// </summary>
		public void ShowProductList()
		{
			// Variable to hold the product number
			int productNumber = 1;

			// Show list of products
			foreach (var item in _products)
			{
				Console.WriteLine($"{productNumber}. {item.Name} - {item.Description} (Price: {item.Price})");
				productNumber++;
			}
			Console.WriteLine($"{productNumber}. Exit program");
		}
		#endregion
	}
}
