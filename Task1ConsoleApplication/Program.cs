using System;
using Task1;

namespace Task1ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            NLoggerAdapter logger = new NLoggerAdapter();
            BookListService bookListService = new BookListService(logger);
            bookListService.AddBook(new Book("Смок Беллью", "Джек Лондон", "ИФ \"LEAN\"", "Сначала он был Кристофер Беллью. В колледже он превратился в Криса Беллью. Позже..."));
            bookListService.AddBook(new Book("Книжный вор", "Маркус Зузак", "Эксмо", "Январь 1939 года. Германия. Страна, затаившая дыхание. Никогда еще у смерти не было столько работы..."));
            bookListService.AddBook(new Book("Повелитель мух", " Уильям Голдинг", "Астрель", "Светловолосый мальчик только что одолел последний спуск со скалы и теперь пробирался к лагуне..."));
            bookListService.AddBook(new Book("Три товапища", "Эрих Мария Ремарк", "Вагриус", " Небо было желтым, как латунь; его еще не закоптило дымом. За крышами фабрики оно светилось особенно сильно. Вот-вот должно было взойти солнце..."));
            bookListService.AddBook(new Book("Фиалки по средам", "Андре Моруа", "АСТ", "Лампы, освещавшие большую столовую, были затенены..."));
            bookListService.SortBookByTag(new BooksComparerByAuthor());
            BookListStorage binaryStorage = new BookListStorage();
            BinarySerializerStorage serializStrorage = new BinarySerializerStorage();
            XMLStorage xmlStorage = new XMLStorage();
            bookListService.SaveData(binaryStorage);
            bookListService.SaveData(serializStrorage);
            bookListService.SaveData(xmlStorage);
            bookListService = new BookListService(logger);
            bookListService.LoadData(binaryStorage);
            bookListService.LoadData(serializStrorage);
            bookListService.LoadData(xmlStorage);
            bookListService.AddBook(new Book("Стилист для снежного человека", "Дарья Донцова", "Эксмо", "Человек не способен лизнуть свой собственный локоть..."));
            Book toDelete = bookListService.FindBookByTag(new ComparableByName("Стилист для снежного человека"));
            bookListService.RemoveBook(toDelete);
            bookListService.SortBookByTag(new BooksComparerByText());
            bookListService.SaveData(binaryStorage);
            Console.WriteLine(bookListService.FindBookByTag(new ComparableByName("АСТ"))?.ToString());
            Console.ReadKey();
        }
    }
}
