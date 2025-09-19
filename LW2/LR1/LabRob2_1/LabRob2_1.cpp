#include "Rectangle.h"

int main() {
	setlocale(0, "UKR");

	//Основні елементи
	Rectangle rect = Rectangle(5, 5);

	string r1STR = rect;

	cout << "Str = " << r1STR << endl;
	
	Rectangle::Show();
	cout << rect << "(Об'єкт rect - початкове значення)" << endl;
	cout << rect++ << "(rect++)" << endl;
	cout << rect-- << "(rect--)"<< endl;
	cout << ++rect << "(++rect)" << endl;
	cout << --rect << "(--rect)" <<  endl;

	cout << "rect*5: " << endl;
	Rectangle::Show();
	cout << rect * 5 << endl;

	cout << endl;

	cout << "Рядкове значення (r):" << endl;
	Rectangle r = r1STR;
	cout << "r квадрат? ";
	if (r)
		cout << "Квадрат" << endl;
	Rectangle::Show();
	cout << r << endl;

	Rectangle rectangle1 = r1STR;
	Rectangle rectangle2(10, 10);

	cout << endl;

	Rectangle::Show();
	cout << rectangle1 << " (rectngle1 початкове значення)" << endl;
	cout << rectangle2 << " (rectngle2 почакове значення)" << endl;

	cout << rectangle1 + rectangle2 << " (Сума двох прямокутникiв)"<<endl;
	cout  << 10 + rectangle1 << " (Число + прямокутник:)" << endl;
	cout  << rectangle1 + 10 << " (Прямокутник + число)" << endl;

	//Індексація та +=
	Rectangle rr;
	
	Rectangle::Show();

	cout << rr << "(пустий об'єкт rr)" << endl;
	cout << "Введiть значення для полiв Rectangle (Перша сторона, друга сторона): "; cin >> rr;
	cout << rr << "(Об'єкт rr піля введення)" << endl;
	(rr += 5)+=10;
	cout << rr << "Об'єкт rr пiсля операцiї (rr += 5)+=10" << endl;

	cout << "Доступ до полiв за iндексом: " << endl;
	cout << "rr[0] = " << rr[0] << endl;
	rr[0] = 10;
	cout << "rr[0] має дорiвнювати 10: " << rr[0] << endl;

	//Логіні операції
	Rectangle r1(10, 20), r2(5, 10);

	Rectangle::Show();
	cout << r1 << "(Об'єкт r1)" << endl;
	cout << r2 << "(Об'єкт r2)" << endl;

	bool a = r1 == r2;
	cout << "r1 == r2 " << a << endl;
	a = r1 >= r2;
	cout << "r1 >= r2 " << a << endl;
	a = r1 > r2;
	cout << "r1 > r2 " << a << endl;
	a = r1 <= r2;
	cout << "r1 <= r2 " << a << endl;
	a = r1 < r2;
	cout << "r1 < r2 " << a << endl;
	a = r1 != r2;
	cout << "r1 != r2 " << a << endl;

	// Перевизначені оператори потоку

	cout << "Створено масив об'єктiв:" << endl;
	Rectangle rectangles[5];

	for (int i = 0; i < 5; i++) {
		cout << "Введiть " << i + 1 << " прямокутник: ";
		cin >> rectangles[i];
	}

	Rectangle::Show();
	for (int i = 0; i < 5; i++)
		cout << rectangles[i] << endl;


}