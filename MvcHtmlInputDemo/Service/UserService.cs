using MvcHtmlInputDemo.Database;
using MvcHtmlInputDemo.Dto;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MvcHtmlInputDemo.Service
{
    public class UserService
    {
        private string connectionString = "Data Source=DESKTOP-HKULI1B;Initial catalog=Demo;user Id = sa; password = spark;";

        public string Add(AddUserDto requestDto) 
        {
            string query = "insert into [User] (FullName, Gender, CityId, Cricket, Kabbdai, Tenies)" +//, ProfilePicture, ProfilePictureName)" +
                " values (@FullName, @Gender, @CityId, @Cricket, @Kabbdai, @Tenies)";//, @ProfilePicture, @ProfilePictureName);";
            var parameters = new IDataParameter[]
            {
                new SqlParameter("@FullName", requestDto.Fullname),
                new SqlParameter("@Gender", requestDto.Gender),
                new SqlParameter("@CityId", requestDto.CityId),
                new SqlParameter("@Cricket", requestDto.Cricket),
                new SqlParameter("@Kabbdai", requestDto.Kabbdai),
                new SqlParameter("@Tenies", requestDto.Tenies),
                new SqlParameter("@ProfilePicture",  requestDto.ProfilePicture),
                new SqlParameter("@ProfilePictureName", requestDto.ProfilePictureName),
           };

            var dbContext = new DB();
            return dbContext.ExecuteData(query, parameters);
        }

        public string Update(UpdateUserdto requestDto)
        {
            string query = "Update table [User] Set FullName = @FullName, Gender = @Gender, CityId = @CityId, Cricket = @Cricket," +
                " Kabbdai = @Kabbdai, Tenies = @Tenies, ProfilePicture = @ProfilePicture, ProfilePictureName = @ProfilePictureName)" +
                " where Id = @Id";
            var parameters = new IDataParameter[]
            {
                new SqlParameter("@Id", requestDto.Id),
                new SqlParameter("@FullName", requestDto.Fullname),
                new SqlParameter("@Gender", requestDto.Gender),
                new SqlParameter("@CityId", requestDto.CityId),
                new SqlParameter("@Cricket", requestDto.Cricket),
                new SqlParameter("@Kabbdai", requestDto.Kabbdai),
                new SqlParameter("@Tenies", requestDto.Tenies),
                new SqlParameter("@ProfilePicture", requestDto.ProfilePicture),
                new SqlParameter("@ProfilePictureName", requestDto.ProfilePictureName),
           };

            var dbContext = new DB();
            return dbContext.ExecuteData(query, parameters);
        }

        public List<UserDto> GetAll()
        {
            string query = "Select u.Id, u.FullName, u.Gender, c.Name as City, u.FullName as sports from [User] u " +
                "left join City c on u.CityId = c.Id ;";           

            var dbContext = new DB();
            var data = dbContext.GetData(query);
            var result = data.AsEnumerable().Select(row =>
            new UserDto
            {
                Id = row.Field<int>("Id"),
                Fullname = row.Field<string>("FullName"),
                City = row.Field<string>("City"),
                Gender = row.Field<string>("Gender"),
                Sports = row.Field<string>("Sports")
            }).ToList();
            return result;
        }
    }
}
