using System;
using System.Collections.Generic;
using System.Text;

namespace DewInterfaces.DewExtensions
{
    public interface IValidate<T>
    {
        /// <summary>
        /// Validate object with overwrite predicate
        /// </summary>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        bool Validate(Func<T, bool> overwrite);
        /// <summary>
        /// Validate object
        /// </summary>
        /// <returns></returns>
        bool Validate();
    }
}
