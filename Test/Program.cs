using System;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            //variabili iniziali
            double kwh = 0, smc = 0;
            int selezione = 0;
            bool controllo = false;
            Scelta scelta;
            do
            {
                Console.WriteLine("Inserisci i kwh che usi annualmente: ");
                string risposta = Console.ReadLine();//legge ció che l'utente scrive da tastiera
                controllo = Double.TryParse(risposta, out kwh);//converte la stringa risposta in double e assegna il valore alla variabile kWh e controllo ottiene valore true, sennó controllo ottiene valore false siccome non riesce a convertire risposta in double
            } while (!controllo || kwh < 0);//ripete se l'utente inserisce una stringa oppure un numero minore di 0

            do
            {
                Console.WriteLine("Inserisci gli smc che usi annualmente: ");
                string risposta = Console.ReadLine();//legge ció che l'utente scrive da tastiera
                controllo = Double.TryParse(risposta, out smc);//converte la stringa risposta in double e assegna il valore alla variabile smc e controllo ottiene valore true, sennó controllo ottiene valore false siccome non riesce a convertire risposta in double
            } while (!controllo || kwh < 0);//ripete se l'utente inserisce una stringa oppure un numero minore di 0

            do
            {
                Console.WriteLine("Inserisci il numero del macchiario che utilizzi:\n" +
                    "1 per Caldaia a condensazione; \n" + "2 per Caldaia tradizionale;\n" + "3 per Stufa elettrica; \n" + "4 per Pompa di calore di buon livello;\n" + "5 per Pompa di calore economica;\n" + "Selezione: ");
                string risposta = Console.ReadLine();//legge ció che l'utente scrive da tastiera
                controllo = Int32.TryParse(risposta, out selezione);//converte la stringa risposta in int e assegna il valore alla variabile selezione e controllo ottiene valore true, sennó controllo ottiene valore false siccome non riesce a convertire risposta in int

            } while (!controllo || selezione > 5 || selezione < 1);//ripete se l'utente inserisce una stringa oppure un numero minore non compreso tra 1 e 5

            scelta = new Scelta(kwh, smc, (selezione -1));//crea un istanza della classe scelta e passa le variabili kWh, Smc e selezione diminuito di 1 perché indicherá l'indice sulla lista dei macchinari 
            string frase = scelta.Scelta_Macchinario();//richiama la funzione Scelta_Macchinario che calcola la miglior opzione in 1, 3 e 5 anni e la stringa che ritorna la assegna a frase
            Console.WriteLine(frase);//scrive a schermo la stringa frase
            Console.WriteLine("Premi un tasto per uscire");
            Console.ReadKey();
        }
    }
}
