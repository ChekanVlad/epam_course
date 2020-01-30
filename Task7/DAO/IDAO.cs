using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOClasses
{
    public interface IDAO<T>
    {
        void Create(T t);
        void Delete(int id);
        T Read(int id);
        void Update(T t, int id);
        List<T> ReadAll();
    }
}
