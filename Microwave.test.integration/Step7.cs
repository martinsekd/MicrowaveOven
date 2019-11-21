using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microwave.test.integration
{
    [TestFixture]
    public class Step7
    {
        private StringWriter stringWriter;
        [SetUp]
        public void SetUp()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [Test]
        public void thatnogetsker()
        {
            Console.WriteLine("Boobies");
            Assert.That(stringWriter.ToString(), Is.EqualTo("Boobies\r\n"));
        }
    }
}
