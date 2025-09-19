#include "Cadr.h"

Cadr::Cadr() :name(""), number(0), rozr(0) { cout << "Використано конструктор за замовчуванням " << this<<endl; }

Cadr::Cadr(string n, int num, int r):
	name(n),
    number(num),
	rozr(r) 
{
	cout << "Викликано звичайний конструктор "<< this << endl;
}

Cadr::Cadr(const Cadr& c) { 
	cout << "Викликано конструктор копiювання" << this <<endl; 
	this->name = c.name;
	this->number = c.number;
	this->rozr = c.rozr;
}

Cadr::~Cadr(void) { cout << "Викликано деструктор" << this << endl; }

string Cadr::getName() {
	return name;
}

void Cadr::setName() {
	cout << "Введiть iм'я працiвника: "; 
	cin >> name;
}

int Cadr::getNum() {
	return number;
}

void Cadr::setNum() {
	cout << "Введiть номер цеху: ";
	cin >> number;
}

int Cadr::getRozr() {
	return rozr;
}

void Cadr::setRozr() {
	cout << "Введiть розряд: ";
	cin >> rozr;
}

void Cadr::SetCadr() {
	setName();
	setNum();
	setRozr();
}

void Cadr::PrintCadr() {
	cout << "Iм'я: " << name << ", розряд: " << rozr << ", номер цеху: " << number << endl;
}
