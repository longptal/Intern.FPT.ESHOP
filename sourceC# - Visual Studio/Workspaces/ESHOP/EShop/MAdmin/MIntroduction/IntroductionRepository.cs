using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MIntroduction
{
    public interface IIntroductionRepository
    {
        int Count(IntroductionSearchEntity SearchIntroductionEntity);
        List<Introduction> List(IntroductionSearchEntity SearchIntroductionEntity);
        Introduction Get(Guid Id);
        void AddOrUpdate(Introduction Introduction);
        void Delete(Guid Id);
    }
    public class IntroductionRepository : CommonRepository<Introduction>, IIntroductionRepository
    {
        public IntroductionRepository(EShopContext context) : base(context)
        {

        }

        public int Count(IntroductionSearchEntity SearchIntroductionEntity)
        {
            if (SearchIntroductionEntity == null) SearchIntroductionEntity = new IntroductionSearchEntity();
            IQueryable<Introduction> Introductions = context.Introductions;
            Apply(Introductions, SearchIntroductionEntity);
            return Introductions.Count();
        }

        public List<Introduction> List(IntroductionSearchEntity SearchIntroductionEntity)
        {
            if (SearchIntroductionEntity == null) SearchIntroductionEntity = new IntroductionSearchEntity();
            IQueryable<Introduction> Introductions = context.Introductions;
            Apply(Introductions, SearchIntroductionEntity);
            SkipAndTake(Introductions, SearchIntroductionEntity);
            return Introductions.ToList();
        }

        public Introduction Get(Guid Id)
        {
            Introduction Introduction = context.Introductions.Where(c => c.Id == Id ).FirstOrDefault();
            if (Introduction == null)
                throw new NotFoundException();
            return Introduction;
        }

        public void AddOrUpdate(Introduction Introduction)
        {
            if (context.Entry(Introduction).State == EntityState.Detached)
                context.Set<Introduction>().Add(Introduction);
        }

        public void Delete(Guid Id)
        {
            Introduction Introduction = Get(Id);
            context.Introductions.Remove(Introduction);
        }

       
        private IQueryable<Introduction> Apply(IQueryable<Introduction> Introductions, IntroductionSearchEntity IntroductionSearchEntity)
        {
            if (IntroductionSearchEntity.Id.HasValue)
                Introductions = Introductions.Where(wh => wh.Id == IntroductionSearchEntity.Id.Value);
            if (!string.IsNullOrEmpty(IntroductionSearchEntity.Content))
                Introductions = Introductions.Where(wh => wh.Content.ToLower().Contains(IntroductionSearchEntity.Content.ToLower()));
            if (!string.IsNullOrEmpty(IntroductionSearchEntity.Route))
                Introductions = Introductions.Where(wh => wh.Route.ToLower().Contains(IntroductionSearchEntity.Route.ToLower()));
            return Introductions;
        }
    }
}
