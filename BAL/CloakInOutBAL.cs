using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GS.DAL;
using GS.Models;

namespace GS.BAL
{
    public class CloakInOutBAL
    {
        private CloakInOutDAL dal = new CloakInOutDAL();

        public async Task<List<getcloakinoutbystaffidbtwdates>> getcloakinoutbystaffidbtwdates(getcloakinoutbystaffidbtwdates RC)
        {
            return await dal.getcloakinoutbystaffidbtwdates(RC);
        }

        public async Task<List<Getstaffdd>> Getstaffdd()
        {
            return await dal.Getstaffdd();
        }
        public async Task<List<StaffWorkingHours>> StaffWorkingHours(StaffWorkingHours SF)
        {
            return await dal.StaffWorkingHours(SF);
        }
    }
}