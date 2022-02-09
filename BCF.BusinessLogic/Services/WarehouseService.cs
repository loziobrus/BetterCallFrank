﻿using AutoMapper;
using BCF.BusinessLogic.Interfaces;
using BCF.DataAccess.Interfaces;
using BCF.Model.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCF.BusinessLogic.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public WarehouseService(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            mapper = _mapper;
            unitOfWork = _unitOfWork;
        }

        public IEnumerable<WarehouseDTO> GetAll()
        {
            var warehouses = unitOfWork.WarehouseRepository.GetAll();
            return mapper.Map<IEnumerable<WarehouseDTO>>(warehouses);
        }

        public async Task Insert(WarehouseDTO warehouseDTO)
        {
            var entity = mapper.Map<Warehouse>(warehouseDTO);
            await unitOfWork.WarehouseRepository.Insert(entity);
            await unitOfWork.Save();

            //foreach (var photo in warehouseDTO.Photos)
            //{
            //    var newPhoto = new Photo
            //    {
            //        WarehouseId = entity.Id,
            //        Path = photo.Path
            //    };
            //    await unitOfWork.PhotoRepository.Insert(newPhoto);
            //    await unitOfWork.Save();
            //}
        }

        public async void Update(string id, WarehouseDTO warehouseDTO)
        {
            var entity = await unitOfWork.WarehouseRepository.GetById(id);
            if (entity != null)
            {
                mapper.Map(warehouseDTO, entity);
                unitOfWork.WarehouseRepository.Update(entity);
                await unitOfWork.Save();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async void SeedDatabase()
        {
            var warehouses = ReadJSON();

            foreach(var warehouse in warehouses)
            {
                await Insert(warehouse);
            }
        }

        static List<WarehouseDTO> ReadJSON()
        {
            string fileData = System.IO.File.ReadAllText(@"../warehouses.json");
            return JsonConvert.DeserializeObject<List<WarehouseDTO>>(fileData);
        }
    }
}
