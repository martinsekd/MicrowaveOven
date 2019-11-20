using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using MicrowaveOvenClasses.Interfaces;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step3
    {
        private Output _output;
        private Display _display;
        private IPowerTube _powerTube;
        private ITimer _timer;
        private Button _button;
        private Door _door;
        private UserInterface _sut;

        [SetUp]
        public void SetUp()
        {
            _timer = Substitute.For<ITimer>();
            _powerTube = Substitute.For<IPowerTube>();
            _display = new Display(_output);
            _sut = new UserInterface();
        }

        [Test]
        public void Buttonspressed()
        {
            
            //_sut.TurnOn();
            //Assert.That(_output.OutTextTest.Contains("Light is turned on"));
        }
    }
}
