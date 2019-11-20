using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using MicrowaveOvenClasses.Interfaces;
using MicrowaveOvenClasses.Boundary;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step3
    {
        private Output _output;
        private Display _display;
        private PowerTube _powerTube;
        private ITimer _timer;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void thatnogetsker()
        {
            //_sut.TurnOn();
            //Assert.That(_output.OutTextTest.Contains("Light is turned on"));
        }
    }
}
