using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Book
    {
        private Author author;
        private string title;
        private int pages;
        private double price;
        private bool available;

        
        //properties
        //automaticky jsem je vygeneroval z gettru a settru pres right click
        //public Author Author { get => author;
        //    set => this.author = value; }

        //public string Title { get => title;
        //    set => this.title = value; }

        //public int Pages { get => pages;
        //    set => this.pages = value; }

        //public double Price { get => price;
        //    set => this.price = value; }

        //public bool Available { get => available;
        //    set => this.available = value; }
        ////konstruktor
        public Book(Author author, string title, int pages, double price)
        {
            this.author = author;
            this.title = title;
            this.pages = pages;
            this.price = price;
        }

        public override string ToString() { return $" {author} - {title}"; }

        ////gettry
        public Author GetAuthor() { return author; }
        public string GetTitle() { return title; }
        public int GetPages() { return pages; }
        public double GetPrice() { return price; }
        public bool GetAvailable() { return available; }
        ////settry
        public void setAuthor(Author author) { this.author = author; }
        public void setTitle(string title) { this.title = title; }
        public void setPages(int pages) { this.pages = pages; }
        public void setPrice(double price) { this.price = price; }
        public void setAvailable(bool available) { this.available = available; }

    }

    class Author
    {
        //datove slozky
        private string firstName;
        private string lastName;
        private List<Book> authBooks;
        // List<Part> parts = new List<Part>();
        private DateTime dateOfBirth;

        //ctor
        public Author(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.SetFirstName(firstName);
            this.SetLastName(lastName);
            this.SetDateOfBirth(dateOfBirth);
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string value)
        {
            firstName = value;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string value)
        {
            lastName = value;
        }

        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }

        public void SetDateOfBirth(DateTime value)
        {
            dateOfBirth = value;
        }

        internal List<Book> GetBooks()
        {
            return authBooks;
        }

        internal void SetBooks(List<Book> value)
        {
            authBooks = value;
        }

        //properties
        //public string FirstName { get => firstName; set => firstName = value; }
        //public string LastName { get => lastName; set => lastName = value; }
        //public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        //internal List<Book> Books { get => authBooks; set => authBooks = value; }

        //verejne metody
        public void listBooks() {  foreach (Book item in GetBooks()) { Console.WriteLine(item); } }

        public override string ToString() {
            return $"{firstName} {lastName}";
        }
    }

    class Reader
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        //muselo se zde i vytvorit pomoci new
        private List<Book> myBooks= new List<Book>();

        public Reader()
        {

        }

        public Reader(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }

        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }

        public void SetDateOfBirth(DateTime value)
        {
            dateOfBirth = value;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string value)
        {
            firstName = value;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string value)
        {
            lastName = value;
        }

        internal List<Book> GetMyBooks()
        {
            return myBooks;
        }

        internal void SetMyBooks(List<Book> value)
        {
            myBooks = value;
        }

        //tohle se musi jeste poresit
        public void borrowBook(Book book) {
            
            
            book.setAvailable(false);
            myBooks.Add(book);
            
        }

        public void returnBook(Book book) {

            //pokud je kniha nedostupna smaze ji z pole vypujcenych u daneho ctenare

            book.setAvailable(true);
            myBooks.Remove(book);
        }

        public void listBorrowed() {
            if (myBooks != null)
            {


                Console.WriteLine($"Ctenar {firstName} {lastName} ma pucene:");

                foreach (Book item in myBooks)
                {
                    Console.WriteLine(item);
                }

            }
            else
            {
                Console.WriteLine($"Ctenar {firstName} {lastName} nema pucene nic.");
            }
        }


    }

    class Library
    {
        private List<Book> libBooks;



        public List<Book> GetBooks()
        {
            return libBooks;
        }
        
        public void SetBooks(List<Book> books)
        {
            this.libBooks = books;


        }

        public Library(List<Book> books)
        {
            this.libBooks = books;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void addBooks(Book book) {

            libBooks.Add(book);
            book.setAvailable(true);
        }

        public void listAvailable() {

            Console.WriteLine("Nerozpucovane knihy, tedy knihy skladem v knihovne: ");
            
            foreach (Book item in libBooks)
            {
                if ((item.GetAvailable()))
                {
                    Console.WriteLine(item);
                }

                
            }
        }
        public void listUnavailable() {
            Console.WriteLine("Rozpucovane knihy, tedy knihy nejsou nyni skladem v knihovne: ");

            foreach (Book item in libBooks)
            {
                if (!(item.GetAvailable()))
                {
                    Console.WriteLine(item);
                }


            }
        }
        public void listAll() {
            Console.WriteLine("Vsechny knihy v knihovne, pujcene i nepucene:");
            foreach (Book item in libBooks)
            {
                Console.WriteLine(item);
            }
        
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            // List < Book > petr = new List<Book>();
            Author autor1 = new Author("Juraj","Bednar", new DateTime(1980, 3, 21));
            Author autor2 = new Author("Dominik","Stroukal", new DateTime(1988, 7, 14));

            Book kniha1 = new Book(autor1, "Hackni sa",500, 800);
            Book kniha2 = new Book(autor1, "Velky restart",350, 620);
            Book kniha3 = new Book(autor2, "Bitcoin a jine penize",280, 400);
            Book kniha4 = new Book(autor2, "DarkWeb: Sex, Drogy a bitcoin",240, 300);

            Reader ctenar1 = new Reader("Petr", "Novak", new DateTime(1983, 3, 21));
            Reader ctenar2 = new Reader("Josef", "Kaplan", new DateTime(1982, 10, 21));

            List<Book> knihyVknihovne1 = new List<Book>();
            Library knihovna1 = new Library(knihyVknihovne1);

            //knihyVknihovne1.Add(kniha1);
            knihovna1.addBooks(kniha1);
            knihovna1.addBooks(new Book(autor2, "Ekonomicke bubliny", 180, 450));
            knihovna1.addBooks(kniha1);
            knihovna1.addBooks(kniha2);
            knihovna1.addBooks(kniha3);

            ctenar1.borrowBook(kniha1);
            ctenar1.borrowBook(kniha2);



            knihovna1.listAll();
            Console.WriteLine();

            knihovna1.listAvailable();
            Console.WriteLine();

            knihovna1.listUnavailable();
            Console.WriteLine();

            ctenar1.listBorrowed();
            
            Console.WriteLine();
            ctenar1.returnBook(kniha1);
            ctenar1.listBorrowed();


            Console.ReadLine();

        }
    }
}
