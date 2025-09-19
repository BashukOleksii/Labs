#include "Rectangle.h"

int main() {
	setlocale(0, "UKR");
	
	//cout << "Виклик конструктора за замовчуванням\n";
	//Rectangle rectangle;
	//cout << "Значення площi: " << rectangle.S() << " та перимету: " << rectangle.P() << " в конструкторi за замовчуванням" << endl;
	//
	//cout << endl;

	//cout << "Виклик парамеризованого конструктора з помилкою:\n";
	//Rectangle rectangle1(10, -10);
	//cout << "Площа: " << rectangle1.S() << ", периметр: " << rectangle1.P() << endl;

	//cout << endl;

	//cout << "Використання гетерiв та сетерiв:\n";
	//Rectangle rectangle3;

	//rectangle3.setA();
	//rectangle3.setB();

	//cout << "GetA: " << rectangle3.getA() << ",GetB: " << rectangle3.getB() << endl;
	//cout << "GetSizes: \n"; rectangle3.getSizes();

	//cout << endl;

	//cout << "Робота з масивом:\n";

	//Rectangle* rectangles = new Rectangle[5];

	//for (int i = 0; i < 5; i++) {
	//	cout << i + 1 << " прямокутник: " << endl;
	//	rectangles[i].setSizes();
	//}

	//for (int i = 0; i < 5; i++) {
	//	cout << i + 1 << " прямокутник: " << endl;
	//	rectangles[i].getSizes();
	//}


	//delete[] rectangles;
	//rectangles = nullptr;
	//cout << endl;


	Rectangle r1 = Rectangle(5, 5);

	string r1STR = r1;

	cout << "Str = " << r1STR << endl;
	cout << "r1++ = " << r1++ << endl;
	cout << "r1-- = " << r1-- << endl;
	cout << "++r1 = " << ++r1 << endl;
	cout << "--r1 = " << --r1 << endl;

	cout << "r1*5 = " << r1 * 5 << endl;

	Rectangle r = r1STR;

	cout << r << endl;

	if (r)
		cout << "Квадрат" << endl;


	Rectangle rectangle1 = r1STR;
	Rectangle rectangle2(10, 10);
	
	cout << "Сума прямокутникiв: " << rectangle1 + rectangle2 << endl;
	cout << "Число + прямокутник:" << 10 + rectangle1 << endl;
	cout << "Прямокутник + число " << rectangle1 + 10 << endl;

}