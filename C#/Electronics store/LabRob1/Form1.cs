using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabRob1
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1;

        List<Appliances> list;
        string filter = "Binary file (*.BIN)|*.BIN";

        CheckBox[] chk;
        Control[] textBoxes;

        public Form1()
        {
            InitializeComponent();


            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Ім'я", typeof(string));
            dt.Columns.Add("Бренд", typeof(string));
            dt.Columns.Add("Ціна", typeof(double));
            dt.Columns.Add("Рік випуску", typeof(int));
            dt.Columns.Add("Тип спожвання", typeof(string));
            dt.Columns.Add("Потужність", typeof(int));
            dt.Columns.Add("Витратність (на год.)", typeof(double));

            dt1 = dt.Copy();

            dataGridView1.DataSource = dt;

            list = new List<Appliances>();

            saveFileDialog1.Filter = filter;
            saveFileDialog1.Title = "Збереження в бінарний файл";

            openFileDialog1.Filter = filter;
            openFileDialog1.Title = "Відкриття бінарного файлу";

            chk = new CheckBox[] { checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15 };
            textBoxes = new Control[] { textBox19, textBox25, textBox24, textBox22, textBox21, comboBox13, textBox20 };
        }


        // Створення
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (IsEmpty(textBox10) || IsEmpty(textBox8) || IsEmpty(textBox9) || IsEmpty(textBox11) || IsEmpty(textBox12) || IsEmpty(textBox23) || IsEmpty(comboBox11))
                return;

            list.Add(new Appliances(textBox10.Text, textBox8.Text, textBox9.Text, double.Parse(textBox11.Text), short.Parse(textBox12.Text), comboBox11.Text, short.Parse(textBox23.Text)));

        }



        // Введення в поле
        private void comboBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == ',' && !textBox11.Text.Contains(',') && textBox11.SelectionStart != 0)
                return;

            e.Handled = true;

        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;

            e.Handled = true;
        }





        private bool IsEmpty(Control t)
        {
            if (string.IsNullOrEmpty(t.Text))
            {
                t.Focus();
                return true;
            }
            return false;
        }

        private void AddToTable(Appliances a)
        {
            dt.Rows.Add(a.Id, a.Name, a.Brand, a.Price, a.Year, a.EnergyClass, a.Power, a.EnergyCost);
        }

        private void UpdateDataGridView()
        {
            dt.Clear();
            foreach (Appliances a in list)
                AddToTable(a);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }

        // Знижка
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                if (row.Index < list.Count)
                    list[row.Index].Discount();

            UpdateDataGridView();
        }

        private void вивестиМасивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void Clear(params Control[] controls)
        {
            foreach (Control c in controls)
                c.Text = "";
        }





        // Збереженн  - читання
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Count > 0 && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = saveFileDialog1.FileName;

                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    using (BinaryWriter br = new BinaryWriter(fs))
                    {
                        foreach (Appliances a in list)
                        {
                            br.Write(a.Id);
                            br.Write(a.Name);
                            br.Write(a.Brand);
                            br.Write(a.Price);
                            br.Write(a.Year);
                            br.Write(a.EnergyClass);
                            br.Write(a.Power);
                        }
                    }
                }
                catch { MessageBox.Show("Помилка запису в файл", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = openFileDialog1.FileName;
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        list.Clear();
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            string id = br.ReadString();
                            string name = br.ReadString();
                            string brand = br.ReadString();
                            double price = br.ReadDouble();
                            short year = br.ReadInt16();
                            string type = br.ReadString();
                            short power = br.ReadInt16();


                            list.Add(new Appliances(id, name, brand, price, year, type, power));

                        }
                    }

                }
                catch { MessageBox.Show("Помилка читання файлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                UpdateDataGridView();
            }
        }







        // Виделення
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= list.Count)
                return;

            textBox13.Text = list[index].Id;
            textBox18.Text = list[index].Name;
            textBox17.Text = list[index].Brand;
            textBox16.Text = list[index].Price.ToString();
            textBox15.Text = list[index].Year.ToString();
            comboBox12.Text = list[index].EnergyClass;
            textBox14.Text = list[index].Power.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            List<Appliances> delete = new List<Appliances>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            { 
                int index = row.Index;
                if (index >= 0 && index < list.Count)
                    if (MessageBox.Show($"Видаляти {list[index].Name} {list[index].Brand} {list[index].Year}?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        delete.Add(list[index]);
            }

            foreach (Appliances a in delete)
                list.Remove(a);

            Clear(textBox18, textBox17, textBox16, textBox15, textBox14, textBox13, comboBox12);
            UpdateDataGridView();
        }

        // Поява/зникнення другої таблиці
        private void tabControl2_TabIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            string text = tabControl.SelectedTab.Text;

            if (text == "Пошук")
            {
                dataGridView2.Visible = true;
                label39.Visible = true;
                dataGridView1.Height = 230;
            }
            else
            {
                dataGridView1.Height = 470;
                dataGridView2.Visible = false;
                label39.Visible = false;
            }

        }

        // Пошук
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bool any = false;

            foreach (CheckBox c in chk)
                any |= c.Checked;

            if (!any)
                return;

            dt1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                bool find = true;

                for (int i = 0; i < chk.Length; i++)
                {
                    if (chk[i].Checked)
                        if (textBoxes[i].Text != row[i].ToString())
                        {
                            find = false;
                            break;
                        }
                }

                if (find)
                    dt1.Rows.Add(row.ItemArray);
            }

            if(dt1.Rows.Count == 0)
            {
                MessageBox.Show("Елементів не знайдено.", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView2.DataSource = dt1;


        }

        // Конструктор зазамовчуванням
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            list.Add(new Appliances());
        }

        private void toolStripButton8_MouseHover(object sender, EventArgs e)
        {
            textBox30.Clear();
            textBox30.Text = "Кнопка \"Арифметичні\"" + Environment.NewLine + "Виберіть рядок/рядки таблиці," + Environment.NewLine + "Введіть число в поле та натисніть кнопку для виконання дії позначеної зліва від полів," + Environment.NewLine + "Можна використовувати декілька полів та виконати арифметичні операції.";
        }

        private void toolStripButton9_MouseHover(object sender, EventArgs e)
        {
            textBox30.Clear();
            textBox30.Text = "Кнопка \"Пошук\"" + Environment.NewLine + "Виберіть рядок таблиці" + Environment.NewLine + "Натисніть кнопку," + Environment.NewLine + "Вам буде показано список всіх товарів із ціною вибраного," + Environment.NewLine + "(Якщо вирати декілька рядків, то будуть виведені товари, які входять в перелік цін вибраних товарів)";
        }

        private void toolStripButton10_MouseHover(object sender, EventArgs e)
        {
            textBox30.Clear();
            textBox30.Text = "Кнопка \"Перевірка\"" + Environment.NewLine + "Виберіть рядок таблиці," + Environment.NewLine + "Натисніть на кнопку," + Environment.NewLine + "В результаті ви маєте отримати повідомлення про те чи товар поточного року випуску." + Environment.NewLine + "(Можна виділити декілька об'єктів, тобі вам потрібно буде вибрати перевірку чи всі об'єкти поточного року, чи хоча б один із вибраного).";
        }
    }

}
