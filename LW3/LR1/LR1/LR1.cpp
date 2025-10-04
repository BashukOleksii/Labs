#include "Edition.h"
#include "Book.h"
#include "Article.h"
#include "Resource.h"
#include "List.h"

int main() {
	setlocale(0, "UKR");
	
	cout << "Створення та додавання до списку:" << endl;

	Edition* book = new Book("Book1","Author1",2025,"WidowHood1");

	Edition* article = new Article("Article1", "Author1",1, "Name1", 2025);

	Edition* resouce = new Resource("Resource1,", "Author3", "Ref", "Anotation");

	
	book->Shap();
	book->Print();
	article->Print();
	resouce->Print();
	List::Add(book); List::Add(article); List::Add(resouce);

	/*
	List::Show();

	cout << "Створення та введення вручну: "<< endl;

	Edition* books[5];

	for (int i = 0; i < 1; i++) {
		books[i] = new Book();
		books[i]->Init();
		List::Add(books[i]);
	}

	List::Show();
	*/

	cout << "Пошук творiв автора:" << endl;

	cout << "Введiть автора для пошуку: ";
	string surname;
	getline(cin, surname);

	List::Find(surname);


}