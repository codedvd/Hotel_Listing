﻿using AutoMapper;
using Hotel_Listing.api.Contracts;
using Hotel_Listing.api.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Listing.api.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext _context;
        public GenericRepository(HotelListingDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();
           return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var enitity = await GetAsync(id);
            _context.Set<T>().Remove(enitity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }   

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
