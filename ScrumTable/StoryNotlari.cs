using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTable
{
    public class StoryNotlari: Notlar
    {
        public List<NotStartedNotlari> NotStTaskListesi;
        public List<InProgressNotlari> InProTaskListesi;
        public List<DoneNotlari> DoneTaskListesi;

        public StoryNotlari()
        {
            NotStTaskListesi = new List<NotStartedNotlari>();
            InProTaskListesi = new List<InProgressNotlari>();
            DoneTaskListesi = new List<DoneNotlari>();
        }

        public void NotStTaskEkle(NotStartedNotlari task)
        {
            NotStTaskListesi.Add(task);
        }

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
