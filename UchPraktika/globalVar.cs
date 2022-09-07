using System;

/*
 * Приложение "Электронный журнал", автор Кондаков Д.К., группа ТИП-62
 * Используется для взаимодействия с БД на MySQL.
 * globalVar - форма входа в систему. Она появляется первой при запуске программы.
 * Переменные:
 * globalVar.login - глобальная переменная логина, используется для
 * формирования строки подключения к отдельным таблицам.
 * globalVar.password - глобальная переменная пароля, также используется для
 * подключения.
 * Функция:
 * Reverse - функция примитивного шифрования и расшифрования пароля. Переворачивает
 * строку-параметр задом наперёд.
*/

namespace UchPraktika
{
    class globalVar
    {
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private static string _login = "";
        private static string _password = "";
        public static string login
        {
            get { return _login; }
            set { _login = value; }
        }
        public static string password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
