using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GonzalesP2.Models;
using GonzalesP2.Controllers;
using System.Net;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void SomeTest()
        {
            // setup  for test 
            int compoundsPerYear = 80;
            int loanYears = 22;
            double interestRate = 7;
            double principle = 500000.00;
            InvestmentCalc testy = new InvestmentCalc(compoundsPerYear, loanYears, interestRate, principle);

            //results making sure the rate does not change from input
            double expected = 7;
            double actual = testy.Interest;

            //check
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SomeTest2()
        {
            // setup  for test 
            int compoundsPerYear = 80;
            int loanYears = 31;
            double interestRate = 7;
            double principle = 0;
            InvestmentCalc testy = new InvestmentCalc(compoundsPerYear, loanYears, interestRate, principle);

            //results expect future value to be 0.00 due to the fact principle is 0
            double expected = 0;
            double actual = testy.FutureValue;

            //check

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SomeTest3()
        {
            // setup for test  
            InvestmentCalc testy = new InvestmentCalc();
            testy.Interest = 5;
            testy.CompPerYr = 2;
            testy.Years = 30;
            testy.Principal = 500000.00;

            //results calculated and expected values from the internet calculator at "http://www.moneychimp.com/calculator///compound_interest_calculator.htm"
            double expected = 2199894.87;
            double actual = testy.FutureValue;
            //check to see if values are within 0.001 of eachother or "=" for a decimal
            Assert.IsTrue((expected - actual < 0.001));
         
        }


    }
}
