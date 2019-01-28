using System.Collections;
using System.Collections.Generic;

namespace Garage_1._0
{

    //    class Garage<T> where T : Vehicle
    //    {

    //        public LimitedList<T> GarageVehicles { get ; set ; }

    //    public Garage(LimitedList<T> garageVehicles)
    //    {
    //        GarageVehicles = garageVehicles;   
    //    }
    //}

    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private readonly List<T> vehicles = new List<T>();

        public int Capacity { get; }
        public int Count => vehicles.Count;
        public bool IsFull => vehicles.Count >= Capacity;

        public Garage(int capacity)
        {
            this.Capacity = capacity;
        }

        public T this[int index]
        {
            get { return vehicles[index]; }
            set { vehicles[index] = value; }
        }

        public bool Add(T item)
        {
            if (IsFull) return false;

            vehicles.Add(item);
            return true;
        }

        public bool Remove(T item)
        {
            return vehicles.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}

