using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_Calculator_OOPS
{
    public class Calculator
    {
        public int CurrentResult { get; private set; }

        public Calculator()
        {
            CurrentResult = 0;
        }

        public int Evaluate(string expression, bool isFirst)
        {
            string fullExpression = isFirst ? expression : $"{CurrentResult} {expression}";
            CurrentResult = Calculate(fullExpression);
            return CurrentResult;
        }

        private int Calculate(string exp)
        {
            int result = 0, currentnum = 0;
            char operation = '+';

            for (int i = 0; i < exp.Length; i++)
            {
                char ch = exp[i];

                if (char.IsDigit(ch))
                {
                    currentnum = currentnum * 10 + (ch - '0');
                }

                if ((!char.IsDigit(ch) && ch != ' ') || i == exp.Length - 1)
                {
                    switch (operation)
                    {
                        case '+':
                            result += currentnum;
                            break;
                        case '-':
                            result -= currentnum;
                            break;
                        case '*':
                            result *= currentnum;
                            break;
                        case '/':
                            if (currentnum == 0)
                                throw new DivideByZeroException("Division by zero.");
                            result /= currentnum;
                            break;
                    }

                    operation = ch;
                    currentnum = 0;
                }
            }

            return result;
        }
    }
}
