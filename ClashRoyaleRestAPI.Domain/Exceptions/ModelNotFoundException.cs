using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Domain.Common.Exceptions
{
    public class ModelNotFoundException<T> : Exception
    {
        public ModelNotFoundException() : base(string.Format("{0} not found", nameof(T)))
        { }
    }
}
