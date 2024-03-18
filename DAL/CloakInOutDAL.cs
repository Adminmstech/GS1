using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GS.DBoperations;
using GS.Models;
using System.Data;

namespace GS.DAL
{
    public class CloakInOutDAL
    {
        public async Task<List<getcloakinoutbystaffidbtwdates>> getcloakinoutbystaffidbtwdates(getcloakinoutbystaffidbtwdates RC)
        {
            using (DBOperations<getcloakinoutbystaffidbtwdates> dbContext = new DBOperations<getcloakinoutbystaffidbtwdates>())
            {

                DynamicParameters parm = new DynamicParameters();
                parm.Add("@StaffId", RC.StaffId, DbType.Int64, ParameterDirection.Input);
                parm.Add("@Datefrom", RC.Datefrom, DbType.DateTime, ParameterDirection.Input);
                parm.Add("@Dateto", RC.Dateto, DbType.DateTime, ParameterDirection.Input);

                var user = await dbContext.Get("getcloakinoutbystaffidbtwdates", parm);

                return user.ToList();

            }
        }

        public async Task<List<Getstaffdd>> Getstaffdd()
        {
            using (DBOperations<Getstaffdd> dbContext = new DBOperations<Getstaffdd>())
            {

                DynamicParameters parm = new DynamicParameters();

                 
                var user = await dbContext.Get("Getstaffdd", null);

                return user.ToList();

            }
        }
        public async Task<List<StaffWorkingHours>> StaffWorkingHours(StaffWorkingHours SF)
        {
            using (DBOperations<StaffWorkingHours> dbContext = new DBOperations<StaffWorkingHours>())
            {

                DynamicParameters parm = new DynamicParameters();
                parm.Add("@Month", SF.Month, DbType.Int64, ParameterDirection.Input);
                parm.Add("@Year", SF.Year, DbType.Int64, ParameterDirection.Input);
                

                var user = await dbContext.Get("StaffWorkingHours", parm );

                return user.ToList();

            }
        }
    }
}