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
        [ProducesResponseType(StatusCodes.Status200OK)]//document the status type 
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        // return villa based on id
        //tell explicitly id is integer
        //[HttpGet("{id:int}")]

        [HttpGet("id", Name ="GetVilla")] //Endpoint

        //[ProducesResponseType(200, Type=typeof(VillaDTO))]    we use this if we want to write method like this
        //ActionResult GetVilla(int id)
        //[ProducesResponseType(200)] another method to document the status type

        [ProducesResponseType(StatusCodes.Status200OK)]//document the status type 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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


        //Creating Source / or Villa 
        //For this use HttpPost Method
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]//document the status type 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            //chech villa name, when create villa its does not exist already and create unique name
            if(VillaStore.villaList.FirstOrDefault(u=>u.Name.ToLower()  == villaDTO.Name.ToLower()) != null)
            {
                //in bracket key, value pair
                ModelState.AddModelError("CustomError", "Villa Name already Exists....");
                return BadRequest(ModelState);
            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            //if creating villa id should be 0 if id is greate then zero then its means this is not create request
            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //So we retrive maximum id here and increment that by one.
            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            //store villaDTO into the villaList
            VillaStore.villaList.Add(villaDTO);

            //this way is use when create source, you give url where the actual source is created
            return CreatedAtRoute("GetVilla",new {id = villaDTO.Id  },villaDTO);
        }
    }
}
