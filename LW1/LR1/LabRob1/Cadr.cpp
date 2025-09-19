#include "Cadr.h"

Cadr::Cadr() :name(""), number(0), rozr(0) { cout << "����������� ����������� �� ������������� " << this<<endl; }

Cadr::Cadr(string n, int num, int r):
	name(n),
    number(num),
	rozr(r) 
{
	cout << "��������� ��������� ����������� "<< this << endl;
}

Cadr::Cadr(const Cadr& c) { 
	cout << "��������� ����������� ���i������" << this <<endl; 
	this->name = c.name;
	this->number = c.number;
	this->rozr = c.rozr;
}

Cadr::~Cadr(void) { cout << "��������� ����������" << this << endl; }

string Cadr::getName() {
	return name;
}

void Cadr::setName() {
	cout << "����i�� i�'� ����i�����: "; 
	cin >> name;
}

int Cadr::getNum() {
	return number;
}

void Cadr::setNum() {
	cout << "����i�� ����� ����: ";
	cin >> number;
}

int Cadr::getRozr() {
	return rozr;
}

void Cadr::setRozr() {
	cout << "����i�� ������: ";
	cin >> rozr;
}

void Cadr::SetCadr() {
	setName();
	setNum();
	setRozr();
}

void Cadr::PrintCadr() {
	cout << "I�'�: " << name << ", ������: " << rozr << ", ����� ����: " << number << endl;
}
