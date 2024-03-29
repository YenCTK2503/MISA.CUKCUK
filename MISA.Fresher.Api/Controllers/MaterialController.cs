﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [ApiController]
    public class MaterialController : BaseController<Material>
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialRepository materialRepository, IMaterialService materialService)
            : base(materialRepository, materialService)
        {
            _materialRepository = materialRepository;
            _materialService = materialService;
        }
        /// <summary>
        /// Lấy ra mã NVL mới
        /// </summary>
        /// <returns>Mã NVL mới</returns>
        /// CreatedBy: CTKimYen (15/1/2022)
        [HttpGet("newMaterialCode")]
        public IActionResult GetNewCode(string materialName)
        {
            return Ok(_materialService.GetNewCode(materialName));
        }

        [HttpGet("filter")]
        public IActionResult Filter([FromQuery] int pageIndex, int pageSize, string objectFilterJson, string objectSortJson)
        {
            return Ok(_materialService.Filter(pageIndex, pageSize, objectFilterJson, objectSortJson));
        }
    }
}
