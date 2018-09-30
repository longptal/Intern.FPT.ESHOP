using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MLanguage
{
    public interface ILanguageRepository
    {
        int Count(LanguageSearchEntity SearchLanguageEntity);
        List<Language> List(LanguageSearchEntity SearchLanguageEntity);
        Language Get(Guid Id);
        void AddOrUpdate(Language Language);
        void Delete(Guid Id);
    }
    public class LanguageRepository : CommonRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(EShopContext context) : base(context)
        {

        }

        public int Count(LanguageSearchEntity SearchLanguageEntity)
        {
            if (SearchLanguageEntity == null) SearchLanguageEntity = new LanguageSearchEntity();
            IQueryable<Language> Languages = context.Languages;
            Apply(Languages, SearchLanguageEntity);
            return Languages.Count();
        }

        public List<Language> List(LanguageSearchEntity SearchLanguageEntity)
        {
            if (SearchLanguageEntity == null) SearchLanguageEntity = new LanguageSearchEntity();
            IQueryable<Language> Languages = context.Languages;
            Apply(Languages, SearchLanguageEntity);
            SkipAndTake(Languages, SearchLanguageEntity);
            return Languages.ToList();
        }

        public Language Get(Guid Id)
        {
            Language Language = context.Languages.Where(c => c.Id == Id ).FirstOrDefault();
            if (Language == null)
                throw new NotFoundException();
            return Language;
        }

        public void AddOrUpdate(Language Language)
        {
            if (context.Entry(Language).State == EntityState.Detached)
                context.Set<Language>().Add(Language);
        }

        public void Delete(Guid Id)
        {
            Language Language = Get(Id);
            context.Languages.Remove(Language);
        }

        private IQueryable<Language> Apply(IQueryable<Language> Languages, LanguageSearchEntity SearchLanguageEntity)
        {
            if (SearchLanguageEntity.Id.HasValue)
                Languages = Languages.Where(t => t.Id == SearchLanguageEntity.Id.Value);
            if (SearchLanguageEntity.IsActive.HasValue)
                Languages = Languages.Where(t => t.IsActive == SearchLanguageEntity.IsActive.Value);
            if (!string.IsNullOrEmpty(SearchLanguageEntity.Code))
                Languages = Languages.Where(t => t.Code.ToLower().Contains(SearchLanguageEntity.Code.ToLower()));
            if (!string.IsNullOrEmpty(SearchLanguageEntity.Name))
                Languages = Languages.Where(t => t.Name.ToLower().Contains(SearchLanguageEntity.Name.ToLower()));
            if (!string.IsNullOrEmpty(SearchLanguageEntity.Icon))
                Languages = Languages.Where(t => t.Icon.ToLower().Contains(SearchLanguageEntity.Icon.ToLower()));
            return Languages;
        }
    }
}
