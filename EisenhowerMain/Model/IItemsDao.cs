using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain.Model
{
    public interface IItemsDao
    {
        public void Save(string title, DateTime deadline, bool importance, bool overwrite);
        public void Load(TodoMatrix todoMatrix, bool overwrite);


    }
}
