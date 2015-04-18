using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Search_Engines_Parser_2
{
    class WorkData
    {
        //Класс-контейнер для даных
        public WorkData()
        {
            Keywords = new string[0];
            ProxyList = new string[0];
            ProxyCredentials = new string[0, 0];
            UAList = new string[0];
            ZonesList = new string[0];
            AllDone = false;

            SEs = string.Empty;
            Data = string.Empty;
            DataNumbers = string.Empty;
            SaveSplitter = string.Empty;
        }

        #region Properties
        /// <summary>
        /// Для каждого сервиса своя цифра, в строке нет разделителей
        /// </summary>
        public string SEs { get; set; }

        /// <summary>
        /// Тип парсинга
        /// 0 - одиночный запрос
        /// 1 - из файла
        /// </summary>
        public int AskType { get; set; }

        /// <summary>
        /// Кодировка запроса/файла
        /// 0 - ANSI;
        /// 1 - UTF-8;
        /// </summary>
        public int AskEncoding { get; set; }

        /// <summary>
        /// Запрос из строки для запроса
        /// </summary>
        public string Ask { get; set; }

        /// <summary>
        /// Кейворды
        /// </summary>
        public string[] Keywords { get; set; }
        /// <summary>
        /// Данные
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Данные, числа для кейвордов
        /// </summary>
        public string DataNumbers { get; set; }

        /// <summary>
        /// Тип сохранения результатов
        /// </summary>
        public int SaveType { get; set; }

        /// <summary>
        /// Тип кодировки для сохранения
        /// </summary>
        public int SaveEncoding { get; set; }

        /// <summary>
        /// Разделитель между кейвордами и цифрами
        /// </summary>
        public string SaveSplitter { get; set; }

        /// <summary>
        /// Кол-во страниц для парсинга
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Прогрессивный парсинг
        /// </summary>
        public bool Progress { get; set; }

        /// <summary>
        /// Парсинг с альтернативными кеями
        /// </summary>
        public bool Trash { get; set; }

        /// <summary>
        /// Пауза между запросами в секундах
        /// </summary>
        public int Pause { get; set; }

        /// <summary>
        /// Использование зон
        /// </summary>
        public bool Zones { get; set; }

        /// <summary>
        /// Список зон для парсинга
        /// </summary>
        public string[] ZonesList { get; set; }

        /// <summary>
        /// Ссылки с хттп
        /// </summary>
        public bool HTTPLinks { get; set; }

        /// <summary>
        /// Использование прокси
        /// </summary>
        public bool Proxy { get; set; }

        /// <summary>
        /// Кол-во запросов, после которых нужно переключиться на след. прокси
        /// </summary>
        public int ProxySwitch { get; set; }

        /// <summary>
        /// Список прокси
        /// </summary>
        public string[] ProxyList { get; set; }

        /// <summary>
        /// Список логинов и паролей для приватных прокси
        /// </summary>
        public string[,] ProxyCredentials { get; set; }

        /// <summary>
        /// Кол-во запросов, после которых нужно сменить УА
        /// </summary>
        public int UASwitch { get; set; }

        /// <summary>
        /// Случайое переключение между УА
        /// </summary>
        public bool UARandom { get; set; }

        /// <summary>
        /// Список УА
        /// </summary>
        public string[] UAList { get; set; }

        /// <summary>
        /// Индикатор завершенности работы
        /// </summary>
        public bool AllDone { get; set; }

        /// <summary>
        /// Индекс текущего кейвордаs
        /// </summary>
        /*public int CurrentKeyword
        {
            set
            {
                this.currentKeyword = value;
            }
            get
            {
                return this.currentKeyword;
            }
        }*/

        /// <summary>
        /// Текущий шаг
        /// </summary>
        public int CurrentStep { get; set; }

        /// <summary>
        /// Всего шагов
        /// </summary>
        public int TotalSteps { get; set; }

        /// <summary>
        /// Индекс текущего прокси
        /// </summary>
        public int CurrentProxy { get; set; }

        /// <summary>
        /// Индекс текущего УА
        /// </summary>
        public int CurrentUA { get; set; }

        /// <summary>
        /// Рабочий поток
        /// </summary>
        public Thread WorkThread { get; set; }
        /// <summary>
        /// Фильтр
        /// </summary>
        public bool Filter { get; set; }
        /// <summary>
        /// Длина
        /// </summary>
        public int FilterLength { get; set; }
        /// <summary>
        /// 0 - символы, 1 - слова
        /// </summary>
        public int FilterType { get; set; }

        #endregion

    }
}
