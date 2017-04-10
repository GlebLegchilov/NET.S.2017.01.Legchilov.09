using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService bookListService = new BookListService();
            bookListService.AddBook(new Book("Смок Беллью", "Джек Лондон", "ИФ \"LEAN\"", "Сначала он был Кристофер Беллью. В колледже он превратился в Криса Беллью. Позже..."));
            bookListService.AddBook(new Book("Книжный вор", "Маркус Зузак", "Эксмо", "Январь 1939 года. Германия. Страна, затаившая дыхание. Никогда еще у смерти не было столько работы..."));
            bookListService.AddBook(new Book("Повелитель мух", " Уильям Голдинг", "Астрель", "Светловолосый мальчик только что одолел последний спуск со скалы и теперь пробирался к лагуне..."));
            bookListService.AddBook(new Book("Три товапища", "Эрих Мария Ремарк", "Вагриус", " Небо было желтым, как латунь; его еще не закоптило дымом. За крышами фабрики оно светилось особенно сильно. Вот-вот должно было взойти солнце..."));
            bookListService.AddBook(new Book("Фиалки по средам", "Андре Моруа", "АСТ", "Лампы, освещавшие большую столовую, были затенены..."));
            bookListService.SortBookByTag(Book.BookTypeSearch.Author);
            bookListService.SaveData("bookList.txt");
            bookListService = new BookListService();
            bookListService.LoadData("bookList.txt");
            bookListService.AddBook(new Book("Стилист для снежного человека", "Дарья Донцова", "Эксмо", "Человек не способен лизнуть свой собственный локоть..."));
            Book toDelete = bookListService.FindBookByTag(Book.BookTypeSearch.Name, "Стилист для снежного человека");
            bookListService.RemoveBook(toDelete);
            bookListService.SortBookByTag(Book.BookTypeSearch.Text);
            bookListService.SaveData("bookList.txt");
            Console.WriteLine(bookListService.FindBookByTag(Book.BookTypeSearch.PublishingHouse, "АСТ").ToString());
            System.Console.ReadKey();
        }
    }
}
