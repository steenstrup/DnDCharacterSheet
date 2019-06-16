using DnDCharacterSheet.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DnDCharacterSheet.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
       
        [HttpGet("[action]")]
        public Characther GetCharacther(int id)
        {
            return MockCharactherRepository.GetCharacther(id);
        }

        [HttpGet("[action]")]
        public List<Characther> GetCharacthers()
        {
            return MockCharactherRepository.Characthers;
        }
    }
}
