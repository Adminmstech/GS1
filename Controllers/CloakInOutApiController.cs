using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using GS.BAL;
using GS.Models;

namespace GS.Controllers
{
    public class CloakInOutApiController : ApiController
    {
        private CloakInOutBAL bal = new CloakInOutBAL();
        [Route("api/getcloakinoutbystaffidbtwdates")]
        [HttpPost]
        public async Task<List<getcloakinoutbystaffidbtwdates>> getcloakinoutbystaffidbtwdates(getcloakinoutbystaffidbtwdates RC)
        {
            return await bal.getcloakinoutbystaffidbtwdates(RC);
        }

        [Route("api/Getstaffdd")]
        [HttpGet]
        public async Task<List<Getstaffdd>> Getstaffdd()
        {
            return await bal.Getstaffdd();
        }

        [Route("api/StaffWorkingHours")]
        [HttpPost]
        public async Task<List<StaffWorkingHours>> StaffWorkingHours(StaffWorkingHours SF)
        {
            return await bal.StaffWorkingHours(SF);
        }

    }
}
