#pragma once
#include <iostream>
#include <string>


using namespace std;

class Rectangle
{
private:
	double a, b;

public:

	Rectangle();

	Rectangle(double a, double b );

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

};

