using ClinicManagement.Entities.Common;

namespace ClinicManagement.Services.Common.Pagination
{
    public static class PageBuilder
    {
        public static BasePagination BuildPagination(this IQueryable<IEntity> queryableEntity, /*int pageCount*/ int activePage, int take)
        {
            if (activePage <= 1) activePage = 1;
            int Count = (int)Math.Ceiling(queryableEntity.Count() / (double)take);
            return new BasePagination
            {
                ActivePage = activePage,
                PageCount = Count == 0 ? 1 : Count,
                PageId = activePage,
                TakeEntity = take,
                SkipEntity = (activePage - 1) * take,
                StartPage = activePage - 3 <= 0 ? 1 : activePage - 3,
                EndPage = activePage + 3 > Count ? Count : activePage + 3
            };
        }

        public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, BasePagination basePagination)
        {
            return queryable.Skip(basePagination.SkipEntity).Take(basePagination.TakeEntity);
        }

        public static BasePagination<TPaginationSelectedDto> BuildPagination<TPaginationSelectedDto>(this IQueryable<IEntity> queryableEntity, /*int pageCount*/ int activePage, int take)
            where TPaginationSelectedDto : class
        {
            if (activePage <= 1) activePage = 1;
            int Count = (int)Math.Ceiling(queryableEntity.Count() / (double)take);
            var pagination = new BasePagination<TPaginationSelectedDto>
            {
                ActivePage = activePage,
                PageCount = Count == 0 ? 1 : Count,
                PageId = activePage,
                TakeEntity = take,
                SkipEntity = (activePage - 1) * take,
                StartPage = activePage - 3 <= 0 ? 1 : activePage - 3,
                EndPage = activePage + 3 > Count ? Count : activePage + 3
            };
            return pagination;
        }

        public static IQueryable<T> Pagination<T, K>(this IQueryable<T> queryable, BasePagination<K> basePagination)
            where K : class
        {
            return queryable.Skip(basePagination.SkipEntity).Take(basePagination.TakeEntity);
        }

        /* public static IEnumerable<T> Pagination<T, K>(this IEnumerable<T> queryable, BasePagination<K> basePagination)
            where K : class
         {
             return queryable.Skip(basePagination.SkipEntity).Take(basePagination.TakeEntity);
         }*/
        #region CustomOrderBy
        #endregion
    }

    #region Enums
    public enum TourAnalyticalInformation
    {
        SetTheFirstRecord,
        SetTheLatestRecord,
        MostScore,
        MinimumScore,
        MostFavorite,
        MinimumFavorite
    }
    public enum PostAnalyticalInformation
    {
        SetTheFirstRecord,
        SetTheLatestRecord,
        MostVisit,
        MinimumVisit,
        MostLike,
        MinimumLike,
        MostFavorite,
        MinimumFavorite
    }
    public enum FactorAnalyticalInformation
    {
        SetTheFirstRecord,
        SetTheLatestRecord,
        TimeToCreateSooner,
        TimeToCreateLater
    }
    #endregion
}
