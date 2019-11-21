using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step8
    {
        private PowerTube _powerTube;
        private IOutput _output;

        [SetUp]
        public void SetUp()
        {
            _powerTube = new PowerTube(_output);

            _output = new Output();

        }

        //[Test]
        //public void TurnOn_WasOff_CorrectOutput()
        //{
        //    //_powerTube.TurnOff();
        //    _powerTube.TurnOn(power:50);

        //    Assert.That(_output,Is.EqualTo("50 %"));
        //}
        //[Test]
        //public void TurnOff_WasOn_CorrectOutput()
        //{
        //    _powerTube.TurnOn(power: 50);
        //    _powerTube.TurnOff();

        //    Assert.That(_output, Is.EqualTo("PowerTube turned off"));
        //}
    }
}
