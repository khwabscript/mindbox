using System;

public class Program
{
	static string[] available_figures = new[]{"Треугольник", "длины трёх сторон", "3", "Круг", "радиус", "1"};
	public static void Main()
	{
		
		Console.Write("Площадь какой фигуры Вы хотите вычислить? (Доступные фигуры: ");
		int variants_of_figure = available_figures.Length;
		for(int j=0; j < variants_of_figure - 3; j=j+3) {
			Console.Write(available_figures[j] + ", ");
		}
		Console.Write(available_figures[variants_of_figure - 3] + ") ");
		string type = Console.ReadLine();
		int figure_index = Array.IndexOf(available_figures, type);
		if(figure_index == -1) {
			for(int k=0; k < variants_of_figure - 3; k=k+3) {
				Console.Write(Prompt(k));
				Console.Write(" если хотите узнать площадь " + available_figures[k] + "а или ");
			}
			Console.Write(Prompt(variants_of_figure - 3));
			Console.Write(", если хотите узнать площадь " + available_figures[variants_of_figure - 3] + "а");
		} else {
			Console.Write(Prompt(figure_index));
		}
		Console.Write(": ");
		double result = Area(type, ReadValue());
		if(result == -1) {
		Console.WriteLine("Неизвестная фигура");
		} else if(result == 0) {
		Console.WriteLine("Необходимо вводить длины сторон через запятую, например: 3,4,5");
		Main();
		} else {
		Console.WriteLine(result);
		}
	}
	public static double[] ReadValue() {
		string[] sides_str = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
		double[] sides = new double[sides_str.Length];
		try {
			for(int i = 0; i < sides_str.Length; ++i) {
				sides[i] = Convert.ToDouble(sides_str[i]);
				IsPositive(sides[i]);
			}
			return sides;
		}
		catch {
			Console.Write("Необходимо вводить параметры положительными числами. Пожалуйста, введите заново в правильном формате: ");
			return ReadValue();
		}
	}
	public static string Prompt(int figure_index) {
		string message = "Введите " + available_figures[figure_index + 1];
			if(Convert.ToInt32(available_figures[figure_index+2])>1) {
				return message + " через запятую";
			} else {
				return message;
			}
	}
	public static double IsPositive(double i) {
		if(i<0) {
			throw new ArgumentOutOfRangeException();
		} else {
			return i;
		}
	}
	public static double Area(string type = "", params double[] sides)
	{
		if(type == "Треугольник") {
		if(sides.Length == 3) {
			return TriangleArea(sides);
		} else {
			return 0;
		}
		} else if(type == "Круг") {
			return CircleArea(sides[0]);
		} else if(type == "") {
		if(sides.Length == 3) {
		return TriangleArea(sides);
		} else if(sides.Length == 1) {
		return CircleArea(sides[0]);
		} else {
		return -1;
		}
		} else {
		return -1;
		}
	}
	public static double TriangleArea(params double[] sides) {
		var a = sides[0];
		var b = sides[1];
		var c = sides[2];
		if(a + b <= c || a + c <= b || b + c <= a) {
			return 0;
		} else {
			var p = (a+b+c)/2;
			var S = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
			return S;
		}
	}
	public static double CircleArea(double radius) {
		return Math.PI*Math.Pow(radius,2);
	}
}