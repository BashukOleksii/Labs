		#include "List.h"

		Node* Register::head = nullptr;

		void Register::Add(Cadr* cadr) {

			Node* newNode = new Node(cadr);

			if (!head)
				head = newNode;
			else {

				Node* c = head;
				while (c->next)
					c = c->next;

				c->next = newNode;

			}
		}

		void Register::Delete() {

			if (!head)
				return;

			if (!head->next) {
				delete head->people;
				delete head;
				head = nullptr;
			}
			else {
				Node* c = head, * last = head->next;
				while (last->next) {
					c = last;
					last = last->next;
				}

				delete last->people;
				delete last;

				c->next = nullptr;
			}
		}

		void Register::Show() {

			if (!head)
				return;

			Node* c = head;

			while (c) {
				c->people->Print();
				c = c->next;
			}
		}



		bool Register::HasName(string name) {

			bool find = false;

			Node* c = head;

			while (c) {
				if (c->people->CompareName(name))
					find = true;
				c = c->next;
			}

			return find;

		}

		void Register::Find(string name)
		{
			if (!HasName(name)) {
				cout << "¬казаних елементiв не знайдено." << endl;
				return;
			}

			Node* c = head;

			while (c)
			{
				if (c->people->CompareName(name))
					c->people->Print();
				c = c->next;
			}
		}

		void Register::Clear()
		{
			while (head)
				Delete();

		}
