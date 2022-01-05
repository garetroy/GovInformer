using GovInformer.Dtos;
using System;

namespace GovInformer
{
    public class GetSenatorRequest
    {
        string SenatorName { get; set; }
        SenatorLocationDto SenatorLocation { get; set; }
    }
}
