using System;
using System.Windows.Forms;

/*
 * Приложение "Электронный журнал", автор Кондаков Д.К., группа ТИП-62
 * Используется для взаимодействия с БД на MySQL.
 * Form8 - форма работы с одной из таблиц.
 * События:
 * Form8_Load - попытка подключения к базе данных и заполнения таблицы информацией.
 * У пользователя должно быть право на использование этой таблицы.
 * button1_Click - попытка сохранить изменения.
 * button2_Click - закрытие формы.
 * dataGridView1_DataError - вызывается при неправильном вводе даты.
*/

namespace UchPraktika
{
    public partial class ProfessorsForm : Form
    {
        public ProfessorsForm()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            try
            {
                this.professorTableAdapter.Connection.ConnectionString = "server=localhost;" +
                    "database=academicperformance;uid=" + globalVar.login +
                    ";pwd=" + globalVar.Reverse(globalVar.password) + ";";
                this.professorTableAdapter.Fill(this.dataSet.professor);
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
                this.professorTableAdapter.Update(this.dataSet.professor);
            }
            catch
            {
                MessageBox.Show("Ошибка. Все поля должны быть заполнены. " +
                    "Идентификатор должен быть уникальным. Дата начала работы " +
                    "должна быть полной");
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
