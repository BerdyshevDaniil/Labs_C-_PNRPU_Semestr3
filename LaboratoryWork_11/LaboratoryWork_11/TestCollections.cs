using System;
using System.Collections.Generic;
using System.Xml.Linq;
using LocationLibrary;

namespace LaboratoryWork_11
{
    internal class TestCollections
    {
        //Contains
        public List<Address> listAddress = new List<Address>();
        public List<string> listString = new List<string>();
        //ContainsValue + ContainsKey
        public SortedDictionary<Location, Address> sdLocation = new SortedDictionary<Location, Address>();
        public SortedDictionary<string, Address> sdString = new SortedDictionary<string, Address>();

        public TestCollections(int size)
        {
            for (int i = 0; i < size; ++i)
            {
                Address current = new Address();
                current.RandomInit();
                while (sdLocation.ContainsKey(current.BaseLocation))
                {
                    current.RandomInit();
                }
                listAddress.Add(current);
                listString.Add(current.ToString());
                sdLocation.Add(current.BaseLocation, current);
                sdString.Add(current.BaseLocation.ToString(), current);
            }
        }
        public void Add(Address c)
        {
            if (!sdLocation.ContainsKey(c.BaseLocation))
            {
                listAddress.Add(c);
                listString.Add(c.ToString());
                sdLocation.Add(c.BaseLocation, c);
                sdString.Add(c.BaseLocation.ToString(), c);
            }
        }
        public void Remove(Address c)
        {
            listAddress.Remove(c);
            listString.Remove(c.ToString());
            sdLocation.Remove(c.BaseLocation);
            sdString.Remove(c.BaseLocation.ToString());
        }
    }
}
