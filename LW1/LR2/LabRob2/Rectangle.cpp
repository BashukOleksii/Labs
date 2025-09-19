#include "Rectangle.h"



void Rectangle::WhileNotNormal(double& num){

	while (num <= 0) {
		cout << "Невiрно задано сторону введiть знову: ";
		cin >> num;
	}
}

Rectangle::Rectangle(double a , double b ) {
	WhileNotNormal(a);
	WhileNotNormal(b);

	this->a = a;
	this->b = b;
}

Rectangle::Rectangle() { a = 0; b = 0;}






double Rectangle::P() const  {

	if (a == 0 || b == 0) {
		cout << "Недостатньо значень сторiн для периметру" << endl;
		return 0;
	}
	return 2*(a + b);
}

double Rectangle::S() const {
	if (a == 0 || b == 0) {
		cout << "Недостатньо значень сторiн для площi." << endl;
		return 0;
	}

	return a * b;
}





void Rectangle::setA() {
	cout << "Введiть сторону a: ";
	cin >> this->a;
	WhileNotNormal(a);
}

void Rectangle::setB() {
	cout << "Введiть сторону b: ";
	cin >> this->b;
	WhileNotNormal(b);
}

void Rectangle::setSizes() {
	this->setA();
	this->setB();
}





double Rectangle::getA() const{
	return a;
}

double Rectangle::getB() const{
	return b;
}

void Rectangle::getSizes() const{
	if (IsSquare())
		cout << "Квадрат\n";
	else
		cout << "Прямокуник\n";
	cout << "Довжина сторони a: " << getA() << ", дожина сторни b:" << getB() << endl;
	
}




bool Rectangle::IsSquare() const {
	if (a == 0 || b == 0) {
		cout << "Недостатньо значень сторiн для визначення того чи квадрат." << endl;
		return false;
	}

	return a == b;
}


Rectangle& Rectangle::operator++() {
	a += 1.0; b += 1.0;
	return *this;
}

Rectangle& Rectangle::operator--() {
	if (a > 1.0 && b > 1.0) {
		a -= 1; b -= 1;
	}
	return *this;
}

Rectangle Rectangle::operator++(int) {
	Rectangle temp = *this;
	a += 1;  b += 1;
	return temp;
}
Rectangle Rectangle::operator--(int) {
	Rectangle temp = *this;
	if (a > 1.0 && b > 1.0) {
		a -= 1; b -= 1;
	}
	return temp;
}

Rectangle::operator bool() const{ return a == b && a != 0; }

Rectangle Rectangle::operator*(int scalar) const {
	double x1 = a, x2 = b;

	if (scalar > 0) {
		x1 *= scalar;
		x2 *= scalar;
	}

	return Rectangle(x1, x2);
}

Rectangle::operator string() const {
	string num = to_string(a) + "|" + to_string(b);
	return num;
}

Rectangle Rectangle::operator+(const Rectangle& r2) const
{
	return Rectangle(a + r2.a, b + r2.b);
}

Rectangle Rectangle::operator+(int side) const
{
	return Rectangle(a + side, b + side);
}

Rectangle::Rectangle(const string& str) {
	int cPos = str.find("|");

	if (cPos != string::npos) {
		string num1 = str.substr(0, cPos);
		string num2 = str.substr(cPos + 1);

		a = stod(num1);
		b = stod(num2);
	}
	else
		a = b = 0;

}

Rectangle operator+(int side, const Rectangle& r2)
{
	return Rectangle(r2.a + side, r2.b + side);
}

ostream& operator<<(ostream& out, const Rectangle& r) {
	out << r.a << " , " << r.b;
	return out;
}




