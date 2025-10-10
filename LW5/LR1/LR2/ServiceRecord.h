	#pragma once
	#include <iostream>
	#include <string>
	#include <iomanip>

	using namespace std;
	enum Status{
		Work,
		OnLeave
	};

	class SRecord {
	private:
		static int NextId;

		int id;
		int hireYear;
		string primarySkill;
		Status status;

	public: 
		SRecord(int _hireYear, string _primarySkill):hireYear(_hireYear), primarySkill(_primarySkill) {
			id = NextId++;
			status = Status::Work;
			CheckYear();
		}

		SRecord(): id(0), hireYear(0), primarySkill("None"), status(Status::OnLeave) {}


		void Print() {
			ShortLine(false); cout << " Запис  про  працівника "; ShortLine(true);
			cout << setw(30) << "Ідентифікаційний номер" << setw(30)<< GetId() << endl;
			cout << setw(30) << "Статус працівника" << setw(30) << GetStatus() << endl;;
			cout << setw(30) << "Рік найму на роботу" << setw(30) << GetHireYear() << endl;
			cout << setw(30) << "Головна діяльність" << setw(30) << GetPrimarySkill() << endl;
		}

		void Init() {
		
			if (!id)
				id = NextId++;

			SetStatus();
			SetHireYear();
			cin.ignore();
			SetPrimarySkill();
		}

		int GetId() {
			return id;
		}
		string GetStatus() {
			switch (status)
			{
			case Work: return "Працює";
				break;
			case OnLeave:return "Не працює";
				break;
			}
		}
		int GetHireYear() {
			return hireYear;
		}
		string GetPrimarySkill() {
			return primarySkill;
		}

		void SetHireYear() {
			cout << "Введіть рік найму на роботу: "; 
			cin >> hireYear;
			CheckYear();
		}
		void SetStatus() {
			cout << "Введіть статус (0 - не працює, інша цифра - працює)";
			short ans;cin >> ans;

			if (ans)
				status = Status::Work;
			else
				status = Status::OnLeave;

		}
		void SetPrimarySkill() {
			cout << "Введіть головний напрям роботи: "; getline(cin, primarySkill);
		}
		void ShortLine(bool endl) {
			for (int i = 0; i < 25; i++)
				cout << "-";

			if (endl)
				cout << "\n";
		}


	private:
		void CheckYear() {
			while (hireYear < 1920) {
				cout << "Введено невірний рік, введіть знову: "; cin >> hireYear;
			}
		}
	
	};
