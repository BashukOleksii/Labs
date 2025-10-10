#pragma once


#include "List.h"

Cadr::Cadr(string name, int enteredYear, string primarySkill, string education)
	:  record(enteredYear, primarySkill)
{
	this->name = name;
	this->education = education;
	Add();
}

Cadr::Cadr() : name("None"), education("None") {}

void Cadr::Add() {
	Register::Add(this);
}

void Cadr::Init() {
		SetName();
		record.Init();
		SetEducation();
}

void Cadr::Shapka() {

	PrintLine();

	cout << setw(16) << "Name |" << setw(20) << "Education |";
	cout << setw(4) << "Id |" << setw(14) << "Status |" << setw(5) << "Year |" << setw(30) << "PrimarySkill |";
	cout << setw(5) << "R |" << setw(8) << "CountW |";
	cout << setw(15) << "Spec |" << setw(8) << "CountP |";
	cout << setw(15) << "Position |" << setw(7) << "CountH" << endl;

	PrintLine();
}

void Cadr::Print() {
	cout << setw(14) << GetName() << " |" << setw(18) <<  GetEducation() << " |";
	record.Print();
}

void Cadr::SetName()
{
	cout << "Введiть iм'я: "; getline(cin, name);
}

void Cadr::SetEducation()
{
	cout << "Введiть, яка освiта: "; getline(cin, education);
}

int Cadr::GetWorkId()
{
	return record.GetId();
}

string Cadr::GetName()
{
	return name;
}

string Cadr::GetEducation()
{
	return education;
}

bool Cadr::CompareName(string name)
{
	return this->name == name;
}

void Cadr::NormalNum(int& num) {
	while (num < 0) {
		cin >> num;

		if (num < 0)
			cout << "Некоректно введенне значення." << endl;
	}
}

void Cadr::PrintLine()
{
	for (int i = 0; i < 148; i++)
		cout << "-";
	cout << endl;
}


