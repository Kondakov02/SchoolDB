using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

/*
 * Приложение "Электронный журнал", автор Кондаков Д.К., группа ТИП-62
 * Используется для взаимодействия с БД на MySQL.
 * Form1 - форма входа в систему. Она появляется первой при запуске программы.
 * Переменная:
 * loginSuccess - определяет, был ли выполнен вход в систему.
 * События:
 * button1_Click - срабатывает при нажатии кнопки "Вход". Производится попытка
 * входа в систему с заданными логином и паролем. Если получается войти, то
 * пользователя уведомляют об этом и закрывают форму Form1, тем самым вызывая
 * событие Form1_FormClosing.
 * Form1_FormClosing - срабатывает при закрытии формы. Если loginSuccess = false,
 * то приложение полностью закрывается, в противном случае открывается основная
 * форма Form2.
*/
namespace UchPraktika
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        bool loginSuccess = false;

        private void button1_Click(object sender, EventArgs e)
        {
            globalVar.login = textBox1.Text;
            globalVar.password = globalVar.Reverse(textBox2.Text);
            MySqlConnection cnn;
            string connectionString = "server=localhost;" +
                "database=academicperformance;uid="+ globalVar.login + 
                ";pwd=" + globalVar.Reverse(globalVar.password) + ";";
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Вы вошли в систему.");
                cnn.Close();
                loginSuccess = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. " +
                    "Пожалуйста, проверьте ещё раз введенные данные");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loginSuccess)
            {
                Application.Exit();
            }
        }
    }
}