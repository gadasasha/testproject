using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class ServicesProcesor
    {
        public static int CreateService (string name, bool active)
        {
            ServicesModel data = new ServicesModel
            {
                Name = name,
                Active = active,
                Date_post = DateTime.Now,
            };

            string sql = @"INSERT INTO dbo.tb_services_balances(Name, Active, Date_post)
                           VALUES(@Name, @Active, @Date_post)   
                           INSERT INTO dbo.tb_services_balances_sums(Service_id, Date_post) 
                           VALUES(SCOPE_IDENTITY(), @Date_post);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ServicesModel> LoadServices()
        {
            string sql = @"SELECT dbo.tb_services_balances.Service_id, dbo.tb_services_balances.Name, dbo.tb_services_balances.active, dbo.tb_services_balances.date_post,  dbo.tb_services_balances_sums.limit,  dbo.tb_services_balances_sums.sum  
                           FROM  dbo.tb_services_balances INNER JOIN  dbo.tb_services_balances_sums  
	                       ON  dbo.tb_services_balances.service_id =  dbo.tb_services_balances_sums.service_id";

            return SqlDataAccess.LoadData<ServicesModel>(sql);
        }

        public static int UpdateLimit(int service_id, decimal limit)
        {
            ServicesModel data = new ServicesModel
            {
                Service_id = service_id,
                Limit = limit,
            };

            string sql = @"UPDATE dbo.tb_services_balances_sums SET Limit=@Limit 
                           WHERE Service_id=@Service_id ";

            return SqlDataAccess.UpdateData(sql, data);
        }

    }
}
