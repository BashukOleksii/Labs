	#pragma once

	#include "Edition.h"

	class Article: public Edition {
	private:
		int number;
		string magazineName;
		int year;

	public:
		Article(string title, string authorSurname,int Number, string Name, int Year) : Edition(title, authorSurname) {
			number = NormalNum(Number);
			magazineName = Name;
			year = NormalNum(Year);

			type = "Article";
		}

		Article() : year(0), number(0),magazineName("None") { type = "Article"; }

	
		void Publish() override {
			cout << "Статтю надруковано." << endl;
		}

		void Print() override {
			Edition::Print();
			cout<< setw(8) << year <<" |" << setw(15) << "|" << setw(8) << number <<" |" << setw(13) << magazineName << " |" << setw(15) << "|"  << endl;
			Edition::ShowLine();
		}

	
		void Init() override {
			Edition::Init();
			cout << "Введiть номер статтi: "; cin >> number; number = NormalNum(number);
			cout << "Введiть рiк випуску статті: "; cin >> year; year = NormalNum(year); 
			cin.ignore();
			cout << "Введiть назву статтi: "; getline(cin, magazineName);
		}
	
	

		virtual ~Article() {}
	};