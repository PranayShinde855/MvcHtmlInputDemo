using MvcHtmlInputDemo.Database;
using MvcHtmlInputDemo.Dto;
using MvcHtmlInputDemo.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MvcHtmlInputDemo.Service
{
    public class CityService
    {
        private string connectionString = "Data Source=DESKTOP-HKULI1B;Initial catalog=Demo;user Id = sa; password = spark;";
        public List<CityDto> GetAll()
        {
            string query = "Select * from [City];";

            var dbContext = new DB();
            var data = dbContext.GetData(query);
            var result = data.AsEnumerable().Select(row =>
            new CityDto
            {
                CityId = row.Field<int>("Id"),
                Name = row.Field<string>("name")
            }).ToList();
            return result;
        }
    }
}
