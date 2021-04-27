using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        [HttpGet]
        [Route("Claims")]
        public object Claims()
        {
            var claims = ReadClaimsCsv();
            var members = ReadMembersCsv();

            return from a in members
                   join p in claims on a.MemberID equals p.MemberID into ClaimsArray
                   select new
                   {
                       memberID = a.MemberID,
                       name = a.FirstName + a.LastName,
                       ClaimAmount = ClaimsArray.Select(ap => ap.ClaimAmount)
                   };
        }

        private IEnumerable<Member> ReadMembersCsv()
        {
            using (var reader = new StreamReader("C:\\Users\\hp\\Downloads\\New folder\\Member.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Member>().ToList();
                return records;
            }
        }

        private IEnumerable<Claim> ReadClaimsCsv()
        {
            using (var reader = new StreamReader("C:\\Users\\hp\\Downloads\\New folder\\Claim.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Claim>().ToList();
                return records;
            }
        }
    }
}
