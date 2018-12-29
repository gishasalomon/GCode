using System;
using System.Collections.Generic;
using System.Text;

namespace TestCI.Database
{
    public interface IDataModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Designation { get; set; }
        string Country { get; set; }
    }
}
