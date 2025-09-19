using System;
using System.Collections.Generic;


namespace BAI
{
    public class BAI_Afteken1
    {
        private const string BASE27CIJFERS = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // ***************
        // * OPGAVE 1a/b *
        // ***************
        public static UInt64 Opg1aDecodeBase27(string base27getal)
        {
            // *** IMPLEMENTATION HERE *** //

            return 0;
        }
        public static string Opg1bEncodeBase27(UInt64 base10getal)
        {
            // *** IMPLEMENTATION HERE *** //

            return "";
        }

        // ***************
        // * OPGAVE 2a/b *
        // ***************
        public static Stack<UInt64> Opdr2aWoordStack(List<string> woorden)
        {
            // *** IMPLEMENTATION HERE *** //
            return null;
        }
        public static Queue<string> Opdr2bKorteWoordenQueue(Stack<UInt64> woordstack)
        {
            // *** IMPLEMENTATION HERE *** //
            return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1a : Decode base-27 ===");
            Console.WriteLine($"BAI    => {Opg1aDecodeBase27("BAI")}");         // 1494
            Console.WriteLine($"HBO-ICT => {Opg1aDecodeBase27("HBO-ICT")}");    // 3136040003
            Console.WriteLine($"BINGO  => {Opg1aDecodeBase27("BINGO")}");       // 1250439
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1b : Encode base-27 ===");
            Console.WriteLine($"1494       => {Opg1bEncodeBase27(1494)}");          // "BAI"
            Console.WriteLine($"3136040003 => {Opg1bEncodeBase27(3136040003)}");    // "HBO-ICT"
            Console.WriteLine($"1250439   => {Opg1bEncodeBase27(1250439)}");        // BINGO
            Console.WriteLine();

            Console.WriteLine("=== Opdracht 2 : Stack / Queue - korte woorden ===");
            string[] woordarray = {"CONCEPT", "OK", "BLAUW", "TOEN", "IS",
                "HBOICT", "GEEL", "DIT", "GOED", "NIEUW"};
            List<string> woorden = new List<string>(woordarray);
            Stack<UInt64> stack = Opdr2aWoordStack(woorden);
            Queue<string> queue = Opdr2bKorteWoordenQueue(stack);

            foreach (string kortwoord in queue)
            {
                Console.Write(kortwoord + " ");                             // Zou "DIT IS OK" moeten opleveren
            }
            Console.WriteLine();
        }
    }
}
