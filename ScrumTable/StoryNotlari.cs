using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTable
{
    public class StoryNotlari: Notlar
    {
        public List<NotStartedNotlari> NotStTaskListesi; // ilgili storynin not started notları
        public List<InProgressNotlari> InProTaskListesi; // ilgili storynin in progress notları
        public List<DoneNotlari> DoneTaskListesi; // ilgili storynin done notları

        public StoryNotlari()
        {
            NotStTaskListesi = new List<NotStartedNotlari>();
            InProTaskListesi = new List<InProgressNotlari>();
            DoneTaskListesi = new List<DoneNotlari>(); // composition ilişkiler
        }

        public void NotStTaskEkle(NotStartedNotlari task)
        {
            NotStTaskListesi.Add(task);
        }  // ilgili taski kategorisine göre ekleme
        public void InProTaskEkle(InProgressNotlari task)
        {
            InProTaskListesi.Add(task);
        }
        public void DoneTaskEkle(DoneNotlari task)
        {
            DoneTaskListesi.Add(task);
        }
    }
}
