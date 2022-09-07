using System;
using System.Windows.Forms;

/*
 * Приложение "Электронный журнал", автор Кондаков Д.К., группа ТИП-62
 * Используется для взаимодействия с БД на MySQL.
 * Form6 - форма работы с одной из таблиц.
 * События:
 * Form6_Load - попытка подключения к базе данных и заполнения таблицы информацией.
 * У пользователя должно быть право на использование этой таблицы.
 * button1_Click - попытка сохранить изменения.
 * button2_Click - закрытие формы.
*/

namespace UchPraktika
{
    public partial class SubjectsForm : Form
    {
        public SubjectsForm()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                this.subjectTableAdapter.Connection.ConnectionString = "server=localhost;" +
                    "database=academicperformance;uid=" + globalVar.login +
                    ";pwd=" + globalVar.Reverse(globalVar.password) + ";";
                this.subjectTableAdapter.Fill(this.dataSet.subject);
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
                this.subjectTableAdapter.Update(this.dataSet.subject);
            }
            catch
            {
                MessageBox.Show("Ошибка. Все поля должны быть заполнены. " +
                    "Идентификатор должен быть уникальным.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
