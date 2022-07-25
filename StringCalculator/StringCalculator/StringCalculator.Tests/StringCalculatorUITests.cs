using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    public class StringCalculatorUITests
    {
        internal class ConsoleWrapperStub : IConsoleWrapper
        {
            private IList<ConsoleKey> _keyCollection;
            private int _keyIndex = 0;

            public ConsoleWrapperStub(IList<ConsoleKey> keyCollection)
            {
                _keyCollection = keyCollection;
            }

            public string Output { get; private set; }

            public ConsoleKeyInfo ReadKey()
            {
                var result = _keyCollection[_keyIndex];
                _keyIndex++;
                return new ConsoleKeyInfo((char)result, result, false, false, false);
            }

            public void WriteLine(string s)
            {
                Output += s;
            }

            public void WriteLine()
            {
                //throw new NotImplementedException();
            }
        }

        [Fact]
        public void EmptyInputReturnZero()
        {
            var stub = new ConsoleWrapperStub(new List<ConsoleKey> { ConsoleKey.E, ConsoleKey.Escape });
            var ui = new StringCalculatorUI(stub);

            ui.Run();

			Assert.Equal("Sum: 0", stub.Output);
		}

        [Fact]
        public void SingleNumberInputReturnNumber()
        {
            var stub = new ConsoleWrapperStub(new List<ConsoleKey> { ConsoleKey.D8, ConsoleKey.E, ConsoleKey.Escape });
            var ui = new StringCalculatorUI(stub);

            ui.Run();

            Assert.Equal("Sum: 8", stub.Output);
        }


        [Fact]
        public void CommaSeparatedNumbersInputReturnNumbersSum()
        {
            var stub = new ConsoleWrapperStub(new List<ConsoleKey> {
                ConsoleKey.D8, (ConsoleKey)44, ConsoleKey.D5, ConsoleKey.E, ConsoleKey.Escape
            });
            var ui = new StringCalculatorUI(stub);

            ui.Run();

            Assert.Equal("Sum: 13", stub.Output);
        }

    }
}
