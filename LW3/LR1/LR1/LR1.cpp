#include "Edition.h"
#include "Book.h"
#include "Article.h"
#include "Resource.h"
#include "List.h"
#include <Windows.h>

int main() {
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	
	cout << "Створення об'єктiв абстрактного класу через конструктор та їхнє виведення: " << endl;

	Edition* book = new Book("Кобзар","Шевченко",2023,"Vivat");

	Edition* article = new Article("Майтер справи","Куц",1,"Всесвiт",2020);

	Edition* resouce = new Resource("Злочин","Куц","http://example.com","Опис злочину");

	Edition::Shap();
	book->Print();
	article->Print();
	resouce->Print();


	cout << "Реалiзацiя абстрактного метода книгою: "; book->Publish();
	cout << "Реалiзацiя абстрактного метода статтею: "; article->Publish();
	cout << "Реалiзацiя абстрактного метода ресурсом: "; resouce->Publish();

	cout << "Виведення елементiв за допомогою списку: " << endl;
	List::Add(book); List::Add(article); List::Add(resouce);
	List::Show();

	cout << "Створення та введення вручну 5 книг: "<< endl;

	Edition* books[5];

	for (int i = 0; i < 5; i++) {
		books[i] = new Book();
		books[i]->Init();
		List::Add(books[i]);
	}

	cout << "Список пiсля додавання:" << endl;
	List::Show();
	

	cout << "Пошук творiв автора:" << endl;
	cout << "Введiть автора для пошуку: ";
	string surname;
	getline(cin, surname);

	List::Find(surname);

	List::Clear();

}