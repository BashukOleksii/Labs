#pragma once

#include "Edition.h"

class Book : public Edition	{
private:
	int year;
	string widowHood;

public:
	Book(string title, string authorSurname, int Year, string WidowHood) : Edition(title, authorSurname) {
		year = NormalNum(Year);
		widowHood = WidowHood;
		type = "Book";
	}
	Book() : year(0), widowHood("None") { type = "Book"; }

	void Publish() override{
		cout << " нигу надруковано." << endl;
	}
	void Print() override {
		Edition::Print();
		cout << setw(8) << year << " |" << setw(13) << widowHood << " |" << setw(10) << "|" << setw(15) << "|" << setw(15) << "|" << endl;
		Edition::ShowLine();
	}
	void Init() override {
		Edition::Init();
		cout << "¬ведiть рiк випуску книги: "; cin >> year; year = NormalNum(year); cin.ignore();
		cout << "¬ведiть видавництво: "; getline(cin, widowHood);
	}


	virtual ~Book(){}

};	