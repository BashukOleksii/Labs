	#pragma once

	#include <iostream>
	#include <string>
	#include <iomanip>


	using namespace std;

	class Edition {

	protected:
		string title;
		string authorSurname;
		string type;

	public:
		Edition(string Title, string AuthorSurname) : title(Title), authorSurname(AuthorSurname) {}
		Edition() : title("None"), authorSurname("None") {}

		virtual void Publish() = 0;

		virtual void Print() {
			cout << setw(13) << title << " |" << setw(13) << authorSurname << " |" << setw(13) << type << " |";
		}

		virtual void Init() {

			cout << "Введiть назву: "; getline(cin, title);
			cout << "Введiть автора: "; getline(cin, authorSurname);
		}

		static void Shap() {
			cout << setw(15) << "Title |" << setw(15) << "AuthorSurname |" << setw(15) << "Type |" << setw(10) << "Year |" << setw(15) << "WidowHood |" << setw(10) << "Number |" << setw(15) << "Name |" << setw(15) << "Ref |" << setw(15) << "Anotation" << endl;
			ShowLine();
		}

		bool IsFind(string Surname) { return authorSurname == Surname; }

		virtual ~Edition() {};

	protected:
		int NormalNum(int num) {
			while (num <= 0) {
				cout << "Невiрне числове значення: " << num << endl;
				cin >> num;
			}

			return num;
		}
		static void ShowLine() {
			for (int i = 0; i < 125; i++)
				cout << "-";
		cout << endl;
		}
	};