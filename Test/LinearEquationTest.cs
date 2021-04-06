using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Trimailov;

namespace Test_Trimailov
{
    [TestClass]
    public class LinearEquationTest
    {
        [TestMethod]
        [ExpectedException(typeof(TrimailovException),
        "ќпределено, что такое уравнение не существует")]
        public void TestMethodSolve()
        {
            LinearEquation myLinearEquation = new LinearEquation();
            CollectionAssert.AreEqual(new List<float>() { 2f }, myLinearEquation.Solve(2, -4, 0));
            CollectionAssert.AreEqual(new List<float>() { -0.625f }, myLinearEquation.Solve(8, 5, 0));
            myLinearEquation.Solve(0, 1, 0);
        }
    }
}
