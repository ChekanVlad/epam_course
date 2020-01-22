using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAO<T>
    {
        void Create(T t);
        T Read(int id);
        void Delete(int id);
        void Update(T t);
        List<T> ReadAll(T t);
    }
}
