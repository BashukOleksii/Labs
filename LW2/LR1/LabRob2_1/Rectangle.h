#pragma once
#include <iostream>
#include <string>
#include <iomanip>

using namespace std;

class Rectangle
{
private:
	double a, b;

public:

	Rectangle();

	Rectangle(double a, double b);

	double P() const;
	double S() const;

	void setSizes();
	void setA();
	void setB();

	void getSizes() const;
	double getA() const;
	double getB() const;

	bool IsSquare() const;

	void WhileNotNormal(double& num);

	Rectangle& operator++();
	Rectangle& operator--();

	Rectangle operator++(int);
	Rectangle operator--(int);

	operator bool() const;

	Rectangle operator*(int scalar) const;

	operator string() const;

	Rectangle operator+(const Rectangle& r2) const;

	Rectangle operator+(int side) const;

	friend Rectangle operator+(int side, const Rectangle& r2);


	Rectangle(const string& str);

	friend ostream& operator<<(ostream& out, const Rectangle& r);
	static void Show();

	friend istream& operator>>(istream& in, Rectangle& r);

	double& operator[](int index);

	Rectangle& operator +=(double num);
	Rectangle& operator +=(int num);
	Rectangle& operator +=(const Rectangle& r);

	friend bool operator ==(const Rectangle& r1, const Rectangle& r2);
	friend bool operator >=(const Rectangle& r1, const Rectangle& r2);
	friend bool operator <=(const Rectangle& r1, const Rectangle& r2);
	friend bool operator >(const Rectangle& r1, const Rectangle& r2);
	friend bool operator <(const Rectangle& r1, const Rectangle& r2);
	friend bool operator !=(const Rectangle& r1, const Rectangle& r2);

	Rectangle& operator =(const Rectangle& r);

};
