using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Common.Exceptions
{
    public class IdNotFoundException<T, U> : Exception
    {
        public IdNotFoundException(U id) : base(string.Format("{0}: Id {1} does not exist", typeof(T), id))
        { }
        public IdNotFoundException() : base($"{typeof(T)}: Ids do not exist")
        { }

    }
}
