using System;
namespace TestNetTopoSuite
{
    public class TestFunctional
    {
        public static void Main1(string [] agrs)
        {
            Console.WriteLine("Test");
            Addition(10,30);

            Action<int, int> add = (a, b) =>
            {
                Console.WriteLine("Add1 :" + (a + b));
            };
            add(10, 20);

            Func<int, int, float> percetage = (marks, total)=> ((float)marks / total) * 100;

            float per = percetage(160, 200);

            Console.WriteLine("Percentage ::" + per);
        }

        static void Addition(int a, int b)
        {
            Console.WriteLine("Add :" + (a + b));
        }
    }
}
