﻿using System;
using System.Collections.Generic;
using SpacePrk.Models;
using SpacePrk.Models.Contracts;
using SpacePrk.Repositories.Interfaces;
using System.Linq;

namespace SpacePrk.Repositories
{
    public class ParkingSpaceRepository : IParkingSpaceRepository
    {
        private ApplicationDbContext _context;

        public ParkingSpaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ParkingSpace> GetAvailablePrkSpacesBySize(int minSize, int maxSize)
        {
            var freeSpaces = _context.ParkingSpace.Where(s => s.IsFree && s.AvailableSpace > minSize && s.AvailableSpace < maxSize); // Fix Available Space here
            return freeSpaces;
        }

        public IEnumerable<ParkingSpace> GetAvailablePrkSpacesByLocation(ParkingSpaceRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkingSpace> GetAllAvailablePrkSpaces()
        {
            var freeSpaces = _context.ParkingSpace.Where(s => s.IsFree); // Fix Available Space here
            return freeSpaces;
        }
    }
}