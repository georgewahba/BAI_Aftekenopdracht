using System;
using System.Collections.Generic;


namespace BAI
{
    public class BAI_Afteken1
    {
        private const string BASE27CIJFERS = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // ***************
        // * OPGAVE 1a/b *
            public static UInt64 Opg1aDecodeBase27(string base27getal)
        {
            // *** IMPLEMENTATION HERE *** //
            // veranderen van base 27 naar base 10
            // wat er hier gebeurd id dat ik 0 x 27 + index eerste letter doe,
            // daarna word die 0 vervangen door dat antwoord dus bijv bij BAI word de 2e stap
            // 2(2 is de index van B)  x 27 + 1 (1 is de index van A)
            UInt64 value = 0;
            foreach (var ch in base27getal)
            {
                int nummer = BASE27CIJFERS.IndexOf(ch);
                
                value = value * 27 +(UInt64)nummer;
            }
            
            return value;
        }
            
        public static string Opg1bEncodeBase27(UInt64 base10getal)
        {
            // *** IMPLEMENTATION HERE *** //
            //veranderen van base 10 naar string
            //wat er hier gebeurd is andersom
            //dat grote getal word gedeeld door 27 en dan mod 27 de rest daarvan is de index in BASE27CIJFERS
            //waarom een stack? omdat je achterstevoren werkt dus de eerste letter die in de stack gaat is de laatste letter van het woord
            
            if (base10getal == 0) return "-";

            var characters = new Stack<char>();
            UInt64 nummer = base10getal;
            while (nummer > 0)
            {
                UInt64 i = nummer / 27;
                int n = (int)(nummer % 27);
                characters.Push(BASE27CIJFERS[n]);
                nummer = i;
            }
            return new string(characters.ToArray());
        }

        // ***************
        // * OPGAVE 2a/b *
        // ***************
        public static Stack<UInt64> Opdr2aWoordStack(List<string> woorden)
        {
            // *** IMPLEMENTATION HERE *** //
            //omzetten vaar de lijst woorden naar nummer en pushen naar een stack
            //wat er hier gebeurd is
            //de lijst met woorden word met de functie van opdrachrt 1 omgezet naar base27 en dan in een stack gezet
            var stack = new Stack<UInt64>();
            foreach (var woord in woorden)
            {
                UInt64 nummer = Opg1aDecodeBase27(woord);
                stack.Push(nummer);
            }
            
            return stack;
        }
        public static Queue<string> Opdr2bKorteWoordenQueue(Stack<UInt64> woordstack)
        {
            // *** IMPLEMENTATION HERE *** //
            // woorden met minder dan 3 letters in een queue zetten
            // wat er hier gebeurd is
            // max woord word berekend dat is 27^3 dan is het woord zzz alles daarboven is meer dan 3 letters
            // in de loop worden de nummers opgehaald en vergeleken of het minder is dan 27 ^ 3, zo ja zet het in de queue
            var queue = new Queue<string>();
            const UInt64 maxwoord = 27 * 27 * 27;
            while (woordstack.Count > 0)
            {
                UInt64 nummer = woordstack.Pop();
                if (nummer < maxwoord)
                {
                    string woord = Opg1bEncodeBase27(nummer);
                    queue.Enqueue(woord);
                }
            }
            return queue;
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
