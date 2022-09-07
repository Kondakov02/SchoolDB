using System;
using System.Windows.Forms;

/*
 * Приложение "Электронный журнал", автор Кондаков Д.К., группа ТИП-62
 * Используется для взаимодействия с БД на MySQL.
 * Form5 - форма работы с одной из таблиц.
 * События:
 * Form5_Load - попытка подключения к базе данных и заполнения таблицы информацией.
 * У пользователя должно быть право на использование этой таблицы.
 * button1_Click - попытка сохранить изменения.
 * button2_Click - закрытие формы.
 * dataGridView1_DataError - вызывается при неправильном вводе даты.
*/

namespace UchPraktika
{
    public partial class StudentsForm : Form
    {
        public StudentsForm()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                this.studentTableAdapter.Connection.ConnectionString = "server=localhost;" +
                    "database=academicperformance;uid=" + globalVar.login +
                    ";pwd=" + globalVar.Reverse(globalVar.password) + ";";
                this.studentTableAdapter.Fill(this.dataSet.student);
                button1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться. Возможно, произошёл сбой " +
                    "или у Вас нет прав пользоваться этой таблицей.");
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentTableAdapter.Update(this.dataSet.student);
            }
            catch
            {
                MessageBox.Show("Ошибка. Все поля должны быть заполнены. " +
                    "Идентификатор должен быть уникальным. Дата поступления " +
                    "должна быть полной. Форма обучения: Дневная, Вечерняя, Заочная. " +
                    "В ячейке \"Группа\" должен быть её идентификатор.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введите полную дату, отделяя день, месяц и год " +
                "через точки или дефисы.");
        }
    }
}
