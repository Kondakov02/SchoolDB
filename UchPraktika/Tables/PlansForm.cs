using System;
using System.Windows.Forms;

/*
 * Приложение "Электронный журнал", автор Кондаков Д.К., группа ТИП-62
 * Используется для взаимодействия с БД на MySQL.
 * Form7 - форма работы с одной из таблиц.
 * События:
 * Form7_Load - попытка подключения к базе данных и заполнения таблицы информацией.
 * У пользователя должно быть право на использование этой таблицы.
 * button1_Click - попытка сохранить изменения.
 * button2_Click - закрытие формы.
*/

namespace UchPraktika
{
    public partial class PlansForm : Form
    {
        public PlansForm()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                this.planTableAdapter.Connection.ConnectionString = "server=localhost;" +
                    "database=academicperformance;uid=" + globalVar.login +
                    ";pwd=" + globalVar.Reverse(globalVar.password) + ";";
                this.planTableAdapter.Fill(this.dataSet.plan);
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
                this.planTableAdapter.Update(this.dataSet.plan);
            }
            catch
            {
                MessageBox.Show("Ошибка. Все поля должны быть заполнены. " +
                    "Идентификатор должен быть уникальным. В ячейках " +
                    "\"Предмет\" и \"Специальность\" должны быть их " +
                    "идентификаторы. Семестр - цифра от 1 до 8. Часы от 0 до " +
                    "255. Тип экзаменации - цифра. Экзамен - 0, зачёт - 1.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
