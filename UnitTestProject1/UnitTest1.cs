using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPLAssignment.shape;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           var formA= new Triangle();
            var a = formA.width;
            var b = formA.Y;
            var c = formA.CircleBase;
            var d = formA.CirclePer;

            formA.Savedvalues(5,3,1,4);
            bool test = false;
            if (a != formA.x && 0 != formA.y && c !=formA.CircleBase && d!=formA.CirclePer)
                test = true;
            Assert.IsTrue(test);


        }
    }
}
