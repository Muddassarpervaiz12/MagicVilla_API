﻿using MagicVillaAPI.Model.Dto;

namespace MagicVillaAPI.Data
{
    public static class VillaStore
    {
        //this is the database of this project we just add record here 
        //we do not use or connect database now
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {

            new VillaDTO { Id = 1, Name = "Pool View" },
            new VillaDTO { Id = 2, Name = "Beach View" }

        };
     }
}
