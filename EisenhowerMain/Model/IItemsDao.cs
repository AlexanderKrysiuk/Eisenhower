using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain.Model
{
    public interface IItemsDao
    {
        public void Save(string title, DateTime deadline, bool importance);
        public void Load(TodoMatrix todoMatrix, bool overwrite);

        public void OverwriteDb();


    }
}
