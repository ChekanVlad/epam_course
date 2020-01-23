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
        T Read(int id);
        void Update(T t, int id);
        void Delete(int id);
        List<T> ReadAll();
    }
}
