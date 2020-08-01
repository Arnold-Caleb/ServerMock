using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AccessDataLibrary;
using Model;

namespace ServerMock
{
    class Helpers
    {   
        DataAccess _data = new DataAccess();
        public string connectionString = "Server=db4free.net,3306;Database=gamers_server;User Id=arnold; Password=Arn0ld!nsql";

        List<LoginModel> loginInfo;
        List<PersonnelModel> personnelInfo;
   

        /*Section for loading information from database tables*/
        public async Task<List<LoginModel>> LoadLoginInfoAsync()
        {
            string sql = "select * from LoginTable";

            loginInfo = await _data.LoadData<LoginModel, dynamic>(sql, new { }, connectionString);

            return loginInfo;
        }

        public async Task<List<PersonnelModel>> LoadPersonnelInfoAsync()
        {
            string sql = "select * from Personnel";

            personnelInfo = await _data.LoadData<PersonnelModel, dynamic>(sql, new { }, connectionString);

            return personnelInfo;
        } 

        /*Section for adding information to the database */
        public async Task InsertLoginInfoAsync(string fullName, string accessType, int totalAlerts, int handledAlerts, int missedAlerts, string language = "English")
        {
            string sql = "insert into LoginTable (FullName, AccessType, TotalAlerts, HandledAlerts, MissedAlerts, Language) values (@FullName, @AccessType, @TotalAlerts, @HandledAlerts, @MissedAlerts, @Language)";

            await _data.SaveData(sql, 
                            new { 
                                FullName=fullName, 
                                AccessType=accessType, 
                                TotalAlerts=totalAlerts, 
                                HandledAlerts=handledAlerts, 
                                MissedAlerts=missedAlerts, 
                                Language=language
                                }, 
                            connectionString);

        }

        public async Task InsertPersonnelInfoAsync(string name, string role, string email, string phone, string filepath)
        {
            string sql = "insert into Personnel (Name, Role, Email, Phone, filepath) values (@Name, @Role, @Email, @Phone, @filepath)";

            await _data.SaveData(sql, 
                            new { 
                                Name=name, 
                                Role=role, 
                                Email=email, 
                                Phone=phone, 
                                filepath=filepath 
                                }, 
                            connectionString);

        }

        /*Section for updating the data in the database */
        public async Task UpdateLoginInfoAsync(string fullName, string accessType)
        {
            string sql = "update LoginTable set FullName = @FullName where AccessType = @AccessType";

            await _data.SaveData(sql, 
                            new { FullName=fullName, AccessType=accessType }, 
                            connectionString);

        }

        public async Task UpdatePersonnelInfoAsync(string name, string role)
        {
            string sql = "update Personnel set Name = @Name where Role=@Role";

            await _data.SaveData(sql, 
                            new { Name=name, Role=role }, 
                            connectionString);

        }

        /*Section for deleting the Data in the database */
        public async Task DeleteLoginInfoAsync(string fullName)
        {
            string sql = "delete from LoginTable where FullName = @FullName";

            await _data.SaveData(sql, 
                            new { FullName=fullName }, 
                            connectionString);

        }

        public async Task DeletePersonnelInfoAsync(string name)
        {
            string sql = "delete from Personnel where Name = @Name";

            await _data.SaveData(sql, 
                            new { Name=name }, 
                            connectionString);

        }
    }
}
