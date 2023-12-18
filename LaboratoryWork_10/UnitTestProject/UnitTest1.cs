using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocationLibrary;
using LaboratoryWork_10;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountNorthernHemisphereAddresses_AddressesIsExists_PositiveCountReturned()
        {
            // arrange
            Location[] locations = { new Address(100, 90, "", "", "", "", 1), new Location(100, 50) };
            int expected = 1;

            // act
            int actual = Program.CountNorthernHemisphereAddresses(locations);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountNorthernHemisphereAddresses_SouthHemisphereAddresses_0Returned()
        {
            // arrange
            Location[] locations = { new Address(100, 0, "", "", "", "", 1), new Address(100, -50, "", "", "", "", 1) };
            int expected = 0;

            // act
            int actual = Program.CountNorthernHemisphereAddresses(locations);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountMultimillionCities_CityExists_PositiveCountReturned()
        {
            // arrange
            Location[] locations = { new City(100, 0, "", "", 2_000_000), new Megacity(100, -50, "", "", 10_000_000, 5000), new City() };
            int expected = 2;

            // act
            int actual = Program.CountMultimillionCities(locations);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountMultimillionCities_CityNotExists_0Returned()
        {
            // arrange
            Location[] locations = { new Location() };
            int expected = 0;

            // act
            int actual = Program.CountMultimillionCities(locations);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountSpecifiedStreetAddresses_AddressExists_PositiveCountReturned()
        {
            // arrange
            Location[] locations = { new Address(100, 90, "", "", "", "Мира", 2), new Address() };
            int expected = 1;

            // act
            int actual = Program.CountSpecifiedStreetAddresses(locations, "Мира");

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountSpecifiedStreetAddresses_AddressNotExists_0Returned()
        {
            // arrange
            Location[] locations = { new Location() };
            int expected = 0;

            // act
            int actual = Program.CountSpecifiedStreetAddresses(locations, "Мира");

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SearchBinary_EmptyArray_NullReturned()
        {
            // arrange
            Location[] locations = new Location[0];
            Location expected = null;

            // act
            Location actual = Program.SearchBinary(locations, 0);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ExactValue_ExactLocationReturned()
        {
            // arrange
            Location[] locations = new Location[10];
            for (int i = 0; i < 10; ++i)
            {
                locations[i] = new Location();
                locations[i].RandomInit();
            }
            Array.Sort(locations);
            Location expected = locations[5];

            // act
            Location actual = Program.SearchBinary(locations, expected.Longitude);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ApproximateValueIndex0_Index1Returned()
        {
            // arrange
            Location[] locations = new Location[3];
            locations[0] = new Location(-180, 90);
            locations[1] = new Location(10, 90);
            locations[2] = new Location(180, 90);
            Array.Sort(locations);
            Location expected = locations[1];

            // act
            Location actual = Program.SearchBinary(locations, 0);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ApproximateValueIndex0_Index0Returned()
        {
            // arrange
            Location[] locations = new Location[3];
            locations[0] = new Location(-180, 90);
            locations[1] = new Location(10, 90);
            locations[2] = new Location(180, 90);
            Array.Sort(locations);
            Location expected = locations[0];

            // act
            Location actual = Program.SearchBinary(locations, -170);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ApproximateValueIndexMax_IndexMaxReturned()
        {
            // arrange
            Location[] locations = new Location[3];
            locations[0] = new Location(-180, 90);
            locations[1] = new Location(-10, 90);
            locations[2] = new Location(180, 90);
            Array.Sort(locations);
            Location expected = locations[2];

            // act
            Location actual = Program.SearchBinary(locations, 170);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ApproximateValueIndexMax_IndexNearMaxReturned()
        {
            // arrange
            Location[] locations = new Location[3];
            locations[0] = new Location(-180, 90);
            locations[1] = new Location(-10, 90);
            locations[2] = new Location(180, 90);
            Array.Sort(locations);
            Location expected = locations[1];

            // act
            Location actual = Program.SearchBinary(locations, 0);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ApproximateValueIndexMidle_IndexMidleDecReturned()
        {
            // arrange
            Location[] locations = new Location[5];
            locations[0] = new Location(-180, 90);
            locations[1] = new Location(-100, 90);
            locations[2] = new Location(0, 90);
            locations[3] = new Location(100, 90);
            locations[4] = new Location(180, 90);
            Array.Sort(locations);
            Location expected = locations[2];

            // act
            Location actual = Program.SearchBinary(locations, 10);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ApproximateValueIndexMidle_IndexMidleIncrReturned()
        {
            // arrange
            Location[] locations = new Location[5];
            locations[0] = new Location(-180, 90);
            locations[1] = new Location(-100, 90);
            locations[2] = new Location(0, 90);
            locations[3] = new Location(100, 90);
            locations[4] = new Location(180, 90);
            Array.Sort(locations);
            Location expected = locations[2];

            // act
            Location actual = Program.SearchBinary(locations, -10);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ApproximateValueIndexMidle_IndexMidle1Returned()
        {
            // arrange
            Location[] locations = new Location[5];
            locations[0] = new Location(-180, 90);
            locations[1] = new Location(-100, 90);
            locations[2] = new Location(0, 90);
            locations[3] = new Location(100, 90);
            locations[4] = new Location(180, 90);
            Array.Sort(locations);
            Location expected = locations[1];

            // act
            Location actual = Program.SearchBinary(locations, -90);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ApproximateValueIndexMidle_IndexMidle2Returned()
        {
            // arrange
            Location[] locations = new Location[6];
            locations[0] = new Location(-180, 90);
            locations[1] = new Location(-100, 90);
            locations[2] = new Location(-10, 90);
            locations[3] = new Location(10, 90);
            locations[4] = new Location(100, 90);
            locations[5] = new Location(180, 90);
            Array.Sort(locations);
            Location expected = locations[3];

            // act
            Location actual = Program.SearchBinary(locations, 5);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SearchBinary_ApproximateArrayLength1_Index0Returned()
        {
            // arrange
            Location[] locations = new Location[1];
            locations[0] = new Location(0, 90);
            Location expected = locations[0];

            // act
            Location actual = Program.SearchBinary(locations, 5);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CopyShallow_Address_ShallowCopyReturned()
        {
            // arrange
            Address ad1 = new Address();
            Address ad2 = Program.CopyShallow(ad1);
            bool expected = true;

            // act
            bool actual = ad1.Equals(ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CopyDeep_Address_DeepCopyReturned()
        {
            // arrange
            Address ad1 = new Address();
            Address ad2 = Program.CopyDeep(ad1);
            bool expected = false;

            // act
            bool actual = Equals(ad1, ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsLocation_NullObject_FalseReturned()
        {
            // arrange
            Location lc1 = null;
            Location lc2 = new Location(1, 1);
            bool expected = false;

            // act
            bool actual = lc2.Equals(lc1);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsLocation_NotEqual_FalseReturned()
        {
            // arrange
            Location lc1 = new Location();
            Location lc2 = new Location(1, 1);
            bool expected = false;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsLocation_Equal_TrueReturned()
        {
            // arrange
            Location lc1 = new Location();
            Location lc2 = new Location();
            bool expected = true;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsAddress_NullObject_FalseReturned()
        {
            // arrange
            Address lc1 = null;
            Address lc2 = new Address();
            bool expected = false;

            // act
            bool actual = lc2.Equals(lc1);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsAddress_NotEqual_FalseReturned()
        {
            // arrange
            Address lc1 = new Address();
            Address lc2 = new Address();
            lc2.Longitude = 1;
            bool expected = false;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsAddress_Equal_TrueReturned()
        {
            // arrange
            Address lc1 = new Address();
            Address lc2 = new Address();
            bool expected = true;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsCity_NullObject_FalseReturned()
        {
            // arrange
            City lc1 = null;
            City lc2 = new City();
            bool expected = false;

            // act
            bool actual = lc2.Equals(lc1);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsCity_NotEqual_FalseReturned()
        {
            // arrange
            City lc1 = new City();
            City lc2 = new City();
            lc2.Longitude = 1;
            bool expected = false;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsCity_Equal_TrueReturned()
        {
            // arrange
            City lc1 = new City();
            City lc2 = new City();
            bool expected = true;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsMegacity_NullObject_FalseReturned()
        {
            // arrange
            Megacity lc1 = null;
            Megacity lc2 = new Megacity();
            bool expected = false;

            // act
            bool actual = lc2.Equals(lc1);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsMegacity_NotEqual_FalseReturned()
        {
            // arrange
            Megacity lc1 = new Megacity();
            Megacity lc2 = new Megacity();
            lc2.Longitude = 1;
            bool expected = false;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsMegacity_Equal_TrueReturned()
        {
            // arrange
            Megacity lc1 = new Megacity();
            Megacity lc2 = new Megacity();
            bool expected = true;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsRegion_NullObject_FalseReturned()
        {
            // arrange
            Region lc1 = null;
            Region lc2 = new Region();
            bool expected = false;

            // act
            bool actual = lc2.Equals(lc1);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsRegion_NotEqual_FalseReturned()
        {
            // arrange
            Region lc1 = new Region();
            Region lc2 = new Region();
            lc2.Longitude = 1;
            bool expected = false;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EqualsRegion_Equal_TrueReturned()
        {
            // arrange
            Region lc1 = new Region();
            Region lc2 = new Region();
            bool expected = true;

            // act
            bool actual = lc1.Equals(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CompareToLocation_EqualLongitude_0Returned()
        {
            // arrange
            Location lc1 = new Location();
            Address lc2 = new Address();
            int expected = 0;

            // act
            int actual = lc1.CompareTo(lc2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShallowCopy_Region_ShallowCopyReturned()
        {
            // arrange
            Region ad1 = new Region();
            Region ad2 = ad1.ShallowCopy();
            bool expected = true;

            // act
            bool actual = ad1.Equals(ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Clone_Region_DeepCopyReturned()
        {
            // arrange
            Region ad1 = new Region();
            Region ad2 = (Region) ad1.Clone();
            bool expected = false;

            // act
            bool actual = Equals(ad1, ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShallowCopy_Location_ShallowCopyReturned()
        {
            // arrange
            Location ad1 = new Location();
            Location ad2 = ad1.ShallowCopy();
            bool expected = true;

            // act
            bool actual = ad1.Equals(ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Clone_Location_DeepCopyReturned()
        {
            // arrange
            Location ad1 = new Location();
            Location ad2 = (Location)ad1.Clone();
            bool expected = true;

            // act
            bool actual = Equals(ad1, ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShallowCopy_City_ShallowCopyReturned()
        {
            // arrange
            City ad1 = new City();
            City ad2 = ad1.ShallowCopy();
            bool expected = true;

            // act
            bool actual = ad1.Equals(ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Clone_City_DeepCopyReturned()
        {
            // arrange
            City ad1 = new City();
            City ad2 = (City)ad1.Clone();
            bool expected = false;

            // act
            bool actual = Equals(ad1, ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShallowCopy_Megacity_ShallowCopyReturned()
        {
            // arrange
            Megacity ad1 = new Megacity();
            Megacity ad2 = ad1.ShallowCopy();
            bool expected = true;

            // act
            bool actual = ad1.Equals(ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Clone_Megacity_DeepCopyReturned()
        {
            // arrange
            Megacity ad1 = new Megacity();
            Megacity ad2 = (Megacity)ad1.Clone();
            bool expected = false;

            // act
            bool actual = Equals(ad1, ad2);

            // assert
            Assert.AreEqual(expected, actual);
        }

    }
}
