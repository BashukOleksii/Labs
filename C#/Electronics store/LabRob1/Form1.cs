using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LabRob1
{
    public partial class Form1 : Form
    {
        ApplianceService applianceService;
        DataTable dt = new DataTable();
        DataTable dt1;

        List<Appliances> list;
        string filter = "Binary file (*.BIN)|*.BIN";

        CheckBox[] chk;
        Control[] textBoxes;

        public Form1()
        {
            InitializeComponent();

            InitialTable();

            applianceService = new ApplianceService();

            list = new List<Appliances>();

            saveFileDialog1.Filter = filter;
            saveFileDialog1.Title = "Збереження в бінарний файл";
            saveFileDialog1.FileName = "Збережений файл";

            openFileDialog1.Filter = filter;
            openFileDialog1.Title = "Відкриття бінарного файлу";
            openFileDialog1.FileName = "Збережений файл";

            chk = new CheckBox[] { checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15,checkBox22, checkBox20, checkBox21, checkBox18, checkBox19, checkBox16,checkBox17 };
            textBoxes = new Control[] { textBox19, textBox25, textBox24, textBox22, textBox21, comboBox13, textBox20,textBox43, textBox38, comboBox17, textBox37, textBox36, textBox35,comboBox16 };
        }


        // Встановлення стовпців таблиці
        private void InitialTable()
        {
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Ім'я", typeof(string));
            dt.Columns.Add("Бренд", typeof(string));
            dt.Columns.Add("Ціна", typeof(double));
            dt.Columns.Add("Рік випуску", typeof(short));
            dt.Columns.Add("Тип спожвання", typeof(string));
            dt.Columns.Add("Потужність", typeof(short));
            dt.Columns.Add("Витратність (на год.)", typeof(double));

            dt.Columns.Add("Діаметр тарілки", typeof(double));
            dt.Columns.Add("Наявність грилю", typeof(string));

            dt.Columns.Add("Обертів на хвилину", typeof(short));
            dt.Columns.Add("Максимальна вага", typeof(double));

            dt.Columns.Add("Тип пилососу", typeof(string));
            dt.Columns.Add("Наявність щітки", typeof(string));

            dt1 = dt.Copy();

            dataGridView1.DataSource = dt;
        }







        // Створення
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            int ind = toolStripComboBox1.SelectedIndex;
            if (ind == -1)
                return;


            if (IsEmpty(textBox10) || IsEmpty(textBox8) || IsEmpty(textBox9) || IsEmpty(textBox11) || IsEmpty(textBox12) || IsEmpty(textBox23) || IsEmpty(comboBox11))
                 return;
            if(ind == 0)
            {
                if (IsEmpty(textBox31) || IsEmpty(comboBox14))
                    return;
                list.Add(new Microwave(textBox10.Text, textBox8.Text, textBox9.Text, double.Parse(textBox11.Text), short.Parse(textBox12.Text), comboBox11.Text, short.Parse(textBox23.Text),double.Parse(textBox31.Text),comboBox14.Text));
            }
            else if (ind == 2)
            {
                if (IsEmpty(comboBox20) || IsEmpty(comboBox15))
                    return;
                list.Add(new Cleaner(textBox10.Text, textBox8.Text, textBox9.Text, double.Parse(textBox11.Text), short.Parse(textBox12.Text), comboBox11.Text, short.Parse(textBox23.Text), comboBox20.Text, comboBox15.Text));
            }
            else if (ind == 1)
            {
                if (IsEmpty(textBox33) || IsEmpty(textBox34))
                    return;
                list.Add(new WashingMashine(textBox10.Text, textBox8.Text, textBox9.Text, double.Parse(textBox11.Text), short.Parse(textBox12.Text), comboBox11.Text, short.Parse(textBox23.Text), short.Parse(textBox33.Text), double.Parse(textBox34.Text)));
            }
        }










        // Введення в поле
        private void comboBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == ',' && !textBox.Text.Contains(',') && textBox.SelectionStart != 0)
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






        private void AddToTable(DataTable t, Appliances a)
        {
           DataRow dRow = t.NewRow();
           a.FillDataRow(dRow);
           t.Rows.Add(dRow);
        }

        private void UpdateDataGridView1()
        {
            dt.Clear();
              foreach (Appliances a in list)
                     AddToTable(dt,a);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }








        // Знижка
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    list[row.Index].Discount();

            UpdateDataGridView1();
        }





        private void вивестиМасивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridView1();
        }

        private void Clear(params Control[] controls)
        {
            foreach (Control c in controls)
                c.Text = "";
        }









        // Збереженн  - читання
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Count > 0)
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                     applianceService.SaveToFile(saveFileDialog1.FileName, list);
            else
                MessageBox.Show("Список для збереження пустий", "Поилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                list = applianceService.LoadFromFile(openFileDialog1.FileName);
                UpdateDataGridView1();
            }
        }










        // Видалення
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index <0)
                return;
            list[index].ImagesWhenDelete(this);
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
            UpdateDataGridView1();
        }







        // Поява/зникнення другої таблиці
        private void tabControl2_TabIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            string text = tabControl.SelectedTab.Text;

            if (text == "Пошук")
                smallSize();
            else
                bigSize();
            

            toolStripButton11.Visible = false;

        }





        // Розміри вікна

        public void smallSize()
        {
            dataGridView2.Visible = true;
            label39.Visible = true;
            dataGridView1.Height = 230;
        }
        public void bigSize()
        {
            dataGridView1.Height = 470;
            dataGridView2.Visible = false;
            label39.Visible = false;
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




        //Конструктор зазамовчуванням
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            int ind = toolStripComboBox1.SelectedIndex;
            if(ind == 0)
                list.Add(new Microwave());
            if(ind == 1)
                list.Add(new WashingMashine());
            if(ind == 2)
                list.Add(new Cleaner());
        }




        // Текстове повідомлення
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

        private void toolStripButton11_MouseHover(object sender, EventArgs e)
        {
            textBox30.Text = "Кнопка \"Сховати\"" + Environment.NewLine + "При відображенні таблиці з результатами може виникнути потреба приховати її," + Environment.NewLine + "Якщо в вас з'явилась така потреба, можна натиснути на цю кнопку.";
        }
        private void toolStripButton12_MouseHover(object sender, EventArgs e)
        {
            textBox30.Text = "Кнопка \"Найдорожчі\"" + Environment.NewLine + "Вам необхідно виділити рядки, які вас цікавлять," + Environment.NewLine + "потім натиснути кноку і ви отримаєте список товарів із нійбільшою ціною.";
        }





        // Арфметичні операції
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            double add = -1, div = -1, sub = -1, mul = -1;

            if (!IsEmpty(textBox26))
                add = double.Parse(textBox26.Text);
            if (!IsEmpty(textBox27))
                sub = double.Parse(textBox27.Text);
            if(!IsEmpty(textBox28))
                mul = double.Parse(textBox28.Text);
            if(!IsEmpty(textBox29))
                div = double.Parse(textBox29.Text);

            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int index = row.Index;

                if(mul >= 0)
                    list[index] *= mul;
                if(div > 0)
                    list[index] /= div;
                if(add > 0)
                    list[index] += add;
                if(sub > 0 && sub <= list[index].Price)
                    list[index] -= sub;
               
            }

            UpdateDataGridView1();


        }




       // Однакової ціни
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            dt1.Clear();
            List <Appliances> find = new List<Appliances>();
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            smallSize();
            toolStripButton11.Visible = true;

            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int index = row.Index;

                find.Add(list[index]);
            }

            deleteFromList(find);

            foreach(Appliances a in list)
                foreach(Appliances b in find)
                    if (a == b)
                        AddToTable(dt1, a);

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dt1;
        }

        private void deleteFromList(List <Appliances> l)
        {
            for(int i = 0; i < l.Count - 1; i++)
                for (int j = i +1; j  < l.Count; j++)
                    if (l[i] == l[j])
                    {
                        l.RemoveAt(j);
                        j--;
                    }
                
        }




        // Поточного року
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            bigSize();
            toolStripButton11.Visible = false;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;

            if (count == 0)
                return;

            int index = dataGridView1.SelectedRows[0].Index;
            if (count == 1 && index < list.Count && index >= 0) 
                if (list[index])
                    MessageBox.Show("Вибраний товар поточного року випуску.", "Порівняння", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Вибраний товар не поточного року випуску.", "Порівняння", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBoxMy messageBoxMy = new MessageBoxMy();
                DialogResult dr = messageBoxMy.ShowDialog();

                if (dr != DialogResult.Cancel)
                {
                    dt1.Clear();
                    smallSize();
                    toolStripButton11.Visible = true;

                    bool one = false, all = true;

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++) 
                    {
                        int indexRow = dataGridView1.SelectedRows[i].Index;
                        if (indexRow < 0)
                            continue;

                        if (list[indexRow])
                        {
                            AddToTable(dt1, list[indexRow]);
                        }
                        if (i < dataGridView1.SelectedRows.Count - 1)
                        {
                            if (list[dataGridView1.SelectedRows[i].Index] || list[dataGridView1.SelectedRows[i + 1].Index])
                                one = true;

                            if (!(list[dataGridView1.SelectedRows[i].Index] && list[dataGridView1.SelectedRows[i + 1].Index]))
                                all = false;
                        }

                    }

                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = dt1;


                    if (dr == DialogResult.OK && dt1.Rows.Count > 0)
                    {
                        if (all)
                            MessageBox.Show("Всі елемент випущені поточного року", "Поівдомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Не всі елемент випущені поточного року", "Поівдомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dr == DialogResult.Yes)
                    {
                        if (one)
                            MessageBox.Show("Хоча б один елемент випущений поточного року", "Поівдомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Ні одного елементу немає поточного року", "Поівдомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Ні одного елементу немає поточного року", "Поівдомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

     





        // Пошук максимального значення.
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            List<Appliances> appliances = new List<Appliances>();

            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
                appliances.Add(list[row.Index]);


            Appliances a = Max(appliances);

            dt1.Clear();

            foreach(Appliances app in appliances)
            {
                if (app == a)
                    AddToTable(dt1,app);
            }

            smallSize();
            toolStripButton11.Visible = true;

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dt1;
            
        }

        private Appliances Max(List<Appliances> appliances)
        {
            Appliances max = appliances[0];
            
            for(int i = 1; i < appliances.Count; i++)
            {
                if(max < appliances[i])
                    max = appliances[i];
            }

            return max;

        }






        // Виведення ціни.
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.ToUpper(e.KeyChar) == 'I')
            {
                DataGridView dataGridView = sender as DataGridView;

                int count = dataGridView.SelectedRows.Count;

                if (count == 0)
                    return;

                string all = "";
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    int index = row.Index;

                    double price = list[index];
                    string name = list[index];

                    all += name + " - " + price + "\n";
                }

                MessageBox.Show(all, "Інформація про вибрані товари", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(char.ToUpper(e.KeyChar) == 'P' || char.ToUpper(e.KeyChar) == 'M')
            {

                foreach(DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int index = row.Index;

                    if(index < 0)
                        continue;

                    if (char.ToUpper(e.KeyChar) == 'P')
                    {
                        double p = list[index];
                        if(p >= 0)
                            list[index]++;
                    }
                    else
                        list[index]--;
                }

                UpdateDataGridView1();

            }
           
        }



    

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainAdd.Visible = true;

            if (toolStripComboBox1.SelectedIndex == 0)
            {
                Microwave.Visible = true;
                Cleaner.Visible = false;
                WashingMashine.Visible = false;
            }
            else if (toolStripComboBox1.SelectedIndex == 2)
            {
                Microwave.Visible = false;
                Cleaner.Visible = true;
                WashingMashine.Visible = false;
            }
            else if (toolStripComboBox1.SelectedIndex == 1)
            {
                Microwave.Visible = false;
                Cleaner.Visible = false;
                WashingMashine.Visible = true;
            }
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (toolStripComboBox2.SelectedIndex == 0)
            {
                panelMicrowave.Visible = true;
                panelCleaner.Visible = false;
                panelWashingMashine.Visible = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
            else if (toolStripComboBox2.SelectedIndex == 2)
            {
                panelMicrowave.Visible = false;
                panelCleaner.Visible = true;
                panelWashingMashine.Visible = false;
                checkBox20.Checked = false;
                checkBox21.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
            else if (toolStripComboBox2.SelectedIndex == 1)
            {
                panelMicrowave.Visible = false;
                panelCleaner.Visible = false;
                panelWashingMashine.Visible = true;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox20.Checked = false;
                checkBox21.Checked = false;
            }
        }
    }

}

// Створення і конструктор зазамовчуванням
