using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Security.AccessControl;

namespace LaboratoryWork_9.Tests
{
    [TestClass]
    public class LaboratoryWork9Tests
    {
        [TestMethod]
        public void EquationIsExists_A0B0C0_XExistsreturned()
        {
            // arrange
            Equation eq = new Equation();
            bool expected = true;

            // act
            bool actual = eq.IsExist();

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationIsExists_A0B0C1_XNotExistsreturned()
        {
            // arrange
            Equation eq = new Equation(0, 0, 1);
            bool expected = false;

            // act
            bool actual = eq.IsExist();

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationIsExists_NegativeDiscriminant_XNotExistsreturned()
        {
            // arrange
            Equation eq = new Equation(1, 1, 5);
            bool expected = false;

            // act
            bool actual = eq.IsExist();

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SolveEquation_NegativeDiscriminant_XNotExistsreturned()
        {
            // arrange
            Equation eq = new Equation(1, 1, 5);
            Tuple<double, double> expected = new Tuple<double, double>(double.MinValue, double.MinValue);

            // act
            double x1, x2;
            eq.SolveEquation(out x1, out x2);
            Tuple<double, double> actual = new Tuple<double, double>(x1, x2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SolveEquation_A0B0C0_XMaxValuesreturned()
        {
            // arrange
            Equation eq = new Equation();
            Tuple<double, double> expected = new Tuple<double, double>(double.MaxValue, double.MaxValue);

            // act
            double x1, x2;
            eq.SolveEquation(out x1, out x2);
            Tuple<double, double> actual = new Tuple<double, double>(x1, x2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SolveEquation_A0B0C1_XMaxValuesreturned()
        {
            // arrange
            Equation eq = new Equation(0, 0, 1);
            Tuple<double, double> expected = new Tuple<double, double>(double.MinValue, double.MinValue);

            // act
            double x1, x2;
            eq.SolveEquation(out x1, out x2);
            Tuple<double, double> actual = new Tuple<double, double>(x1, x2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SolveEquation_Discriminant0_XNotExistsreturned()
        {
            // arrange
            Equation eq = new Equation(1, 2, 1);
            Tuple<double, double> expected = new Tuple<double, double>(-1, -1);

            // act
            double x1, x2;
            eq.SolveEquation(out x1, out x2);
            Tuple<double, double> actual = new Tuple<double, double>(x1, x2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SolveEquation_PositiveDiscriminantA0_XNotExistsreturned()
        {
            // arrange
            Equation eq = new Equation(0, 1, 1);
            Tuple<double, double> expected = new Tuple<double, double>(-1, Double.MinValue);

            // act
            double x1, x2;
            eq.SolveEquation(out x1, out x2);
            Tuple<double, double> actual = new Tuple<double, double>(x1, x2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SolveEquation_PositiveDiscriminantA1_XNotExistsreturned()
        {
            // arrange
            Equation eq = new Equation(1, -1, -6);
            Tuple<double, double> expected = new Tuple<double, double>(-2, 3);

            // act
            double x1, x2;
            eq.SolveEquation(out x1, out x2);
            Tuple<double, double> actual = new Tuple<double, double>(x1, x2);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationIncrement_A0B1C2_A1B2C3returned()
        {
            // arrange
            Equation eq = new Equation(0, 1, 2);
            Tuple<double, double, double> expected = new Tuple<double, double, double>(1, 2, 3);

            // act
            eq++;
            Tuple<double, double, double> actual = new Tuple<double, double, double>(eq.A, eq.B, eq.C);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationDecrement_A1B1C2_A0B0C1returned()
        {
            // arrange
            Equation eq = new Equation(1, 1, 2);
            Tuple<double, double, double> expected = new Tuple<double, double, double>(0, 0, 1);

            // act
            eq--;
            Tuple<double, double, double> actual = new Tuple<double, double, double>(eq.A, eq.B, eq.C);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationDouble_A0B0C1_0returned()
        {
            // arrange
            Equation eq = new Equation(0, 0, 1);
            double expected = 0;

            // act
            double actual = (double)eq;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationDouble_A0B0C0_MaxValuereturned()
        {
            // arrange
            Equation eq = new Equation();
            double expected = Double.MaxValue;

            // act
            double actual = (double)eq;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationDouble_A0_NegativeValuereturned()
        {
            // arrange
            Equation eq = new Equation(0, 1, 1);
            double expected = -1;

            // act
            double actual = (double)eq;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationDouble_PositiveDiscriminantA1_XMaxreturned()
        {
            // arrange
            Equation eq = new Equation(1, -1, -6);
            double expected = 3;

            // act
            double actual = (double)eq;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationBool_A0B0C0_Truereturned()
        {
            // arrange
            Equation eq = new Equation();
            bool expected = true;

            // act
            bool actual = (bool)eq;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationBool_A0B0C1_Falsereturned()
        {
            // arrange
            Equation eq = new Equation(0, 0, 1);
            bool expected = false;

            // act
            bool actual = (bool)eq;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationEquality_EqualEquations_Truereturned()
        {
            // arrange
            Equation eq1 = new Equation();
            Equation eq2 = new Equation(0, 0, 0);
            bool expected = true;

            // act
            bool actual = eq1 == eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationEquality_NotEqualEquations_Falsereturned()
        {
            // arrange
            Equation eq1 = new Equation();
            Equation eq2 = new Equation(1, 0, 0);
            bool expected = false;

            // act
            bool actual = eq1 == eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationInequality_EqualEquations_Falsereturned()
        {
            // arrange
            Equation eq1 = new Equation();
            Equation eq2 = new Equation(eq1);
            bool expected = false;

            // act
            bool actual = eq1 != eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationMore_XNotExist_Falsereturned()
        {
            // arrange
            Equation eq1 = new Equation(0, 0, 1);
            Equation eq2 = new Equation(1, 0, 1);
            bool expected = false;

            // act
            bool actual = eq1 > eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationMore_X2NotExist_Truereturned()
        {
            // arrange
            Equation eq1 = new Equation(1, 2, 1);
            Equation eq2 = new Equation(1, 0, 1);
            bool expected = true;

            // act
            bool actual = eq1 > eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationMore_MaxX1EqualX2_Falsereturned()
        {
            // arrange
            Equation eq1 = new Equation(1, 2, 1);
            Equation eq2 = new Equation(1, -2, 1);
            bool expected = false;

            // act
            bool actual = eq1 > eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationMore_MaxX2MoreThanMaxX1_Falsereturned()
        {
            // arrange
            Equation eq1 = new Equation(1, -1, -6);
            Equation eq2 = new Equation(1, -1, -30);
            bool expected = false;

            // act
            bool actual = eq1 > eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationMore_MaxX1DoubleMaxValueMoreThanMaxX2A0_Truereturned()
        {
            // arrange
            Equation eq1 = new Equation();
            Equation eq2 = new Equation(0, 1, -30);
            bool expected = true;

            // act
            bool actual = eq1 > eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationMore_MaxX1A0MoreThanX2DoubleMaxValue_Falsereturned()
        {
            // arrange
            Equation eq1 = new Equation(0, 1, -6);
            Equation eq2 = new Equation();
            bool expected = false;

            // act
            bool actual = eq1 > eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationLess_XNotExist_Falsereturned()
        {
            // arrange
            Equation eq1 = new Equation(0, 0, 1);
            Equation eq2 = new Equation(1, 0, 1);
            bool expected = false;

            // act
            bool actual = eq1 < eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationLess_X1NotExist_Truereturned()
        {
            // arrange
            Equation eq2 = new Equation(1, 2, 1);
            Equation eq1 = new Equation(1, 0, 1);
            bool expected = true;

            // act
            bool actual = eq1 < eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationLess_MaxX1EqualX2_Falsereturned()
        {
            // arrange
            Equation eq1 = new Equation(1, 2, 1);
            Equation eq2 = new Equation(1, -2, 1);
            bool expected = false;

            // act
            bool actual = eq1 < eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationLess_MaxX1LessThanMaxX2_Falsereturned()
        {
            // arrange
            Equation eq2 = new Equation(1, -1, -6);
            Equation eq1 = new Equation(1, -1, -30);
            bool expected = false;

            // act
            bool actual = eq1 < eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationLess_X1DoubleMaxValueLessThanMaxX2A0_Falsereturned()
        {
            // arrange
            Equation eq1 = new Equation();
            Equation eq2 = new Equation(0, 1, -30);
            bool expected = false;

            // act
            bool actual = eq1 < eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationLess_MaxX1A0LessThanX2DoubleMaxValue_Truereturned()
        {
            // arrange
            Equation eq1 = new Equation(0, 1, -6);
            Equation eq2 = new Equation();
            bool expected = true;

            // act
            bool actual = eq1 < eq2;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaxAbsRoot_EmptyArray_Nullreturned()
        {
            // arrange
            EquationArray arr = new EquationArray();
            Equation expected = null;

            // act
            Equation actual = Program.FindMaxAbsRoot(arr);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FindMaxAbsRoot_RandomArray_Equationreturned()
        {
            // arrange
            EquationArray arr = new EquationArray(2, 5, -5);
            bool expected = true;

            // act
            Equation maxEquation = Program.FindMaxAbsRoot(arr);
            bool actual = arr.Equations.Contains(maxEquation);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationArrayCount_Constructors_Count4returned()
        {
            // arrange
            EquationArray arr1 = new EquationArray();
            EquationArray arr2 = new EquationArray(2, 5, -5);
            EquationArray arr3 = new EquationArray(arr1);
            int expected = 3;

            // act
            int actual = EquationArray.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationArrayIndex_GetInRange_Equationreturned()
        {
            // arrange
            EquationArray arr = new EquationArray(2, 5, -5);
            var expected = true;

            // act
            Equation eq0 = arr[0];
            var actual = arr.Equations.Contains(eq0);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationArrayIndex_GetOutOfRange_Exceptionreturned()
        {
            // arrange
            EquationArray arr = new EquationArray(2, 5, -5);
            var expected = false;

            // act
            var actual = true;
            try
            {
                Equation eq = arr[5];
            }
            catch (ArgumentOutOfRangeException)
            {
                actual = false;
            }

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EquationArrayIndex_SetInRange_Equationreturned()
        {
            // arrange
            EquationArray arr = new EquationArray(2, 5, -5);
            var expected = true;

            // act
            arr[0] = new Equation();
            var actual = (arr[0].A == 0 && arr[0].B == 0 && arr[0].C == 0);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
