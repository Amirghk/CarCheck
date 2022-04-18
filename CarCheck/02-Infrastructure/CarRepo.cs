namespace CarCheck
{
    public class CarRepo : IGenericRepo<Car>
    {
        public int Add(Car obj)
        {
            if (Program.DataStoreS.cars is null)
            {
                Program.DataStoreS.cars = new List<Car> { obj };
            }
            else
                Program.DataStoreS.cars.Add(obj);
            return obj.id;
        }

        public int Delete(Car obj)
        {
            Program.DataStoreS.cars.Remove(obj);
            return obj.id;
        }

        public Car Get(int id)
        {
            return Program.DataStoreS.cars.FirstOrDefault(car => car.id == id);
        }

        public List<Car> GetAll()
        {
            try
            {
                return Program.DataStoreS.cars;
            }
            catch (NullReferenceException)
            {

                throw new Exception("The list is empty.");

            }
        }

        public int Update(Car obj)
        {
            Car? car = Program.DataStoreS.cars.FirstOrDefault(car => car.id == obj.id);
            if (car != null)
            {
                Program.DataStoreS.cars.Remove(car);
                Program.DataStoreS.cars.Add(obj);
                return obj.id;
            }
            else
                return 0;
        }
    }
}