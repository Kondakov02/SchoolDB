using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

/*
 * Приложение "Электронный журнал", автор Кондаков Д.К., группа ТИП-62
 * Используется для взаимодействия с БД на MySQL.
 * Form10 - форма калькулятора. Здесь пользователь выбирает параметры и вызывает
 * хранимую процедуру в базе данных, результат выполнения которой отображается
 * на форме.
 * Переменные:
 * connString - строка подключения к базе данных.
 * События:
 * Form10_Load - при загрузке формы приложение пробует подключиться к базе данных и
 * заполнить списки параметров информацией. Для этого у пользователя должны быть права
 * на работу с таблицами Группа и Предмет. В случае сбоя отключается кнопка вызова процедуры.
 * button1_Click - вызов процедуры с передачей выбранных параметров. Результат отображается в
 * ячейке. У пользователя также должно быть право вызывать хранимые процедуры.
 * button2_Click - закрытие формы.
*/

namespace UchPraktika
{
    public partial class CalcForm : Form
    {
        public CalcForm()
        {
            InitializeComponent();
        }

        string connString = "server=localhost;database=academicperformance;uid=" +
        globalVar.login + ";pwd=" + globalVar.Reverse(globalVar.password) + ";";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                MySqlParameter[] pms = new MySqlParameter[3];
                pms[0] = new MySqlParameter("A", MySqlDbType.UInt32);
                pms[0].Value = UInt32.Parse(comboBox1.SelectedValue.ToString());

                pms[1] = new MySqlParameter("B", MySqlDbType.UInt32);
                pms[1].Value = UInt32.Parse(comboBox3.SelectedValue.ToString());

                pms[2] = new MySqlParameter("C", MySqlDbType.UInt32);
                pms[2].Value = UInt32.Parse(comboBox2.SelectedItem.ToString());

                MySqlCommand command = new MySqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "groupperformance";

                command.Parameters.AddRange(pms);

                connection.Open();
                textBox1.Text = command.ExecuteScalar().ToString();
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка. Возможно, у Вас нет прав " +
                    "пользоваться данным калькулятором.");
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            try
            {
                this.subjectTableAdapter.Connection.ConnectionString = connString;
                this.subjectTableAdapter.Fill(this.dataSet.subject);
                this.studentgroupTableAdapter.Connection.ConnectionString = connString;
                this.studentgroupTableAdapter.Fill(this.dataSet.studentgroup);
                button1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться. Возможно, произошёл сбой " +
                    "или у Вас нет прав пользоваться одной из таблиц.");
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
