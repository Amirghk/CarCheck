using System.Globalization;

namespace CarCheck
{
    public class Program
    {
        // static property of datastore to use
        public static DataStore DataStoreS { get; set; }
       
        static void Main(string[] args)
        {
      
            if (DataStoreS == null)
            {
                DataStoreS = new DataStore();
            }
            DataStoreS.cars.Add(new Car("Peugeot", 2017));
            DataStoreS.customers.Add(new Customer("Amir"));
            DataStoreS.clerks.Add(new Clerk("Joe"));
            DataStoreS.facilities.Add(new ExaminationFacility("Ashrafi"));

            const string address = @"../file.txt";
            // make an object of the Repositories to use
            CarRepo carRepo = new CarRepo();
            ClerkRepo clerkRepo = new ClerkRepo();
            CustomerRepo customerRepo = new CustomerRepo();
            FacilityRepo facilityRepo = new FacilityRepo();
            QueueRepo queueRepo = new QueueRepo();
            RecieptRepo recieptRepo = new RecieptRepo();

            ReadWriteFile rw = new ReadWriteFile();

            MainMenu();

            void MainMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1. Add a car.");
                    Console.WriteLine("2. Add a customer.");
                    Console.WriteLine("3. Add a clerk.");
                    Console.WriteLine("4. Add a facility.");
                    Console.WriteLine("5. book a test.");
                    Console.WriteLine("6. request a receipt.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("7. Save to file.");
                    Console.WriteLine("8. Save to RAM");
                    Console.ForegroundColor = ConsoleColor.White;

                    var choice = Console.ReadKey(true);

                    switch (choice.Key)
                    {
                        case ConsoleKey.D1:
                            AddCar();
                            break;
                        case ConsoleKey.D2:
                            AddCustomer();
                            break;
                        case ConsoleKey.D3:
                            AddClerk();
                            break;
                        case ConsoleKey.D4:
                            AddFacility();
                            break;
                        case ConsoleKey.D5:
                            BookTest();
                            break;
                        case ConsoleKey.D6:
                            RequestReceipt();
                            break;
                        case ConsoleKey.D7:
                            rw.Write(address, DataStoreS);
                            Console.WriteLine("Done!");
                            break;
                        case ConsoleKey.D8:
                            DataStoreS = new DataStore();
                            DataStoreS = rw.Read(address);
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }


            void AddCar()
            {
                Console.Clear();
                Console.WriteLine("Car Brand: ");
                string? brand = Console.ReadLine();
                Console.WriteLine("Year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Car car = new Car(brand, year);
                carRepo.Add(car);
                Console.WriteLine("Car Added Succesfully!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }

            void AddCustomer()
            {
                Console.Clear();
                Console.WriteLine("Name: ");
                string? name = Console.ReadLine();
                Customer customer = new Customer(name);
                customerRepo.Add(customer);
                Console.WriteLine("Added Succesfully!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }

            void AddClerk()
            {
                Console.Clear();
                Console.WriteLine("Name: ");
                string? name = Console.ReadLine();
                Clerk clerk = new Clerk(name);
                clerkRepo.Add(clerk);
                Console.WriteLine("Added Succesfully!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }

            void AddFacility()
            {
                Console.Clear();
                Console.WriteLine("Name: ");
                string? name = Console.ReadLine();
                ExaminationFacility facility = new ExaminationFacility(name);
                facilityRepo.Add(facility);
                Console.WriteLine("Added Succesfully!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }

            void BookTest()
            {
                Console.Clear();
                // ------ get queue & car ------
                Console.WriteLine("Enter month: ");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day: ");
                int day = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("Select the car you wish to get tested: ");
                var cars = carRepo.GetAll();
                foreach (var c in cars)
                {
                    Console.WriteLine($"{c.id} - {c.brand}");
                }
                int choice = Convert.ToInt32(Console.ReadLine());
                var car = cars.FirstOrDefault(car => car.id == choice);
                DateTime date = new DateTime(2022, month, day);
                Queue q = new Queue(car.id, date);

                // ------ get facility ------
                Console.WriteLine("Select the facility: ");
                var facilities = facilityRepo.GetAll();
                foreach (var f in facilities)
                {
                    Console.WriteLine($"{f.id} - {f.name}");
                }
                choice = Convert.ToInt32(Console.ReadLine());

                var facility = facilities.FirstOrDefault(f => f.id == choice);
                if (facility == null)
                {
                    Console.WriteLine("Wrong Input!");
                    return;
                }
                else
                {
                    int response = facility.SignUpQuery(q);
                    switch (response)
                    {
                        case 1:
                            
                            queueRepo.Add(q);
                            facility.SignUps[date].Add(q);
                            break;
                        case 2:
                            Console.WriteLine("Unlucky!");
                            return;
                    }
                }

                // ------ get customer ------
                Console.WriteLine("Select a customer: ");
                var customers = customerRepo.GetAll();
                foreach (var cu in customers)
                {
                    Console.WriteLine($"{cu.id} - {cu.name}");
                }
                choice = Convert.ToInt32(Console.ReadLine());
                var customer = customers.FirstOrDefault(c => c.id == choice);
                if (customer == null)
                {
                    Console.WriteLine("Wrong Input!");
                    return;
                }

                // ------ get clerk ------
                Console.WriteLine("Select a clerk: ");
                var clerks = clerkRepo.GetAll();
                foreach (var cl in clerks)
                {
                    Console.WriteLine($"{cl.id} - {cl.name}");
                }
                choice = Convert.ToInt32(Console.ReadLine());
                var clerk = clerks.FirstOrDefault(c => c.id == choice);
                if (clerk == null)
                {
                    Console.WriteLine("Wrong Input!");
                    return;
                }

                // make a receipt
                Console.WriteLine($"Your session is booked for {date.ToString("d", new CultureInfo("fa-IR", false))}!");
                Reciept reciept = new Reciept(facility.id, car.id, customer.id, clerk.id, date);
                DataStoreS.reciepts.Add(reciept);

                Console.WriteLine("press any key to continue");
                Console.ReadKey(true);
            }

            void RequestReceipt()
            {
                Console.Clear();
                Console.WriteLine("Select the car you wish to get the receipt of: ");
                foreach (var c in carRepo.GetAll())
                {
                    Console.WriteLine($"{c.id} - {c.brand}");
                }
                int choice = Convert.ToInt32(Console.ReadLine());

                var receipt = recieptRepo.GetAll().FirstOrDefault(r => r.CarID == choice);
                if (receipt == null)
                {
                    Console.WriteLine("No receipts saved for the Car you selected!");
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(receipt.ToString());
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("press any key to continue.");
                Console.ReadKey(true);
            }
        }
    }
}

