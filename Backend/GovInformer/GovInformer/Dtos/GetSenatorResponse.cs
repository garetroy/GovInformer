using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovInformer.Dtos
{
    public class GetSenatorResponse
    {
        bool IsVacant { get; set; }
        string Name { get; set; }
    }
}
