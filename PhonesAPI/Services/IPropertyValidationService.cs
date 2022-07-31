using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesAPI.Services
{
    public interface IPropertyValidationService
    {
        bool HasValidProperties<T>(string fields);
    }
}
