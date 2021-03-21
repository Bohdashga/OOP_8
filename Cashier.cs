using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_8
{
    public class Cashier
    {
        private List<CinemaHall> cinemaHalls;
        private List<Movie> movies;
        private List<Viewer> soldTickets;

        private FileController hallFile;
        private FileController moviesFile;

        public Cashier()
        {
            cinemaHalls = new List<CinemaHall>();
            movies = new List<Movie>();
            soldTickets = new List<Viewer>();

            hallFile = new FileController("cinema.txt");
            moviesFile = new FileController("movie.txt");

            readAll();

            MainMenu();

            writeAll();
        }

        public void MainMenu()
        {
            int menu = -1;

            while (menu != 0)
            {
                Console.Clear();
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Buy ticket");
                Console.WriteLine("2. Add movie");
                Console.WriteLine("3. Add cinema hall");
                Console.WriteLine("4. View cinema halls");
                Console.WriteLine("5. View Movies");
                Console.WriteLine("5. View Sold tickets");
                Console.Write("0. Exit\n\n > ");
                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        BuyTicket();
                        break;
                    case 2:

                        AddMovie();
                        break;
                    case 3:
                        AddCinemaHall();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Cinema halls:\n");
                        printList(new List<object>(cinemaHalls));
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Movies:\n");
                        printList(new List<object>(movies));
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Sold tickets:\n");
                        printList(new List<object>(soldTickets));
                        break;
                }

                Console.WriteLine("\n\nPress any key....");
                Console.ReadKey();
            }
        }

        public void BuyTicket()
        {
            Console.Clear();
            Console.WriteLine("Buying:\n");
            Console.Write("Choose film:\n\n ");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine((i) + ". " + movies[i] + "\n");
            }

            Console.Write(" > ");
            int select = Convert.ToInt32(Console.ReadLine());

            List<CinemaHall> cinemas = new List<CinemaHall>();

            for (int i = 0; i < cinemaHalls.Count; i++)
            {
                if (cinemaHalls[i].Movie.Name == movies[select].Name)
                {
                    cinemas.Add(cinemaHalls[i]);
                }
            }

            if (cinemas.Count != 0)
            {
                Console.WriteLine("\n\nChoose hall:\n");
                for (int i = 0; i < cinemas.Count; i++)
                {
                    Console.WriteLine((i) + ". " + cinemas[i].Name);
                }
                Console.Write("\n > ");
                select = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine(cinemas[select]);
                Console.Write("\n\nSelect seat > ");
                int seat = Convert.ToInt32(Console.ReadLine());

                cinemas[select].Seats[seat / 10, seat % 10] = true;

                Viewer viewer = new Viewer();
                viewer.Movie = cinemas[select].Movie.Name;

                soldTickets.Add(viewer);
            }
            else
            {
                Console.WriteLine("Cant find free hall");
            }
        }

        public void AddMovie()
        {

            Movie movie = new Movie();

            Console.Clear();
            Console.WriteLine("Adding movie:\n");

            Console.Write("Name > ");
            movie.Name = Console.ReadLine();

            Console.Write("Description > ");
            movie.Description = Console.ReadLine();

            Console.Write("Duration > ");
            movie.Duration = Convert.ToInt32(Console.ReadLine());

            Console.Write("Price > ");
            movie.Price = Convert.ToDouble(Console.ReadLine());

            movies.Add(movie);
        }

        public void AddCinemaHall()
        {
            CinemaHall hall = new CinemaHall();

            Console.Clear();
            Console.WriteLine("Adding hall:\n");

            Console.Write("Hall Name > ");
            hall.Name = Console.ReadLine();

            Console.WriteLine("Select Movie:\n");
            printList(new List<object>(movies));

            Console.Write("\n > ");
            int select = int.Parse(Console.ReadLine());

            hall.Movie = movies[select];

            cinemaHalls.Add(hall);
        }

        public static void printList(List<object> list)
        {
            int i = 0;
            foreach (var obj in list)
            {
                Console.WriteLine((i++) + ". " + obj + "\n");
            }
        }

        public void readAll()
        {
            string[] values = moviesFile.ReadFile();

            foreach (var value in values)
            {
                Movie movie = new Movie();
                movie.stringToObject(value);
                movies.Add(movie);
            }

            values = hallFile.ReadFile();

            foreach (var value in values)
            {
                CinemaHall hall = new CinemaHall();
                hall.stringToObject(value);
                cinemaHalls.Add(hall);
            }
        }

        public void writeAll()
        {
            moviesFile.WriteInFile(movies.ToArray());
            hallFile.WriteInFile(cinemaHalls.ToArray());
        }
    }
}
