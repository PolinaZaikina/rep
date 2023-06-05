using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5._2
{
    public struct Record
    {
        public int ClientID; // идентификационный номер клиента
        public int Year; // год
        public int Month; // номер месяца
        public int Duration; // продолжительность занятий в данном месяце данного года (в часах)

    }
    internal class FitnessCenter
    {
        public List<Record> Records { get; set; }

        public FitnessCenter()
        {
            Records = new List<Record>();
        }

        public void FindClientWithMaxDuration()
        {
            var result = Records
                .GroupBy(r => r.ClientID) //группируем записи по ClientID
                .Select(g => new //преобразуем группу записей в анонимный объект, содержащий ClientID и TotalDuration
                {
                  ClientID = g.Key,//получаем уникальное значение ClientID для каждой группы
                    TotalDuration = g.Sum(r => r.Duration) //вычисляем общую продолжительность 
                })
                  .OrderByDescending(r => r.TotalDuration) //сортируем результаты по убыванию общей продолжительности занятий
                  .ThenByDescending(r => r.ClientID); //сортируем результаты по убыванию ClientID

            //вывод результатов
            foreach (var client in result)
                Console.WriteLine($"ID клиента: {client.ClientID}\t " +
                    $"Общая продолжительность: {client.TotalDuration}");       
        }
    }
}
