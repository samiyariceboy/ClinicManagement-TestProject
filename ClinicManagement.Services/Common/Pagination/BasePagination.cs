namespace ClinicManagement.Services.Common.Pagination
{
    public class BasePagination
    {
        public BasePagination()
        {
            PageId = 1;
            TakeEntity = 4;
        }
        /// <summary>
        /// Explain: شماره صفحه
        /// </summary>
        public int PageId { get; set; }
        /// <summary>
        /// Explain: تعداد صفحات => مقدار دهی نشود / تاثیری ندارد
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Explain: شماره صفحه فعلی
        /// </summary>
        public int ActivePage { get; set; }

        /// <summary>
        /// Explain: صفحه شروع
        /// </summary>
        public int StartPage { get; set; }

        /// <summary>
        /// Explain: صفحه پایان
        /// </summary>
        public int EndPage { get; set; }

        /// <summary>
        /// Explain: تعداد نمایش در هر هر صفحه
        /// </summary>
        public int TakeEntity { get; set; }

        /// <summary>
        /// Explain: مقدار دهی نشود/تاثیری ندارد
        /// </summary>
        public int SkipEntity { get; set; }
    }

    public class BasePagination<TPagiationSelectedDto>
       where TPagiationSelectedDto : class
    {
        public BasePagination()
        {
            PageId = 1;
            TakeEntity = 4;
        }
        /// <summary>
        /// Explain: شماره صفحه
        /// </summary>
        public int PageId { get; set; }
        /// <summary>
        /// Explain: تعداد صفحات => مقدار دهی نشود / تاثیری ندارد
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Explain: شماره صفحه فعلی
        /// </summary>
        public int ActivePage { get; set; }

        /// <summary>
        /// Explain: صفحه شروع
        /// </summary>
        public int StartPage { get; set; }

        /// <summary>
        /// Explain: صفحه پایان
        /// </summary>
        public int EndPage { get; set; }

        /// <summary>
        /// Explain: تعداد نمایش در هر هر صفحه
        /// </summary>
        public int TakeEntity { get; set; }

        /// <summary>
        /// Explain: مقدار دهی نشود/تاثیری ندارد
        /// </summary>
        public int SkipEntity { get; set; }

        public virtual TPagiationSelectedDto? SetPagination(BasePagination<TPagiationSelectedDto> basePagination)
        {
            PageId = basePagination.ActivePage;
            PageCount = basePagination.PageCount == int.MinValue ? 0 : basePagination.PageCount;
            StartPage = basePagination.StartPage == int.MinValue ? 0 : basePagination.StartPage;
            EndPage = basePagination.EndPage == int.MinValue ? 0 : basePagination.EndPage;
            TakeEntity = basePagination.TakeEntity;
            SkipEntity = basePagination.SkipEntity;
            ActivePage = basePagination.ActivePage;
            return this as TPagiationSelectedDto;
        }
    }
}
