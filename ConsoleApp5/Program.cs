using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
	interface IInteres	//реализация интерфейса
	{
		int Sum { get; set; }
		void Operation(int x, int y);
	}
	class Program
	{
		static void Main(string[] args)
		{
			Tovar printerr1 = new Printerr("Canon", 1000, "Принтер", "Цветной");
			Tovar printerr2 = new Printerr("Hp", 2000, "Принтер", "Цветной");
			Printerr printerr = printerr1 as Printerr;                              //идентификация типа объекта с помощью оператора as
			printerr.TypePrinter = "Ч/Б";											//Теперь возможно обращение

			Tovar scaner1 = new Scaner("Canon", 500, "Сканер");
			Tovar scaner2 = new Scaner("Hp", 700, "Сканер");

			Tovar computer1 = new Computer("Lenovo", 5000, "Ноутбук");
			Tovar computer2 = new Computer("Hp", 4000, "Ноутбук");

			Tovar planshet1 = new Planshet("Lenovo", 1500, "Планшет");
			Tovar planshet2 = new Planshet("Samsung", 1800, "Планшет");

			printerr1.Display();
			printerr2.Display();

			//iAmPrinting
			Interes interes = new Interes();
			Printer printer = new Printer();
			object printer1 = printer.iAmPrinting(interes);
			Console.WriteLine("Вызов метод iAmPrinting - " + printer);

			Console.ReadKey();
		}
	}
	abstract class Tovar					//абстрактный класс
	{
		public abstract void Display();     //абстрактный метод
		public string Name{ get; set; }
		public int Price{ get; set; }
		public Tovar(string name, int price)
		{
			if(name.Trim() != "" && price != 0 )
			{
				Name = name;
				Price = price;
			}
			else 
			{
				Console.WriteLine("Вы ввели некоректные данные");
			}
			
		}
		public override string ToString()
		{
			return "Тип объекта Name - " + Name.GetType() + ", его значение - " + Name;
		}
	}
	class Technology : Tovar		//наследование
	{
		public string TypeOfTechnology{ get; set; }
		public Technology(string name, int price, string type_of_technology) : base(name, price)
		{
			if(type_of_technology.Trim() != "")
			{
				TypeOfTechnology = type_of_technology;
			}	
		}
		public override void Display()
		{
			Console.WriteLine($"Имя - {Name}, цена - {Price}, тип техники - {TypeOfTechnology} .");
		}
		public override string ToString()
		{
			return "Тип объекта Name - " + Name.GetType() + ", его значение - " + Name;
		}
	}
	class Printerr : Technology
	{
		public string TypePrinter{ get; set; }
		public Printerr(string name, int price, string type_of_technology, string typePrinter) : base(name, price, type_of_technology)
		{
			TypePrinter = typePrinter;
		}
		public override string ToString()
		{
			return "Тип объекта Name - " + Name.GetType() + ", его значение - " + Name;
		}
		public override void Display()
		{
			Console.WriteLine($"Имя - {Name}, цена - {Price}, тип техники - {TypeOfTechnology}, тип принтера - {TypePrinter} .");
		}
	}
	class Scaner : Technology
	{
		public Scaner(string name, int price, string type_of_technology) : base(name, price, type_of_technology)
		{

		}
		public override string ToString()			//переопределение метода
		{
			return "Тип объекта Name - " + Name.GetType() + ", его значение - " + Name;
		}
		public override void Display()
		{
			Console.WriteLine($" Имя - {Name}, цена - {Price}, тип техники - {TypeOfTechnology} .");
		}
	}
	class Computer : Technology
	{
		public Computer(string name, int price, string type_of_technology) : base(name, price, type_of_technology)
		{

		}
		public override void Display()
		{
			Console.WriteLine($" Имя - {Name}, цена - {Price}, тип техники - {TypeOfTechnology} .");
		}
	}
	class Planshet : Technology
	{
		public Planshet(string name, int price, string type_of_technology) : base(name, price, type_of_technology)
		{

		}
		//Переопределение методов Object
		public override string ToString()
		{
			if (String.IsNullOrEmpty(Name))
				return base.ToString();
			return Name;
		}
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
		public override bool Equals(object obj)
		{
			if (obj.GetType() != this.GetType()) return false;

			Technology technology = (Technology)obj;
			return this.Name == technology.Name;
		}
		public override void Display()
		{
			Console.WriteLine($" Имя - {Name}, цена - {Price}, тип техники - {TypeOfTechnology} .");
		}
	}
	sealed class Interes : IInteres //бесплодный класс
	{
		public int Sum { get; set; }
		public void Operation(int x, int y)
		{
			Sum = x + y;
		}
		public int Operation(int x)
		{
			return ++x;
		}
		public override string ToString()
		{
			return "Тип объекта Sum - " + Sum.GetType() + ", его значение - " + Sum;
		}
	}
	class Printer
	{
		public object iAmPrinting(object x)
		{
			return "Тип объекта - " + x.GetType() + ", вызов метода ToString - " + x.ToString();
		}
	}
}
