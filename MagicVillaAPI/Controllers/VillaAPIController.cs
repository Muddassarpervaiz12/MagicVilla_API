using MagicVillaAPI.Data;
using MagicVillaAPI.Model;
using MagicVillaAPI.Model.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Controllers
{
    //routing VillaAPI Controller
    [Route("api/VillaAPI")]
    //this is api controller that why we use this attribute
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        //return list of villa
        //end point on method level not on controller level
        //so IEnumeable<VillaDTO> is get end point  
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        // return villa based on id
        //tell explicitly id is integer
        //[HttpGet("{id:int}")]
        [HttpGet("id")] //Endpoint
        //[ProducesResponseType(200, Type=typeof(VillaDTO))]    we use this if we want to write method like this
        //ActionResult GetVilla(int id)
        [ProducesResponseType(200)]//document the status type 
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }
    }
}
