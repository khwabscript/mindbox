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
			Console.Write(", если хотите узнать площадь " + available_figures[variants_of_figure - 3] + "а: ");
			double[] sides = ReadValue();
			int sides_length = sides.Length;
			int has_figure = Array.IndexOf(available_figures, sides_length.ToString());
			if(has_figure != -1) {
				Console.Write(PrintResult(Area(sides_length, sides)));
			} else {
				Console.Write("Мы не можем вычислить площадь фигуры с числом параметров: " + sides_length + ". ");
				Main();
			}
		} else {
			Console.Write(Prompt(figure_index) + ": ");
			//double[] sides = ReadValue();
			Console.Write(IsWrongInput(figure_index));
		}
	}
	public static string PrintResult(double S) {
		if(S==0) {
			return "Фигуры с такими параметрами не существует!";
		} else {
			return "Площадь равна: " + S;
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
	public static string IsWrongInput(int figure_index) {
		double[] sides = ReadValue();
		int sides_length = sides.Length;
		int need_sides_length = Convert.ToInt32(available_figures[figure_index+2]);
		if(sides_length == need_sides_length) {
			return PrintResult(Area(sides_length, sides));
		} else {
			Console.Write(Prompt(figure_index) + ", отделяя дробную часть точкой. Например: ");
			for(int l=0; l < need_sides_length - 1; ++l) {
				Console.Write(l+"."+(l+1)+", ");
			}
			Console.Write("2.5 ");
			return IsWrongInput(figure_index);
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
	public static double Area(int sides_length, double[] sides) {
		if(sides_length==3) {
			return TriangleArea(sides);
		} else if(sides_length==1) {
			return CircleArea(sides[0]);
		} else {
			return 0;
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
