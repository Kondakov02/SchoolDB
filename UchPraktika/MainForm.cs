using System;
using System.Windows.Forms;

/*
 * Приложение "Электронный журнал", автор Кондаков Д.К., группа ТИП-62
 * Используется для взаимодействия с БД на MySQL.
 * Form2 - основная форма приложения. Здесь выбирается таблица, с которой пользователь
 * будет работать.
 * События:
 * Form2_Load - приложение изначально запускает именно эту форму, а не Form1, так как
 * она основная. Но при первоначальной загрузке Form2 вызывает Form1 и остаётся неактивной
 * до тех пор, пока пользователь не войдёт в систему или закроет программу.
 * button1_Click и т.д. - нажатие на кнопки вызывает соответствующие формы для работы с
 * таблицами.
*/

namespace UchPraktika
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProfilesForm profileForm = new ProfilesForm();
            profileForm.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GroupsForm groupForm = new GroupsForm();
            groupForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentsForm studentForm = new StudentsForm();
            studentForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SubjectsForm subjectForm = new SubjectsForm();
            subjectForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PlansForm planForm = new PlansForm();
            planForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProfessorsForm profForm = new ProfessorsForm();
            profForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            JournalForm journalForm = new JournalForm();
            journalForm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CalcForm calculatorForm = new CalcForm();
            calculatorForm.ShowDialog();
        }
    }
}
