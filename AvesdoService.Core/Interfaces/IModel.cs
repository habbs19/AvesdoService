using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Core.Interfaces
{
    public abstract class IModel<T> where T : IEquatable<T>
    {
        public T Id { get; set; }
        public string Key { get; set; }
    }
}
