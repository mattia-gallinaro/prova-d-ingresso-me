using System;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            double kwh = 0, smc = 0;
            int selezione = 0;
            bool controllo = false;
            Scelta scelta;
            do
            {
                Console.WriteLine("Inserisci i kwh che usi annualmente: ");
                string risposta = Console.ReadLine();//legge ció che l'utente scrive da tastiera
                controllo = Double.TryParse(risposta, out kwh);
            } while (!controllo || kwh < 0);//ripete se l'utente inserisce una stringa oppure un numero minore di 0

            do
            {
                Console.WriteLine("Inserisci gli smc che usi annualmente: ");
                string risposta = Console.ReadLine();//legge ció che l'utente scrive da tastiera
                controllo = Double.TryParse(risposta, out smc);//converte la stringa risposta in double e assegna il valore alla variabile smc e controllo ottiene valore true, sennó controllo ottiene valore false siccome non riesce a convertire risposta in smc
            } while (!controllo || kwh < 0);//ripete se l'utente inserisce una stringa oppure un numero minore di 0

            do
            {
                Console.WriteLine("Inserisci il numero del macchiario che utilizzi:\n" +
                    "1 per Caldaia a condensazione; \n" + "2 per Caldaia tradizionale;\n" + "3 per Stufa elettrica; \n" + "4 per Pompa di calore di buon livello;\n" + "5 per Pompa di calore economica;\n" + "Selezione: ");
                string risposta = Console.ReadLine();//legge ció che l'utente scrive da tastiera
                controllo = Int32.TryParse(risposta, out selezione);

            } while (!controllo || selezione > 5 || selezione < 1);

            scelta = new Scelta(kwh, smc, (selezione -1));//crea un istanza 
            string frase = scelta.Scelta_Macchinario();
            Console.WriteLine(frase);
            Console.WriteLine("Premi un tasto per uscire");
            Console.ReadKey();
        }
    }
}
