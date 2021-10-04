using ef_scaffold.Entities;
using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_scaffold
{    
    public class UserInterface
    {
        public Service Service { get; set; }
        const string DIVISORE = "==============================================================";
        const string MAIN_MENU = @"Operazioni disponibili, inserisci:
                                    a per vedere tutti i corsi
                                    c per aggiungere un corso
                                    e per cercare le edizioni di un corso
                                    b per inserire un edizione di un corso
                                    r per creare un report
                                    d per cambiare memoria in uso
                                    q per terminare il programma";
        const string BASE_PROMPT = "=>";
        public UserInterface(Service s)
        {
            Service = s;
        }
        public void Start()
        {

            //Nuovo caso: l'utente inserisce l'id di un corso e il programma risponde mostrando il numero di edizioni che esistono del corso, la somma dei prezzi delle edizioni, il valore medio del prezzo odelle edizioni
            //la mediana del prezzo delle edizioni, la moda dei prezzi delle edizioni, numero max studenti e numero min studenti
            //OUTPUT => n-edizioni | somma prezzi | media prezzi | mediana prezzi | moda prezzi | n-max studenti | n-min studenti           
            bool quit = false;
            do
            {
                Console.WriteLine(DIVISORE);
                Console.WriteLine(MAIN_MENU);
                char c = ReadChar(BASE_PROMPT);
                switch (c)
                {
                    case 'a':
                        ShowCourses();
                        break;
                    case 'c':
                        CreateCourse();
                        break;
                    case 'b':
                        CreateCourseEdition();
                        break;
                    //case 'r':
                    //    GenerateReport();
                    //    break;
                    case 'e':
                        ShowCourseEditionsByCourse();
                        break;
                    case 'd':
                        ChangeRepo();
                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Comando non riconoscuto");
                        break;
                }
            }
            while (!quit);
        }

        private void ChangeRepo()
        {
            int x;
            do
            {
                string name = ReadString(@"Cambio memoria, inserire
                                    1. Database tramite entity framework
                                    2. Database tramite ADO
                                    3. Memoria interna della macchina
                                    =>");
                x = int.Parse(name);               
            } while (x < 0 & x > 4);
            Service.ChangeRepo(x);
        }

        private void ShowCourseEditionsByCourse()
        {
            long idCorso = ReadLong("Inserire Id del corso =>");
            IEnumerable<Edizioni> editions = Service.FindEditionsByIdCourse(idCorso);
            foreach(var item in editions)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void CreateCourseEdition()
        {
            Edizioni output;
            long idCorso = 0;
            long idAula = 0;
            long idFinanziatore = 0;

            idCorso = ReadLong("Inserire Id del corso =>");
            string code = ReadString("Inserire codice Edizione =>");
            LocalDate start = ReadLocalDate("Inserire data di inizio corso (yyyy-mm-dd) =>");
            LocalDate end = ReadLocalDate("Inserire data di fine corso (yyyy-mm-dd) =>");
            int numStudents = (int)ReadLong("Inserire numero studenti =>");
            decimal realPrice = ReadDecimal("Inserire prezzo finale edizione corso =>");
            idAula = ReadLong("Inserire Id dell'aula =>");
            idFinanziatore = ReadLong("Inserire Id del finanziatore =>");
            output = new Edizioni(0, code, idCorso, start, end, numStudents, realPrice, idAula, idFinanziatore);
            Service.CreateEdition(output);
        }

        private Corso CreateCourse()
        {
            //do{
            Corso c = null;
            long idLivello = 0;
            string titolo = ReadString("Inserire Titolo =>");
            string descrizione = ReadString("Inserire Descrizione =>");
            do
            {
                idLivello = ReadLong(@"Inserire Livello del corso: 1.PRINCIPIANTE
                                                                   2.MEDIO
                                                                   3.ESPERTO
                                                                   4.GURU =>");
            } while (idLivello > 5 || idLivello < 1);

            long idProgetto = 0;
            long idCategoria;
            idProgetto = ReadLong("Inserire l'Id del progetto =>");
            /* do 
             * {
             *      idProgetto = ReadLong("Inserire l'Id del progetto =>");
             * } while (!Service.ProjectExist(idProgetto))
            */

            idCategoria = ReadLong("Inserire l'Id della Categoria =>");
            /* do 
             * {
             *      idCategoria = ReadLong("Inserire l'Id della categoria =>");
             * } while (!Service.CategoryExist(idCategoria))
            */

            int durataCorso = (int)ReadLong("Inserire Durata del corso =>");
            decimal prezzoCorso = ReadDecimal("Inserire Prezzo corso =>");
            c = new Corso(0, titolo, durataCorso, prezzoCorso,
                    idLivello, idProgetto, idCategoria, descrizione);
            Console.WriteLine(DIVISORE);
            Service.CreateCourse(c);
            //} while (!Service.CategoryExist(idCategoria)&&!Service.ProjectExist(idProgetto))
            return c;
        }

        private void ShowCourses()
        {
            IEnumerable<Corso> courses = Service.GetAllCourses();
            foreach(var item in courses)
            {
                Console.WriteLine(item.ToString());
            }
        }


        private LocalDate ReadLocalDate(string prompt)
        {
            bool success = false;
            LocalDate date = new LocalDate(2021, 01, 01);
            do
            {
                string answer = ReadString(prompt);
                try
                {
                    success = TryParse(answer, out date);
                }
                catch (UnparsableValueException ex)
                {
                    success = false;
                    Console.WriteLine("Formato errato, inserire una data nel formato yyyy-MM-dd");
                }

            }
            while (!success);
            return date;
        }

        private bool TryParse(string input, out LocalDate date)
        {
            var pattern = LocalDatePattern.CreateWithInvariantCulture("yyyy-MM-dd"); // => DA GESTIRE
            var parseResult = pattern.Parse(input);
            date = parseResult.GetValueOrThrow();
            return true;
        }

        private string ReadString(string prompt)
        {
            string answer = null;
            do
            {
                Console.Write(prompt);
                answer = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine("Devi inserire almeno un carattere");
                }
            }
            while (string.IsNullOrEmpty(answer));
            return answer;
        }

        private char ReadChar(string prompt)
        {
            return ReadString(prompt)[0];
        }

        private long ReadLong(string prompt)
        {
            bool isNumber = false;
            long num;
            do
            {
                string answer = ReadString(prompt);
                isNumber = long.TryParse(answer, out num);
                if (!isNumber)
                {
                    Console.WriteLine("Devi inserire un numero =>");
                }
            }
            while (!isNumber);
            return num;
        }

        private decimal ReadDecimal(string prompt)
        {
            bool isNumber = false;
            decimal num;
            do
            {
                string answer = ReadString(prompt);
                isNumber = decimal.TryParse(answer, out num);
                if (!isNumber)
                {
                    Console.WriteLine("Devi inserire un numero =>");
                }
            }
            while (!isNumber);
            return num;
        }
    }
}

