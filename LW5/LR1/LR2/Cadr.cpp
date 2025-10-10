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

void Cadr::Print() {
	cout << endl << endl << endl;
	PrintFatLine(false); cout << " ²ÍÔÎÐÌÀÖ²ß ÏÐÎ ÐÎÁ²ÒÍÈÊÀ "; PrintFatLine(true);
	cout << setw(30) << "²ì'ÿ" << setw(30) << GetName() << endl;
	cout << setw(30) << "Îñâ³òà" << setw(30) << GetEducation() << endl;
	record.Print();
}

void Cadr::SetName()
{
	cout << "Ââåäiòü iì'ÿ: "; getline(cin, name);
}

void Cadr::SetEducation()
{
	cout << "Ââåäiòü, ÿêà îñâiòà: "; getline(cin, education);
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
			cout << "Íåêîðåêòíî ââåäåííå çíà÷åííÿ." << endl;
	}
}

void Cadr::PrintFatLine(bool endl)
{
	for (int i = 0; i < 25; i++)
		cout << "=";

	if (endl)
		cout << "\n";
}


